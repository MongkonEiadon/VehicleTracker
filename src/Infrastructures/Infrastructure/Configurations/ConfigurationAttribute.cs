using System;

namespace Infrastructure.Configurations {
    public class ConfigurationAttribute : Attribute {
        public ConfigurationAttribute(string key) {
            Key = key;
        }

        public string Key { get; }
    }
}