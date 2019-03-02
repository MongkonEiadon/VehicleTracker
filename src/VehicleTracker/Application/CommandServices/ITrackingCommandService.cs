using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using VehicleTracker.Business.VehicleDomain;

namespace VehicleTracker.Application.CommandServices
{
    public interface ITrackingCommandService
    {
        Task StoreVehicleLocationAsync(Guid vehicleId, double latitude, double longitude, double zindex, CancellationToken ctx);
    }
}
