using System;
using System.Collections.Generic;

namespace Vehicle7Tracker.Domain.Infrastructure
{
    public sealed class ServiceConfiguration : MiddlewareConfiguration
    {
        private static volatile object _sync = new object();

        //initialize read
        public override MiddlewareConfiguration Create(IDictionary<string, string> configuration)
        {
            lock (_sync)
            {
                var _instance = new ServiceConfiguration();
                
                //runtime metadata filling configuration for this object.
                foreach (var item in configuration ?? throw new ArgumentNullException($"configuration is required."))
                {
                    var property = _instance.GetType().GetProperty(item.Key) ??
                                   throw new KeyNotFoundException($"{item.Key} is not recognized as configuration field.");
                    property.SetValue(obj: _instance, value: item.Value);
                }
                return _instance;
            }
        }
    }
}