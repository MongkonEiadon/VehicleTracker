using System.Threading;
using System.Threading.Tasks;

using VehicleTracker.Business.VehicleDomain;

namespace VehicleTracker.Application.CommandServices {
    public interface IVehicleCommandService {
        Task CreateNewVehicleAsync(VehicleEntity vehicleEntity, CancellationToken ctx);
    }
}