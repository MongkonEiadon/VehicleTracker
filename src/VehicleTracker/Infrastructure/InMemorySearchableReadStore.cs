using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using EventFlow.Logs;
using EventFlow.ReadStores;
using EventFlow.ReadStores.InMemory;

using VehicleTracker.Application;

namespace VehicleTracker.Infrastructure {
    public class InMemorySearchableReadStore<TReadModel> : InMemoryReadStore<TReadModel>,
        ISearchableReadModelStore<TReadModel>
        where TReadModel : class, IReadModel, new() {
        public InMemorySearchableReadStore(
            ILog log)
            : base(log) {
        }


        public new Task<IReadOnlyCollection<TReadModel>> FindAsync(
            Predicate<TReadModel> predicate,
            CancellationToken cancellationToken) {
            return base.FindAsync(predicate, cancellationToken);
        }
    }
}