using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Queries;
using Vehicle7Tracker.Domain.Application.QueryServices;
using Vehicle7Tracker.Domain.Business.VehicleDomain;

namespace Vehicle7Tracker.Domain.Application.CommandServices
{
    public interface IVehicleCommandServices
    {
        Task CreateNewVehicleAsync(Vehicle vehicleModel, CancellationToken ctx);
    }

}
