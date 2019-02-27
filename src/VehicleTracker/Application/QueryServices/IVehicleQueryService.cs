using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vehicle = VehicleTracker.Business.VehicleDomain.Vehicle;
using VehicleTracker.Business.VehicleDomain;

namespace VehicleTracker.Application.QueryServices
{
    public interface IVehicleQueryService
    {
        Task<Business.VehicleDomain.Vehicle> GetVehicleByIdAsync(VehicleId id, CancellationToken ctx);
    }
}
