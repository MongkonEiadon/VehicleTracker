using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Domain.Business.Vehicles;

namespace Domain.Application.CommandServices
{
    public interface ITrackingCommandService
    {
        Task StoreVehicleLocationAsync(Guid vehicleId, double latitude, double longitude, double zindex, CancellationToken ctx);
    }
}
