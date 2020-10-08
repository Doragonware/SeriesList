using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.UnitOfWorks.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWorks.EFCore.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        /// <summary>
        /// <see cref="SeriesListContext"/> to use for storage.
        /// </summary>
        private readonly SeriesListContext _seriesListContext;

        public AuthRepository(SeriesListContext seriesListContext)
        {
            if (seriesListContext == null)
                throw new ArgumentNullException(nameof(seriesListContext));

            _seriesListContext = seriesListContext;
        }

        public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default)
            => await _seriesListContext.Set<User>().AnyAsync(predicate, cancellationToken);

        public async Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default)
            => await _seriesListContext.Set<User>().FirstOrDefaultAsync(predicate, cancellationToken);
    }
}