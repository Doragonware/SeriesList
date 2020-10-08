using System;
using Domain.Entities;
using Domain.UnitOfWorks.Repositories;

namespace Infrastructure.UnitOfWorks.EFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// <see cref="SeriesListContext"/> to use for storage.
        /// </summary>
        private readonly SeriesListContext _seriesListContext;

        public UserRepository(SeriesListContext seriesListContext)
        {
            if (seriesListContext == null)
                throw new ArgumentNullException(nameof(seriesListContext));

            _seriesListContext = seriesListContext;
        }


        public User Create(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var entry = _seriesListContext.Set<User>().Add(user);

            return entry.Entity;
        }
    }
}