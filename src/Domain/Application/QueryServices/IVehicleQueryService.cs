using System.Threading;
using System.Threading.Tasks;

using Domain.Business.Vehicles;

namespace Domain.Application.QueryServices {
    public interface IVehicleQueryService {
        Task<VehicleEntity> GetVehicleByIdAsync(VehicleId id, CancellationToken ctx);
    }
}