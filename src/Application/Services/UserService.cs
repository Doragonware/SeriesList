using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using Domain.UnitOfWorks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        /// <summary>
        /// <see cref="IUnitOfWork"/> to use for accessing storage.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }


        public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _unitOfWork.Users.Create(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}