using EventFlow.Core;

namespace VehicleTracker.Business.CustomerDomain {
    public class CustomerId : Identity<CustomerId> {
        public CustomerId(string value) : base(value) {
        }
    }

}