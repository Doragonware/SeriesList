using System.Threading;
using System.Threading.Tasks;
using Domain.UnitOfWorks.Repositories;

namespace Domain.UnitOfWorks
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// <see cref="ISerieRepository"/> to use for accessing and storing series.
        /// </summary>
        public ISerieRepository Series { get; }

        /// <summary>
        /// Save all changes in unit of work.
        /// </summary>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}