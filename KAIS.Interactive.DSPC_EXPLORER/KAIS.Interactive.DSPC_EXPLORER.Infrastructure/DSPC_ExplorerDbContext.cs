using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
            modelBuilder.SeedInitialSections();
            modelBuilder.SeedInitialGraveOwners();
            modelBuilder.SeedIntialRegistrars();
        }

    }
}
