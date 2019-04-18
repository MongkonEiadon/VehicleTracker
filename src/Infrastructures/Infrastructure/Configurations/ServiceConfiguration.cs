namespace Infrastructure.Configurations {
    public class ServiceConfiguration : ConfigurationBinder<ServiceConfiguration> {
        [Configuration(Identifiers.ACCOUNTS_URL)]
        public string AccountServiceEndPointUrl { get; set; }
    }
}