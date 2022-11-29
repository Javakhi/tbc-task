using Microsoft.EntityFrameworkCore;

namespace TBC.Infrastructure.DbContexts
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonDbContext).Assembly);
        }
    }
}
