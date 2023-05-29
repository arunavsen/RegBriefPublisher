using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegBriefPublisher.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BriefMapId",
                table: "WTABriefs");

            migrationBuilder.DropColumn(
                name: "BriefMapId",
                table: "TPABriefs");

            migrationBuilder.DropColumn(
                name: "BriefMapId",
                table: "TAXBriefs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BriefMapId",
                table: "WTABriefs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BriefMapId",
                table: "TPABriefs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BriefMapId",
                table: "TAXBriefs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
