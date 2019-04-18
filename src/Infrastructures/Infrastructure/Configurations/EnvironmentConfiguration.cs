namespace Infrastructure.Configurations {
    public class EnvironmentConfiguration : ConfigurationBinder<EnvironmentConfiguration> {
        [Configuration(Identifiers.ES_CONNECTION)]
        public string EventSourcingConnection { get; set; }

        [Configuration(Identifiers.DB_CONNECTION)]
        public string DbConnection { get; set; }

        [Configuration(Identifiers.SNAPSHOT_EVERY)]
        public int SnapshotEvery { get; set; } = 10;

        [Configuration(Identifiers.RABBIT_CONNECTION)]
        public string RabbitMqConnection { get; set; }

        [Configuration(Identifiers.SERVICE_NAME)]
        public string ServiceName { get; set; }

        [Configuration(Identifiers.RABBIT_QUEUE)]
        public string RabbitQueueName { get; set; } = "eventflow";

        [Configuration(Identifiers.RABBIT_EXCHANGE)]
        public string RabbitExchange { get; set; }
    }
}