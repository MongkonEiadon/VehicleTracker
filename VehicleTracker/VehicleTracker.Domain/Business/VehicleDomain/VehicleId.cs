using EventFlow.Core;

namespace VehicleTracker.Domain.Business.VehicleDomain
{
    public class VehicleId : Identity<VehicleId>
    {
        public VehicleId(string value) : base(value)
        {
        }
    }
}