using EventFlow.ValueObjects;

namespace VehicleTracker.Business {
    public class CorrelationId : SingleValueObject<CorrelationId> {
        public CorrelationId(CorrelationId value) : base(value) {
        }
    }
}