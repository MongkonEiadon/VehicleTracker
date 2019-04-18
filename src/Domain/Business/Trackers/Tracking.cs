using EventFlow.Entities;

namespace Domain.Business.Trackers {
    public class Tracking : Entity<TrackingId> {
        public Tracking(TrackingId id) : base(id) {
        }
    }
}