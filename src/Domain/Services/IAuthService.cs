using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="user">user object.</param>
        /// <param name="password">user specified password.</param>
        /// <returns>register user</returns>
         Task<User> Register(User user, string password);

         /// <summary>
         /// Creates a crypted password with hash and salt.
         /// </summary>
         /// <param name="password">password user specifies to create an user.</param>
         void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

         /// <summary>
         /// Login with username and password.
         /// </summary>
         /// <param name="username">username to login.</param>
         /// <param name="password">password to login.</param>
         /// <returns></returns>
         Task<User> Login(string username, string password);

         /// <summary>
         /// Verifies the password if it is correct.
         /// </summary>
         /// <param name="password">User specified password.</param>
         /// <returns>Returns true or false.</returns>
         bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);


        /// <summary>
        /// Checks the database for usernames which already exists or not.
        /// </summary>
        /// <param name="username">to check in database if it exists.</param>
        /// <returns>True or false if the user exists.</returns>
         Task<bool> UserExists(string username);

    }
}