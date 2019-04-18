using System.Threading;
using System.Threading.Tasks;

using Domain.Application.CommandServices;
using Domain.Business.Vehicles;
using Domain.Business.Vehicles.Commands;

using EventFlow;


namespace Vehicles.ReadStore.Services {
    public class VehicleCommandService : IVehicleCommandService {
        private readonly ICommandBus _commandBus;
        public VehicleCommandService(ICommandBus commandBus) {
            _commandBus = commandBus;
        }

        public async Task CreateNewVehicleAsync(VehicleEntity vehicleEntity, CancellationToken ctx) {

            await _commandBus.PublishAsync(new RegisterVehicleCommand(vehicleEntity), ctx);
        }

        public async Task UpdateVehicleLocationAsync(VehicleId id, double latitude, double longitude, double zindex, CancellationToken ctx) {
            await _commandBus.PublishAsync(new UpdateVehicleLocationCommand(id, latitude, longitude, zindex), ctx);
        }

    }
}