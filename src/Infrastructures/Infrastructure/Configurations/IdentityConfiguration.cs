namespace Infrastructure.Configurations
{
    public class IdentityConfiguration : ConfigurationBinder<IdentityConfiguration>
    {
        [Configuration(Identifiers.IDS_URL)]
        public string IdentityServerUrl { get; set; }
    }
}