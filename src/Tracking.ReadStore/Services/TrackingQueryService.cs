using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using EventFlow.Queries;

using Tracking.ReadStore.ReadModels;

using VehicleTracker.Application.QueryServices;
using VehicleTracker.Business.TrackingDomain.Query;
using VehicleTracker.Business.VehicleDomain;

namespace Tracking.ReadStore.Services
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
