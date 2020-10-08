using Domain.Entities;

namespace Domain.UnitOfWorks.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Creates a User.
        /// </summary>
        /// <param name="user">User to create.</param>
        User Create(User user);
    }
}