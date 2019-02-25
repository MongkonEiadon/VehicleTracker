using System;
using System.Collections.Generic;
using System.Text;
using EventFlow.ValueObjects;

namespace VehicleTracker.Domain.Business
{
    public class CorrelationId : SingleValueObject<CorrelationId>
    {
        public CorrelationId(CorrelationId value) : base(value)
        {
        }
    }
}
