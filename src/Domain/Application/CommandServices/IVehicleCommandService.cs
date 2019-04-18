using System.Threading;
using System.Threading.Tasks;

using Domain.Business.Vehicles;

namespace Domain.Application.CommandServices {
    public interface IVehicleCommandService {
        Task CreateNewVehicleAsync(VehicleEntity vehicleEntity, CancellationToken ctx);

        Task UpdateVehicleLocationAsync(VehicleId vehicleId, double latitude, double longitude, double zindex, CancellationToken ctx);

    }
}