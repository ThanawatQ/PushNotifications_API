self.importScripts('/scripts/push-notifications-controller.js');

const pushNotificationTitle = 'Notification';

self.addEventListener('push', function (event) {

    let jsonObject = JSON.parse(event.data.text());
    event.waitUntil(self.registration.showNotification(jsonObject.Title,
        {
            body: jsonObject.Notification,
            icon: jsonObject.icon,
            tag: "vibration-sample",
            data: { url: jsonObject.action.Url },
            actions: [{ action: jsonObject.action.action, title: jsonObject.action.title }],
        }
    ));
});
self.addEventListener('notificationclick', function (event) {
    event.notification.close();
    if (event.action === 'open_url') {
        clients.openWindow(event.notification.data.url)
    } 
}, false);


self.addEventListener('pushsubscriptionchange', function (event) {
    const handlePushSubscriptionChangePromise = Promise.resolve();

    if (event.oldSubscription) {
        handlePushSubscriptionChangePromise = handlePushSubscriptionChangePromise.then(function () {
            return PushNotificationsController.discardPushSubscription(event.oldSubscription);
        });
    }

    if (event.newSubscription) {
        handlePushSubscriptionChangePromise = handlePushSubscriptionChangePromise.then(function () {
            return PushNotificationsController.storePushSubscription(event.newSubscription);
        });
    }

    if (!event.newSubscription) {
        handlePushSubscriptionChangePromise = handlePushSubscriptionChangePromise.then(function () {
            return PushNotificationsController.retrievePublicKey().then(function (applicationServerPublicKey) {
                return pushServiceWorkerRegistration.pushManager.subscribe({
                    userVisibleOnly: true,
                    applicationServerKey: applicationServerPublicKey
                }).then(function (pushSubscription) {
                    return PushNotificationsController.storePushSubscription(pushSubscription);
                });
            });
        });
    }

    event.waitUntil(handlePushSubscriptionChangePromise);
});

self.addEventListener('notificationclick', function (event) {
    event.notification.close();
});