using Newtonsoft.Json;

namespace Tracking.Service.ViewModels {

    public class TrackingViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

    }
}