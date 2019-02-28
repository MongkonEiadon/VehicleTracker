using System.Threading;
using System.Threading.Tasks;

using EventFlow;

using VehicleTracker.Application.CommandServices;
using VehicleTracker.Business.VehicleDomain;

namespace Vehicle.ReadStore.Services {
    public class VehicleCommandService : IVehicleCommandService {
        private readonly ICommandBus _commandBus;
        public VehicleCommandService(ICommandBus commandBus) {
            _commandBus = commandBus;
        }

        public Task CreateNewVehicleAsync(VehicleEntity vehicleEntity, CancellationToken ctx) {
            throw new System.NotImplementedException();
        }
    }
}