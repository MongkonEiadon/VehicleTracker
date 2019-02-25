using EventFlow.Core;

namespace VehicleTracker.Domain.Business.CustomerDomain
{
    public class CustomerId : Identity<CustomerId>
    {
        public CustomerId(string value) : base(value)
        {
        }
    }
}