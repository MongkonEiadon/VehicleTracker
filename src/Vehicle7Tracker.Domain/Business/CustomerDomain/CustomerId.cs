using EventFlow.Core;

namespace Vehicle7Tracker.Domain.Business.CustomerDomain
{
    public class CustomerId : Identity<CustomerId>
    {
        public CustomerId(string value) : base(value)
        {
        }
    }
}