using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracker.Business.VehicleDomain;

namespace VehicleTracker.Application.QueryServices
{
    public interface IVehicleQueryService
    {
        Task<Business.VehicleDomain.VehicleModel> GetVehicleByIdAsync(VehicleId id, CancellationToken ctx);
    }
}
