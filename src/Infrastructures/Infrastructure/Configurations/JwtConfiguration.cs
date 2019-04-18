namespace Infrastructure.Configurations {
    public class JwtConfiguration : ConfigurationBinder<JwtConfiguration> {

        [Configuration(Identifiers.JWT_KEY)]
        public string JwtKey { get; set; }

        [Configuration(Identifiers.JWT_AUDIENCE)]
        public string JwtAudience { get; set; }

        [Configuration(Identifiers.JWT_ISSUER)]
        public string JwtIssuer { get; set; }
    }
}