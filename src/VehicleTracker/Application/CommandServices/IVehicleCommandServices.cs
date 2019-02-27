using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Queries;
using VehicleTracker.Application.QueryServices;
using VehicleTracker.Business.VehicleDomain;

namespace VehicleTracker.Application.CommandServices
{
    public interface IVehicleCommandServices
    {
        Task CreateNewVehicleAsync(VehicleModel vehicleModelModel, CancellationToken ctx);
    }

}
