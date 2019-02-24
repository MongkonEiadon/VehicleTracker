using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vehicle = Vehicle7Tracker.Domain.Business.VehicleDomain.Vehicle;
using Vehicle7Tracker.Domain.Business.VehicleDomain;

namespace Vehicle7Tracker.Domain.Application.QueryServices
{
    public interface IVehicleQueryService
    {
        Task<Vehicle> GetVehicleByIdAsync(VehicleId id, CancellationToken ctx);
    }
}
