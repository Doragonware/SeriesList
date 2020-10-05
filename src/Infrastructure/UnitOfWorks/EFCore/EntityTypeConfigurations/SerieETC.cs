using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.UnitOfWorks.EFCore.EntityTypeConfigurations
{
    public class SerieETC : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.HasKey(serie => serie.Id);
        }
    }
}