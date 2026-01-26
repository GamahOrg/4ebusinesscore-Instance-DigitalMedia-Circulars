using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Circulars.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DocumentAboutEn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentAboutEn",
                table: "Circular",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentAboutEn",
                table: "Circular");
        }
    }
}
