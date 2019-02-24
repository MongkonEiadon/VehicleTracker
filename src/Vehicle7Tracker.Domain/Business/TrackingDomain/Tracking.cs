using EventFlow.Entities;

namespace Vehicle7Tracker.Domain.Business.TrackingDomain
{
    public class Tracking : Entity<TrackingId>
    {
        public Tracking(TrackingId id) : base(id)
        {
        }
    }
}