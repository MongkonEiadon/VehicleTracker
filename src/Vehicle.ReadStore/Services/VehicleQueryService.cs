using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Queries;
using VehicleTracker.Application.QueryServices;
using VehicleTracker.Business.VehicleDomain;

namespace Vehicle.ReadStore.Services
{

    public class VehicleQueryService : IVehicleQueryService
    {
        private readonly IQueryProcessor _queryProcessor;

        public VehicleQueryService(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }


        public async Task<VehicleTracker.Business.VehicleDomain.VehicleModel> GetVehicleByIdAsync(VehicleId id, CancellationToken ctx)
        {
            var result = await _queryProcessor.ProcessAsync(new ReadModelByIdQuery<VehicleReadModel>(id), ctx);

            return result?.ToVehicle();
        }
    }
}
