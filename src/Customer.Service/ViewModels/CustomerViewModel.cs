using Newtonsoft.Json;

namespace Customer.Service.ViewModels {

    public class CustomerViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}