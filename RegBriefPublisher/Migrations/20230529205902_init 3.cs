using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegBriefPublisher.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAXBriefs_BriefCountryMaps_BriefCountryMapId",
                table: "TAXBriefs");

            migrationBuilder.AlterColumn<int>(
                name: "BriefCountryMapId",
                table: "TAXBriefs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TAXBriefs_BriefCountryMaps_BriefCountryMapId",
                table: "TAXBriefs",
                column: "BriefCountryMapId",
                principalTable: "BriefCountryMaps",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAXBriefs_BriefCountryMaps_BriefCountryMapId",
                table: "TAXBriefs");

            migrationBuilder.AlterColumn<int>(
                name: "BriefCountryMapId",
                table: "TAXBriefs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TAXBriefs_BriefCountryMaps_BriefCountryMapId",
                table: "TAXBriefs",
                column: "BriefCountryMapId",
                principalTable: "BriefCountryMaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
