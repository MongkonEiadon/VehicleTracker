using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Queries;
using VehicleTracker.Domain.Application.QueryServices;
using VehicleTracker.Domain.Business.VehicleDomain;

namespace VehicleTracker.Domain.Application.CommandServices
{
    public interface IVehicleCommandServices
    {
        Task CreateNewVehicleAsync(Vehicle vehicleModel, CancellationToken ctx);
    }

}
