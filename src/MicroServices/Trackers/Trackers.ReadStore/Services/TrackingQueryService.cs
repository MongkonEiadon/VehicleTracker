using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Domain.Application.QueryServices;
using Domain.Business.Trackers.Query;
using Domain.Business.Vehicles;

using EventFlow.Queries;

using Trackers.ReadStore.ReadModels;


namespace Trackers.ReadStore.Services
{
    public class TrackingQueryService : ITrackingQueryService
    {

        private readonly IQueryProcessor _queryProcessor;

        public TrackingQueryService(IQueryProcessor queryProcessor) {
            _queryProcessor = queryProcessor;
        }

        public async Task<LocationEntity> GetCurrentVehicleLocationAsync(VehicleId id, CancellationToken ctx)
        {
            var result = await _queryProcessor.ProcessAsync(new ReadModelByIdQuery<LocationReadModel>(id), ctx);

            return result?.ToLocation();
        }

        public Task<IEnumerable<LocationEntity>> GetLocationHistoryAsync(VehicleId id, CancellationToken ctx) {
            return _queryProcessor.ProcessAsync(new LocationHistoryQuery(id), ctx);
        }
    }

}
