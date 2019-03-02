using System;
using System.Threading;
using System.Threading.Tasks;

using EventFlow;

using VehicleTracker.Application.CommandServices;
using VehicleTracker.Business.VehicleDomain;
using VehicleTracker.Business.VehicleDomain.Commands;

namespace Tracking.ReadStore.Services {

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