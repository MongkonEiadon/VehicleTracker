using System;
using System.Collections.Generic;
using System.Text;
using EventFlow.ValueObjects;

namespace Vehicle7Tracker.Domain.Business
{
    public class CorrelationId : SingleValueObject<CorrelationId>
    {
        public CorrelationId(CorrelationId value) : base(value)
        {
        }
    }
}
