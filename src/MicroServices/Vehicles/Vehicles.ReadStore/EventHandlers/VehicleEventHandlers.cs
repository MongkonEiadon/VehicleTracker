using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Domain.Business.Vehicles;
using Domain.Business.Vehicles.Commands;
using Domain.Business.Vehicles.Events;

using EventFlow;
using EventFlow.Aggregates;
using EventFlow.Subscribers;

using Infrastructure.ReadStores;

namespace Vehicles.ReadStore.EventHandlers
{
    public class VehicleEventHandlers : 
        ISubscribeSynchronousTo<VehicleAggregate, VehicleId, VehicleRegisteredEvent> {

        private readonly ICommandBus _commandBus;
        private readonly ISearchableReadModelStore<VehicleReadModel> _vehicleSearchableReadModelStore;


        public VehicleEventHandlers(ICommandBus commandBus,
            ISearchableReadModelStore<VehicleReadModel> vehicleSearchableReadModelStore) {
            _commandBus = commandBus;
            _vehicleSearchableReadModelStore = vehicleSearchableReadModelStore;
        }


        public async Task HandleAsync(IDomainEvent<VehicleAggregate, VehicleId, VehicleRegisteredEvent> domainEvent, CancellationToken cancellationToken) {

            var existing = await _vehicleSearchableReadModelStore
                .FindAsync(
                    x => string.Equals(domainEvent.AggregateEvent.Vehicle.LicensePlateNumber, x.LicensePlateNumber,
                        StringComparison.CurrentCultureIgnoreCase), cancellationToken);

            if (existing == null) {
                await _commandBus.PublishAsync(new VehicleRegisterCompleteCommand(domainEvent.AggregateEvent.Vehicle),
                    cancellationToken);
            }

        }

    }
}
