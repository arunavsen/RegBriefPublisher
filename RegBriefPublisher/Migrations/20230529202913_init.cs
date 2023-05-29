using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegBriefPublisher.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Briefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Briefs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BriefCountryMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BriefId = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BriefCountryMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BriefCountryMaps_Briefs_BriefId",
                        column: x => x.BriefId,
                        principalTable: "Briefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TAXBriefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortStory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongStory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BriefMapId = table.Column<int>(type: "int", nullable: false),
                    BriefCountryMapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAXBriefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TAXBriefs_BriefCountryMaps_BriefCountryMapId",
                        column: x => x.BriefCountryMapId,
                        principalTable: "BriefCountryMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TPABriefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortStory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongStory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BriefMapId = table.Column<int>(type: "int", nullable: false),
                    BriefCountryMapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPABriefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TPABriefs_BriefCountryMaps_BriefCountryMapId",
                        column: x => x.BriefCountryMapId,
                        principalTable: "BriefCountryMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WTABriefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortStory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongStory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BriefMapId = table.Column<int>(type: "int", nullable: false),
                    BriefCountryMapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WTABriefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WTABriefs_BriefCountryMaps_BriefCountryMapId",
                        column: x => x.BriefCountryMapId,
                        principalTable: "BriefCountryMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BriefCountryMaps_BriefId",
                table: "BriefCountryMaps",
                column: "BriefId");

            migrationBuilder.CreateIndex(
                name: "IX_TAXBriefs_BriefCountryMapId",
                table: "TAXBriefs",
                column: "BriefCountryMapId");

            migrationBuilder.CreateIndex(
                name: "IX_TPABriefs_BriefCountryMapId",
                table: "TPABriefs",
                column: "BriefCountryMapId");

            migrationBuilder.CreateIndex(
                name: "IX_WTABriefs_BriefCountryMapId",
                table: "WTABriefs",
                column: "BriefCountryMapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAXBriefs");

            migrationBuilder.DropTable(
                name: "TPABriefs");

            migrationBuilder.DropTable(
                name: "WTABriefs");

            migrationBuilder.DropTable(
                name: "BriefCountryMaps");

            migrationBuilder.DropTable(
                name: "Briefs");
        }
    }
}
