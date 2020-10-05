using Infrastructure.UnitOfWorks.EFCore.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWorks.EFCore
{
    public class SeriesListContext : DbContext
    {
        public SeriesListContext(DbContextOptions<SeriesListContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
            modelBuilder.ApplyConfiguration(new SerieETC());
        }
    }
}