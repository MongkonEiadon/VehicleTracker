using Newtonsoft.Json;

namespace Trackers.Service.ViewModels {

    public class TrackingViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

    }
}