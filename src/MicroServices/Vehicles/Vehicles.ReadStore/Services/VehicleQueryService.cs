using System.Threading;
using System.Threading.Tasks;

using Domain.Application.QueryServices;
using Domain.Business.Vehicles;

using EventFlow.Queries;


namespace Vehicles.ReadStore.Services {
    public class VehicleQueryService : IVehicleQueryService {
        private readonly IQueryProcessor _queryProcessor;

        public VehicleQueryService(IQueryProcessor queryProcessor) {
            _queryProcessor = queryProcessor;
        }


        public async Task<VehicleEntity> GetVehicleByIdAsync(VehicleId id, CancellationToken ctx) {
            var result = await _queryProcessor.ProcessAsync(new ReadModelByIdQuery<VehicleReadModel>(id), ctx);

            return result?.ToVehicle();
        }

    }
}