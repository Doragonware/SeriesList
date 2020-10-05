using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.UnitOfWorks.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWorks.EFCore.Repositories
{
    public sealed class SerieRepository : ISerieRepository
    {
        /// <summary>
        /// <see cref="SeriesListContext"/> to use for storage.
        /// </summary>
        private readonly SeriesListContext _seriesListContext;


        public SerieRepository(SeriesListContext seriesListContext)
        {
            if (seriesListContext == null)
                throw new ArgumentNullException(nameof(seriesListContext));

            _seriesListContext = seriesListContext;
        }

        public async Task<IReadOnlyCollection<Serie>> AllSync(CancellationToken cancellationToken = default)
            => await _seriesListContext.Set<Serie>().ToListAsync(cancellationToken);

        public Serie Create(Serie serie)
        {
            if (serie == null)
                throw new ArgumentNullException(nameof(serie));

            var entry = _seriesListContext.Set<Serie>().Add(serie);

            return entry.Entity;
        }

        public Serie Delete(Serie serie)
        {
            if (serie == null)
                throw new ArgumentNullException(nameof(serie));

            var entry = _seriesListContext.Set<Serie>().Remove(serie);

            return entry.Entity;
        }

        public async Task<Serie> SingleOrDefaltAsync(int id, CancellationToken cancellationToken = default)
            => await _seriesListContext.Set<Serie>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        public Serie Update(Serie serie)
        {
            if (serie == null)
                throw new ArgumentNullException(nameof(serie));

            var entry = _seriesListContext.Set<Serie>().Update(serie);

            return entry.Entity;
        }
    }
}