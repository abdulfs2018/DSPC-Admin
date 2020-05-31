using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Migrations
{
    public partial class InitialTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Code", "DateOpened", "GraveCount" },
                values: new object[] { 1, "A", new DateTime(1930, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000 });

            migrationBuilder.InsertData(
                table: "GraveOwners",
                columns: new[] { "Id", "GraveDepth", "GraveHeadStone", "GraveLocation", "GraveOwnerAddress", "GraveOwnerName", "GraveReferenceCode", "GraveRow", "GraveSize", "Remarks", "SectionId", "SubId" },
                values: new object[,]
                {
                    { 1, 1, true, "0.35345, -6.3423", "4 Longwalk, Dundalk, Co. Louth", "John Logan", "A001", 1, "S", "Died before Sister buried in Ref C023", 1, "A1" },
                    { 2, 2, true, "0.35365, -6.3423", "7 Mourne View, Dundalk, Co. Louth", "James Coleman", "A002", 1, "S", "Survived by Son Jeremy Colman", 1, "A2" },
                    { 3, 3, true, "0.35385, -6.3423", "12 Seacrest, Dundalk, Co. Louth", "Matthew Loane", "A003", 1, "S", "Owner lives in Washington D.C. , USA", 1, "A3" },
                    { 4, 4, true, "0.35405, -6.3423", "18 the tides, Dundalk, Co. Louth", "Colm Lynch", "A004", 1, "S", "Purchased along with Grave Ref A034", 1, "A4" }
                });

            migrationBuilder.InsertData(
                table: "Registrars",
                columns: new[] { "Id", "AdditionalComments", "Age", "AgeDetail", "BookPage", "BurialDate", "DeathDate", "DeathLocation", "FirstName", "GraveOwnerId", "InternmentSignature", "LastName", "MarriageStatus", "NumberInBook", "NumberInfo", "Occupation", "Proprietary", "Public", "RegistrarName", "Religion", "SectionInfo", "Sex" },
                values: new object[,]
                {
                    { 1, "", 32, "Years", "bk1 pg1", new DateTime(1932, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1932, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Longwalk, Dundalk, Co. Louth", "John", 1, "Jeremy Logan", "Logan", "Single", 1, null, "Carpenter", "", "", "P. R. Finnegan", "Roman Catholic", "", "M" },
                    { 2, "", 47, "Years", "bk1 pg1", new DateTime(1932, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1932, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dundalk Hospital, Dundalk, Co. Louth", "Mark", 1, "Jeremy Logan", "Logan", "Married", 2, null, "Blacksmith", "", "", "P. R. Finnegan", "Roman Catholic", "", "M" },
                    { 3, "", 56, "Years", "bk1 pg1", new DateTime(1936, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1936, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "20 the Willows, Blackrock, Co. Louth", "Gerry", 2, "Peter Coleman", "Coleman", "Divorced", 3, null, "Carpenter", "", "", "P. R. Finnegan", "Roman Catholic", "", "M" },
                    { 4, "", 38, "Years", "bk1 pg1", new DateTime(1937, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1937, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dundalk Hospital, Dundalk, Co. Louth", "Martin", 2, "Peter Coleman", "Coleman", "Single", 4, null, "Carpenter", "", "", "P. R. Finnegan", "Roman Catholic", "", "M" },
                    { 5, "", 32, "Years", "bk1 pg1", new DateTime(1939, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1939, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Longwalk, Dundalk, Co. Louth", "Killian", 3, "Matthew Loane", "Logan", "Single", 5, null, "Carpenter", "", "", "P. R. Finnegan", "Roman Catholic", "", "M" },
                    { 6, "", 27, "Years", "bk1 pg1", new DateTime(1940, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1940, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "27 the Brook, Blackrock, Co. Louth", "Jeremy", 3, "Matthew Loane", "Logan", "Single", 6, null, "Carpenter", "", "", "P. R. Finnegan", "Roman Catholic", "", "M" },
                    { 7, "", 28, "Years", "bk1 pg1", new DateTime(1941, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1941, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dundalk Hospital, Dundalk, Co. Louth", "Ronan", 4, "Lucas Lynch", "Lynch", "Married", 7, null, "Carpenter", "", "", "P. R. Finnegan", "Roman Catholic", "", "M" },
                    { 8, "", 32, "Years", "bk1 pg1", new DateTime(1942, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1942, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "20 Downside Green, Dundalk, Co. Louth", "Mal", 4, "Lucas Lynch", "Lynch", "Divorced", 8, null, "Carpenter", "", "", "P. R. Finnegan", "Roman Catholic", "", "M" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Registrars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Registrars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Registrars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Registrars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Registrars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Registrars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Registrars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Registrars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GraveOwners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GraveOwners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GraveOwners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GraveOwners",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
