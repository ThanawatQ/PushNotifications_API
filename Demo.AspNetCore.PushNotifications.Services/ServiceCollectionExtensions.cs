using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PushNotifications.Services.Abstractions;
using PushNotifications.Services.Sqlite;
using PushNotifications.Services.PushService;

namespace PushNotifications.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPushSubscriptionStore(this IServiceCollection services, IConfiguration configuration)
        {
            switch (configuration.GetSubscriptionStoreType())
            {
                case SubscriptionStoreTypes.Sqlite:
                    services.AddSqlitePushSubscriptionStore(configuration);
                    break;
                default:
                    throw new NotSupportedException($"Not supported {nameof(IPushSubscriptionStore)} type.");
            }

            return services;
        }

        public static IServiceCollection AddPushNotificationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.AddPushServicePushNotificationService(configuration);

            return services;
        }

        public static IServiceCollection AddPushNotificationsQueue(this IServiceCollection services)
        {
            services.AddSingleton<IPushNotificationsQueue, PushNotificationsQueue>();
            services.AddSingleton<IHostedService, PushNotificationsDequeuer>();

            return services;
        }
    }
}
