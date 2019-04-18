using EventFlow.Core;

namespace Domain.Business.Trackers {
    public class TrackingId : Identity<TrackingId> {
        public TrackingId(string value) : base(value) {
        }
    }
}