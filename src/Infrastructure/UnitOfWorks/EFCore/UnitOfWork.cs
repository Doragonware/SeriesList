using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.UnitOfWorks;
using Domain.UnitOfWorks.Repositories;
using Infrastructure.UnitOfWorks.EFCore.Repositories;

namespace Infrastructure.UnitOfWorks.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// <see cref="SeriesListContext" /> to use for storage.
        /// </summary>
        private readonly SeriesListContext _seriesListContext;

        /// <summary>
        /// Hidden field for <see cref="Series"/>.
        /// </summary>
        private ISerieRepository _series;
        private IAuthRepository _auth;
        private IUserRepository _users;


        /// <summary>
        /// Constructs <see cref="UnitOfWork"/> with the provided information.
        /// </summary>
        /// <param name="seriesListContext"><see cref="SeriesListContext"/>to use for storage.</param>
        public UnitOfWork(SeriesListContext seriesListContext)
        {
            if (seriesListContext == null)
                throw new ArgumentNullException(nameof(seriesListContext));

            _seriesListContext = seriesListContext;
        }

        public ISerieRepository Series
            => (_series ??= new SerieRepository(_seriesListContext));

        public IAuthRepository Auth
        => (_auth ??= new AuthRepository(_seriesListContext));

        public IUserRepository Users
            => (_users ??= new UserRepository(_seriesListContext));


        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _seriesListContext.SaveChangesAsync(cancellationToken);
        }
    }
}