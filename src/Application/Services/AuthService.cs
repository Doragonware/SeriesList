using System;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using Domain.UnitOfWorks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {

        /// <summary>
        /// <see cref="IUnitOfWork"/> to use for accessing storage.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;


        public AuthService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<User> Login(string username, string password)
        {
            User user = await _unitOfWork.Auth.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _unitOfWork.Users.Create(user);
            await _unitOfWork.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _unitOfWork.Auth.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
    }
}