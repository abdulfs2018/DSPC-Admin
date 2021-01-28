using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            List<GraveOwner> graveOwners = modelBuilder.SeedGraveOwnerCSV();
            modelBuilder.SeedRegistrarCSV(graveOwners);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // more detailed debugging when running update-database or dotnet ef database update commands
            optionsBuilder.EnableSensitiveDataLogging();
        }

    }
}
