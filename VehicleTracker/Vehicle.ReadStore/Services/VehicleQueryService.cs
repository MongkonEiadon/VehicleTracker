using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Queries;
using Vehicle7Tracker.Domain.Application.QueryServices;
using Vehicle7Tracker.Domain.Business.VehicleDomain;

namespace Vehicle.ReadStore.Services
{

    public class VehicleQueryService : IVehicleQueryService
    {
        private readonly IQueryProcessor _queryProcessor;

        public VehicleQueryService(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }


        public async Task<Vehicle7Tracker.Domain.Business.VehicleDomain.Vehicle> GetVehicleByIdAsync(VehicleId id, CancellationToken ctx)
        {
            var result = await _queryProcessor.ProcessAsync(new ReadModelByIdQuery<VehicleReadModel>(id), ctx);

            return result?.ToVehicle();
        }
    }
}
