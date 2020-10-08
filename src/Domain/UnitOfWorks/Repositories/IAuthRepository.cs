using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.UnitOfWorks.Repositories
{
    public interface IAuthRepository
    {
         Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default);
         Task<bool> AnyAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default);
    }
}