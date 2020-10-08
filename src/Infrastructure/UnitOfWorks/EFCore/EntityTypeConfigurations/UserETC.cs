using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWorks.EFCore.EntityTypeConfigurations
{
    public class UserETC : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
        }
    }
}