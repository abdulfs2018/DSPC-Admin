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
            modelBuilder.Entity<Section>().HasData(
                    new Section
                    {
                        Id = 1,
                        Code = "A",
                        DateOpened = new DateTime(1930, 1, 1),
                        GraveCount = 2000
                    }
                );

            modelBuilder.Entity<GraveOwner>().HasData(
                    new
                    {
                        Id = 1,
                        SubId = "A1",
                        GraveReferenceCode = "A001",
                        GraveRow = 1,
                        GraveDepth = 1,
                        GraveSize = "S",
                        GraveLocation = "0.35345, -6.3423",
                        GraveHeadStone = true,
                        GraveOwnerName = "John Logan",
                        GraveOwnerAddress = "4 Longwalk, Dundalk, Co. Louth",
                        Remarks = "Died before Sister buried in Ref C023",
                        SectionId = 1
                    },
                    new
                    {
                        Id = 2,
                        SubId = "A2",
                        GraveReferenceCode = "A002",
                        GraveRow = 1,
                        GraveDepth = 2,
                        GraveSize = "S",
                        GraveLocation = "0.35365, -6.3423",
                        GraveHeadStone = true,
                        GraveOwnerName = "James Coleman",
                        GraveOwnerAddress = "7 Mourne View, Dundalk, Co. Louth",
                        Remarks = "Survived by Son Jeremy Colman",
                        SectionId = 1
                    },
                    new
                    {
                        Id = 3,
                        SubId = "A3",
                        GraveReferenceCode = "A003",
                        GraveRow = 1,
                        GraveDepth = 3,
                        GraveSize = "S",
                        GraveLocation = "0.35385, -6.3423",
                        GraveHeadStone = true,
                        GraveOwnerName = "Matthew Loane",
                        GraveOwnerAddress = "12 Seacrest, Dundalk, Co. Louth",
                        Remarks = "Owner lives in Washington D.C. , USA",
                        SectionId = 1
                    },
                    new
                    {
                        Id = 4,
                        SubId = "A4",
                        GraveReferenceCode = "A004",
                        GraveRow = 1,
                        GraveDepth = 4,
                        GraveSize = "S",
                        GraveLocation = "0.35405, -6.3423",
                        GraveHeadStone = true,
                        GraveOwnerName = "Colm Lynch",
                        GraveOwnerAddress = "18 the tides, Dundalk, Co. Louth",
                        Remarks = "Purchased along with Grave Ref A034",
                        SectionId = 1
                    }

                );


            modelBuilder.Entity<Registrar>().HasData(
                    new
                    {
                        Id = 1,
                        BookPage = "bk1 pg1",
                        NumberInBook = 1,
                        FirstName = "John",
                        LastName = "Logan",
                        Sex = "M",
                        Age = 32,
                        AgeDetail = "Years",
                        Religion = "Roman Catholic",
                        Occupation = "Carpenter",
                        DeathLocation = "Longwalk, Dundalk, Co. Louth",
                        MarriageStatus = "Single",
                        DeathDate = new DateTime(1932,2,12),
                        BurialDate = new DateTime(1932,2,14),
                        Public = "",
                        Proprietary = "",
                        SectionInfo = "",
                        InternmentSignature = "Jeremy Logan",
                        AdditionalComments = "",
                        RegistrarName = "P. R. Finnegan",
                        GraveOwnerId = 1            
                    },
                    new
                    {
                        Id = 2,
                        BookPage = "bk1 pg1",
                        NumberInBook = 2,
                        FirstName = "Mark",
                        LastName = "Logan",
                        Sex = "M",
                        Age = 47,
                        AgeDetail = "Years",
                        Religion = "Roman Catholic",
                        Occupation = "Blacksmith",
                        DeathLocation = "Dundalk Hospital, Dundalk, Co. Louth",
                        MarriageStatus = "Married",
                        DeathDate = new DateTime(1932, 4, 26),
                        BurialDate = new DateTime(1932, 4, 28),
                        Public = "",
                        Proprietary = "",
                        SectionInfo = "",
                        InternmentSignature = "Jeremy Logan",
                        AdditionalComments = "",
                        RegistrarName = "P. R. Finnegan",
                        GraveOwnerId = 1
                    },
                    new
                    {
                        Id = 3,
                        BookPage = "bk1 pg1",
                        NumberInBook = 3,
                        FirstName = "Gerry",
                        LastName = "Coleman",
                        Sex = "M",
                        Age = 56,
                        AgeDetail = "Years",
                        Religion = "Roman Catholic",
                        Occupation = "Carpenter",
                        DeathLocation = "20 the Willows, Blackrock, Co. Louth",
                        MarriageStatus = "Divorced",
                        DeathDate = new DateTime(1936, 6, 6),
                        BurialDate = new DateTime(1936, 6, 8),
                        Public = "",
                        Proprietary = "",
                        SectionInfo = "",
                        InternmentSignature = "Peter Coleman",
                        AdditionalComments = "",
                        RegistrarName = "P. R. Finnegan",
                        GraveOwnerId = 2
                    },
                    new
                    {
                        Id = 4,
                        BookPage = "bk1 pg1",
                        NumberInBook = 4,
                        FirstName = "Martin",
                        LastName = "Coleman",
                        Sex = "M",
                        Age = 38,
                        AgeDetail = "Years",
                        Religion = "Roman Catholic",
                        Occupation = "Carpenter",
                        DeathLocation = "Dundalk Hospital, Dundalk, Co. Louth",
                        MarriageStatus = "Single",
                        DeathDate = new DateTime(1937, 8, 6),
                        BurialDate = new DateTime(1937, 8, 8),
                        Public = "",
                        Proprietary = "",
                        SectionInfo = "",
                        InternmentSignature = "Peter Coleman",
                        AdditionalComments = "",
                        RegistrarName = "P. R. Finnegan",
                        GraveOwnerId = 2
                    },
                    new
                    {
                        Id = 5,
                        BookPage = "bk1 pg1",
                        NumberInBook = 5,
                        FirstName = "Killian",
                        LastName = "Logan",
                        Sex = "M",
                        Age = 32,
                        AgeDetail = "Years",
                        Religion = "Roman Catholic",
                        Occupation = "Carpenter",
                        DeathLocation = "Longwalk, Dundalk, Co. Louth",
                        MarriageStatus = "Single",
                        DeathDate = new DateTime(1939, 11, 13),
                        BurialDate = new DateTime(1939, 11, 15),
                        Public = "",
                        Proprietary = "",
                        SectionInfo = "",
                        InternmentSignature = "Matthew Loane",
                        AdditionalComments = "",
                        RegistrarName = "P. R. Finnegan",
                        GraveOwnerId = 3
                    },
                    new
                    {
                        Id = 6,
                        BookPage = "bk1 pg1",
                        NumberInBook = 6,
                        FirstName = "Jeremy",
                        LastName = "Logan",
                        Sex = "M",
                        Age = 27,
                        AgeDetail = "Years",
                        Religion = "Roman Catholic",
                        Occupation = "Carpenter",
                        DeathLocation = "27 the Brook, Blackrock, Co. Louth",
                        MarriageStatus = "Single",
                        DeathDate = new DateTime(1940, 1, 26),
                        BurialDate = new DateTime(1940, 1, 28),
                        Public = "",
                        Proprietary = "",
                        SectionInfo = "",
                        InternmentSignature = "Matthew Loane",
                        AdditionalComments = "",
                        RegistrarName = "P. R. Finnegan",
                        GraveOwnerId = 3
                    },
                    new
                    {
                        Id = 7,
                        BookPage = "bk1 pg1",
                        NumberInBook = 7,
                        FirstName = "Ronan",
                        LastName = "Lynch",
                        Sex = "M",
                        Age = 28,
                        AgeDetail = "Years",
                        Religion = "Roman Catholic",
                        Occupation = "Carpenter",
                        DeathLocation = "Dundalk Hospital, Dundalk, Co. Louth",
                        MarriageStatus = "Married",
                        DeathDate = new DateTime(1941, 2, 2),
                        BurialDate = new DateTime(1941, 2, 4),
                        Public = "",
                        Proprietary = "",
                        SectionInfo = "",
                        InternmentSignature = "Lucas Lynch",
                        AdditionalComments = "",
                        RegistrarName = "P. R. Finnegan",
                        GraveOwnerId = 4
                    },
                    new
                    {
                        Id = 8,
                        BookPage = "bk1 pg1",
                        NumberInBook = 8,
                        FirstName = "Mal",
                        LastName = "Lynch",
                        Sex = "M",
                        Age = 32,
                        AgeDetail = "Years",
                        Religion = "Roman Catholic",
                        Occupation = "Carpenter",
                        DeathLocation = "20 Downside Green, Dundalk, Co. Louth",
                        MarriageStatus = "Divorced",
                        DeathDate = new DateTime(1942, 9, 27),
                        BurialDate = new DateTime(1942, 9, 29),
                        Public = "",
                        Proprietary = "",
                        SectionInfo = "",
                        InternmentSignature = "Lucas Lynch",
                        AdditionalComments = "",
                        RegistrarName = "P. R. Finnegan",
                        GraveOwnerId = 4
                    }
                );


        }

    }
}
