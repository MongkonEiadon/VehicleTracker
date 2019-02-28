using System.Threading;
using System.Threading.Tasks;

using VehicleTracker.Business.VehicleDomain;

namespace VehicleTracker.Application.QueryServices {
    public interface IVehicleQueryService {
        Task<VehicleEntity> GetVehicleByIdAsync(VehicleId id, CancellationToken ctx);
    }
}