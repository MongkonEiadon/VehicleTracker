using EventFlow.Core;

namespace Domain.Business.Customers {
    public class CustomerId : Identity<CustomerId> {
        public CustomerId(string value) : base(value) {
        }
    }

}