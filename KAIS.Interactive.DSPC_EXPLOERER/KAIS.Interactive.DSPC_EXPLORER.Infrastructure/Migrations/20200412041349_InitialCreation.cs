using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    DateOpened = table.Column<DateTime>(nullable: false),
                    GraveCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ApprovalPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GraveOwners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubId = table.Column<string>(nullable: true),
                    JkIndex = table.Column<string>(nullable: true),
                    GraveReferenceCode = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: false),
                    GraveRow = table.Column<int>(nullable: false),
                    GraveDepth = table.Column<int>(nullable: false),
                    GraveSize = table.Column<string>(nullable: true),
                    GraveLocation = table.Column<string>(nullable: true),
                    GraveHeadStone = table.Column<bool>(nullable: false),
                    GraveOwnerName = table.Column<string>(nullable: true),
                    GraveOwnerAddress = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraveOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraveOwners_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookPage = table.Column<string>(nullable: true),
                    NumberInBook = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    AgeDetail = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    DeathLocation = table.Column<string>(nullable: true),
                    MarriageStatus = table.Column<string>(nullable: true),
                    DeathDate = table.Column<DateTime>(nullable: false),
                    BurialDate = table.Column<DateTime>(nullable: false),
                    GraveReferenceCode = table.Column<string>(nullable: true),
                    Public = table.Column<string>(nullable: true),
                    Proprietary = table.Column<string>(nullable: true),
                    SectionInfo = table.Column<string>(nullable: true),
                    NumberInfo = table.Column<string>(nullable: true),
                    InternmentSignature = table.Column<string>(nullable: true),
                    AdditionalComments = table.Column<string>(nullable: true),
                    RegistrarName = table.Column<string>(nullable: true),
                    GraveOwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrars_GraveOwners_GraveOwnerId",
                        column: x => x.GraveOwnerId,
                        principalTable: "GraveOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GraveOwners_SectionId",
                table: "GraveOwners",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrars_GraveOwnerId",
                table: "Registrars",
                column: "GraveOwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GraveOwners");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
