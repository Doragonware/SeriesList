using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Services
{
    public interface ISerieService
    {
        /// <summary>
        /// Gets all Series.
        /// </summary>
        /// <returns>List of Series.</returns>
        Task<IReadOnlyCollection<Serie>> AllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a single Serie.
        /// </summary>
        /// <param name="id">Id of the Serie to return.</param>
        /// <returns>Serie by id.</returns>
        Task<Serie> SingleOrDefaultAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new Serie.
        /// </summary>
        /// <param name="serie">Serie to create.</param>
        /// <returns>Serie which were created.</returns>
        Task<Serie> CreateAsync(Serie serie, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a Serie.
        /// </summary>
        /// <param name="serie">Serie to update.</param>
        /// <returns>Serie which where updated.</returns>
        Task<Serie> UpdateAsync(Serie serie, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes a Serie.
        /// </summary>
        /// <param name="serie">Serie to remove.</param>
        /// <returns>Serie which were removed.</returns>
        Task<Serie> RemoveAsync(Serie serie, CancellationToken cancellationToken = default);
    }
}