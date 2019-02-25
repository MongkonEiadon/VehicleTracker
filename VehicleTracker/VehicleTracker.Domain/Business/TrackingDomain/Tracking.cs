using EventFlow.Entities;

namespace VehicleTracker.Domain.Business.TrackingDomain
{
    public class Tracking : Entity<TrackingId>
    {
        public Tracking(TrackingId id) : base(id)
        {
        }
    }
}