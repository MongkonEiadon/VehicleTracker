using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using EventFlow.Aggregates;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.ReadStores;
using EventFlow.ReadStores;

using Microsoft.EntityFrameworkCore;

namespace VehicleTracker.Infrastructure {
    public interface ISearchableReadModelStore<TReadModel> : IReadModelStore<TReadModel>
        where TReadModel : class, IReadModel, new() {
        Task<IReadOnlyCollection<TReadModel>> FindAsync(
            Predicate<TReadModel> predicate,
            CancellationToken cancellationToken);
    }
}