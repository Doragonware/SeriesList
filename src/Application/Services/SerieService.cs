using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using Domain.UnitOfWorks;

namespace Application.Services
{
    public class SerieService : ISerieService
    {
        /// <summary>
        /// <see cref="IUnitOfWork"/> to use for accessing storage.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        public SerieService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }


        public async Task<IReadOnlyCollection<Serie>> AllAsync(CancellationToken cancellationToken = default)
        {
            var series = await _unitOfWork.Series.AllSync(cancellationToken);
            return series;
        }

        public async Task<Serie> SingleOrDefaultAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "can't be less than zero.");
            var serie = await _unitOfWork.Series.SingleOrDefaltAsync(id, cancellationToken);
            return serie;
        }

        public async Task<Serie> CreateAsync(Serie serie, CancellationToken cancellationToken = default)
        {
            if (serie == null)
                throw new ArgumentNullException(nameof(serie));

            _unitOfWork.Series.Create(serie);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return serie;
        }

        public async Task<Serie> UpdateAsync(Serie serie, CancellationToken cancellationToken = default)
        {
            if (serie == null)
                throw new ArgumentNullException(nameof(serie));

            _unitOfWork.Series.Update(serie);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return serie;
        }

        public async Task<Serie> RemoveAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "can't be less than zero.");

            var serieToDelete = await _unitOfWork.Series.SingleOrDefaltAsync(id, cancellationToken);

            _unitOfWork.Series.Delete(serieToDelete);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return serieToDelete;
        }
    }
}