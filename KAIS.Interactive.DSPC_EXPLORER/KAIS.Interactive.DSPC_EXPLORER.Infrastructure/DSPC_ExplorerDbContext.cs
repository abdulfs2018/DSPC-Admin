using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;
using System.IO;
using CsvHelper;
using System.Linq;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model
{
    public class DSPC_ExplorerDbContext: DbContext
    {

        public DSPC_ExplorerDbContext(DbContextOptions<DSPC_ExplorerDbContext> options)
              : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<GraveOwner> GraveOwners { get; set; }
        public DbSet<Registrar> Registrars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.SeedInitialSections();
            //modelBuilder.SeedInitialGraveOwners();
            //modelBuilder.SeedIntialRegistrars();
            modelBuilder.SeedSectionCSV();
            modelBuilder.SeedGraveOwnerCSV();
            modelBuilder.SeedRegistrarCSV();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // more detailed debugging when running update-database or dotnet ef database update commands
            optionsBuilder.EnableSensitiveDataLogging();
        }

    }
}
