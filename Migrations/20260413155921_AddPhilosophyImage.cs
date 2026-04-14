using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BFC.Migrations
{
    /// <inheritdoc />
    public partial class AddPhilosophyImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhilosophyImageUrl",
                table: "SiteSettings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhilosophyImageUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhilosophyImageUrl",
                table: "SiteSettings");
        }
    }
}
