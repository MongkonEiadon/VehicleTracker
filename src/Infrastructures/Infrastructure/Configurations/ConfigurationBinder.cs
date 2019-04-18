using System;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configurations {
    public abstract class ConfigurationBinder<T> {
        public static T Bind(IConfiguration configuration) {
            var propsInfo = typeof(T).GetProperties().Where(x => x.GetCustomAttributes<ConfigurationAttribute>().Any());

            var instant = Activator.CreateInstance<T>();
            foreach (var pInfo in propsInfo) {
                var key = pInfo.GetCustomAttribute<ConfigurationAttribute>().Key;
                var value = configuration.GetValue<object>(key);

                pInfo.SetValue(instant, value);
            }

            return instant;
        }
    }
}