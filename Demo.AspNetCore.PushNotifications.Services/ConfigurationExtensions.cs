using System;
using Microsoft.Extensions.Configuration;
using PushNotifications.Services.Abstractions;

namespace PushNotifications.Services
{
    internal static class ConfigurationExtensions
    {
        private const string SUBSCRIPTION_STORE_TYPE_CONFIGURATION_KEY = "PushSubscriptionStoreType";
        private const string SUBSCRIPTION_STORE_TYPE_SQLITE = "Sqlite";

        public static SubscriptionStoreTypes GetSubscriptionStoreType(this IConfiguration configuration)
        {
            string subscriptionStoreType = configuration.GetValue(SUBSCRIPTION_STORE_TYPE_CONFIGURATION_KEY, SUBSCRIPTION_STORE_TYPE_SQLITE);

            if (subscriptionStoreType.Equals(SUBSCRIPTION_STORE_TYPE_SQLITE, StringComparison.InvariantCultureIgnoreCase))
            {
                return SubscriptionStoreTypes.Sqlite;
            }
            else
            {
                throw new NotSupportedException($"Not supported {nameof(IPushSubscriptionStore)} type.");
            }
        }
    }
}
