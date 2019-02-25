using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vehicle = VehicleTracker.Domain.Business.VehicleDomain.Vehicle;
using VehicleTracker.Domain.Business.VehicleDomain;

namespace VehicleTracker.Domain.Application.QueryServices
{
    public interface IVehicleQueryService
    {
        Task<Vehicle> GetVehicleByIdAsync(VehicleId id, CancellationToken ctx);
    }
}
