using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.UnitOfWorks.Repositories
{
    public interface ISerieRepository
    {
        /// <summary>
        /// All Series.
        /// </summary>
        /// <returns>List of all Series.</returns>
        Task<IReadOnlyCollection<Serie>> AllSync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a Serie.
        /// </summary>
        /// <param name="serie">Serie to create.</param>
        Serie Create(Serie serie);

        /// <summary>
        /// Gets a single Serie with the provided id.
        /// </summary>
        /// <param name="id">Id of the Serie.</param>
        /// <returns>A single Serie or null if not found.</returns>
        Task<Serie> SingleOrDefaltAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a Serie.
        /// </summary>
        /// <param name="serie">Serie to update.</param>
        Serie Update(Serie serie);

        /// <summary>
        /// Deletes a Serie.
        /// </summary>
        /// <param name="serie">Serie to delete.</param>
        Serie Delete(Serie serie);
    }
}