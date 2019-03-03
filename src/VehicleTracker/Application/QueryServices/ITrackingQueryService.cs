using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using VehicleTracker.Business.VehicleDomain;

namespace VehicleTracker.Application.QueryServices
{
    public interface ITrackingQueryService {

        Task<LocationEntity> GetCurrentVehicleLocationAsync(VehicleId id, CancellationToken ctx);

        Task<IEnumerable<LocationEntity>> GetLocationHistoryAsync(VehicleId id, CancellationToken ctx);

    }
}
