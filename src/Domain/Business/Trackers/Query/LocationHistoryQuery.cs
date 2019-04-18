using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Domain.Business.Vehicles;

using EventFlow.Aggregates;
using EventFlow.Queries;

namespace Domain.Business.Trackers.Query
{
    public class LocationHistoryQuery : IQuery<IEnumerable<LocationEntity>>
    {

        public VehicleId VehicleId { get; }

        public LocationHistoryQuery(VehicleId vehicleId) {
            VehicleId = vehicleId;
        }
    }


    internal class LocationHistoryQueryHandler : IQueryHandler<LocationHistoryQuery, IEnumerable<LocationEntity>> {

        private readonly IAggregateStore _aggregateStore;

        public LocationHistoryQueryHandler(IAggregateStore aggregateStore) {
            _aggregateStore = aggregateStore;
        }

        public async Task<IEnumerable<LocationEntity>> ExecuteQueryAsync(LocationHistoryQuery query, CancellationToken cancellationToken) {

            var agg = await _aggregateStore.LoadAsync<VehicleAggregate, VehicleId>(query.VehicleId, cancellationToken);
            return agg.GetLocationHistory();
        }

    }
}
