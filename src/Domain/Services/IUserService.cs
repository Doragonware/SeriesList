using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Creates a new User.
        /// </summary>
        /// <param name="user">User to create.</param>
        /// <returns>User which were created.</returns>
        Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
    }
}