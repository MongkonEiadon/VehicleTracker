using EventFlow.Core;

namespace VehicleTracker.Business.TrackingDomain {
    public class TrackingId : Identity<TrackingId> {
        public TrackingId(string value) : base(value) {
        }
    }
}