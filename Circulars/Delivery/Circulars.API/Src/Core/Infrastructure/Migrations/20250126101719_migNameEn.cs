using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Circulars.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migNameEn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Circular",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Circular");
        }
    }
}
