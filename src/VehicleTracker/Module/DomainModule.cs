using System;
using System.Collections.Generic;
using System.Text;

using EventFlow;
using EventFlow.Configuration;
using EventFlow.Extensions;

namespace VehicleTracker.Module
{
    public class DomainModule : IModule
    {
        public void Register(IEventFlowOptions eventFlowOptions) {
            eventFlowOptions.AddDefaults(typeof(DomainModule).Assembly);
        }
    }
}
