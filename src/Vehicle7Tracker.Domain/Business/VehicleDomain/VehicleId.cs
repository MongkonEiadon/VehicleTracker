using EventFlow.Core;

namespace Vehicle7Tracker.Domain.Business.VehicleDomain
{
    public class VehicleId : Identity<VehicleId>
    {
        public VehicleId(string value) : base(value)
        {
        }
    }
}