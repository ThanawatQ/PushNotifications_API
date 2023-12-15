using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using PushNotifications.Services.Sqlite;


namespace PushNotifications.Services
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UsePushSubscriptionStore(this IApplicationBuilder app)
        {
            SubscriptionStoreTypes subscriptionStoreType = ((IConfiguration)app.ApplicationServices.GetService(typeof(IConfiguration))).GetSubscriptionStoreType();

            if (subscriptionStoreType == SubscriptionStoreTypes.Sqlite)
            {
                app.UseSqlitePushSubscriptionStore();
            }
            //else if (subscriptionStoreType == SubscriptionStoreTypes.CosmosDB)
            //{
            //    app.UseCosmosDbPushSubscriptionStore();
            //}

            return app;
        }
    }
}
