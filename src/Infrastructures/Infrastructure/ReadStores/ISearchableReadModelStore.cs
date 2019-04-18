using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using EventFlow.ReadStores;

namespace Infrastructure.ReadStores {
    public interface ISearchableReadModelStore<TReadModel> : IReadModelStore<TReadModel>
        where TReadModel : class, IReadModel, new() {
        Task<IReadOnlyCollection<TReadModel>> FindAsync(
            Predicate<TReadModel> predicate,
            CancellationToken cancellationToken);
    }
}