using System;
using System.Threading;
using System.Threading.Tasks;

using Domain.Application.CommandServices;
using Domain.Business.Vehicles;
using Domain.Business.Vehicles.Commands;

using EventFlow;

namespace Trackers.ReadStore.Services {

    public class TrackingCommandService : ITrackingCommandService {

        private readonly ICommandBus _commandBus;

        public TrackingCommandService(ICommandBus commandBus) {
            _commandBus = commandBus;
        }

        public async Task StoreVehicleLocationAsync(Guid vehicleId, double latitude, double longitude, double zindex, CancellationToken ctx) {
            
            await _commandBus.PublishAsync(new UpdateVehicleLocationCommand(VehicleId.With(vehicleId),
                latitude, longitude, zindex), ctx);

        }

    }

}