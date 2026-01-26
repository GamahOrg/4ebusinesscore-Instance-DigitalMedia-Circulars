using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Circulars.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migddddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentInfo");

            migrationBuilder.RenameColumn(
                name: "Approval",
                table: "Circular",
                newName: "DocumentAbout");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Circular",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "AccreditationDate",
                table: "Circular",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalId",
                table: "Circular",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentClass",
                table: "Circular",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EnforcementId",
                table: "Circular",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IssuerId",
                table: "Circular",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Approvals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enforcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enforcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issuers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgsConcerned",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgsConcernedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CircularId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgsConcerned", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgsConcerned_Circular_CircularId",
                        column: x => x.CircularId,
                        principalTable: "Circular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Circular_ApprovalId",
                table: "Circular",
                column: "ApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_Circular_EnforcementId",
                table: "Circular",
                column: "EnforcementId");

            migrationBuilder.CreateIndex(
                name: "IX_Circular_IssuerId",
                table: "Circular",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgsConcerned_CircularId",
                table: "OrgsConcerned",
                column: "CircularId");

            migrationBuilder.AddForeignKey(
                name: "FK_Circular_Approvals_ApprovalId",
                table: "Circular",
                column: "ApprovalId",
                principalTable: "Approvals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Circular_Enforcements_EnforcementId",
                table: "Circular",
                column: "EnforcementId",
                principalTable: "Enforcements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Circular_Issuers_IssuerId",
                table: "Circular",
                column: "IssuerId",
                principalTable: "Issuers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Circular_Approvals_ApprovalId",
                table: "Circular");

            migrationBuilder.DropForeignKey(
                name: "FK_Circular_Enforcements_EnforcementId",
                table: "Circular");

            migrationBuilder.DropForeignKey(
                name: "FK_Circular_Issuers_IssuerId",
                table: "Circular");

            migrationBuilder.DropTable(
                name: "Approvals");

            migrationBuilder.DropTable(
                name: "Enforcements");

            migrationBuilder.DropTable(
                name: "Issuers");

            migrationBuilder.DropTable(
                name: "OrgsConcerned");

            migrationBuilder.DropIndex(
                name: "IX_Circular_ApprovalId",
                table: "Circular");

            migrationBuilder.DropIndex(
                name: "IX_Circular_EnforcementId",
                table: "Circular");

            migrationBuilder.DropIndex(
                name: "IX_Circular_IssuerId",
                table: "Circular");

            migrationBuilder.DropColumn(
                name: "AccreditationDate",
                table: "Circular");

            migrationBuilder.DropColumn(
                name: "ApprovalId",
                table: "Circular");

            migrationBuilder.DropColumn(
                name: "DocumentClass",
                table: "Circular");

            migrationBuilder.DropColumn(
                name: "EnforcementId",
                table: "Circular");

            migrationBuilder.DropColumn(
                name: "IssuerId",
                table: "Circular");

            migrationBuilder.RenameColumn(
                name: "DocumentAbout",
                table: "Circular",
                newName: "Approval");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Circular",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "DocumentInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CircularId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Accreditation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccreditationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentAbout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    EditionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditionNumber = table.Column<int>(type: "int", nullable: false),
                    Enforcement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentInfo_Circular_CircularId",
                        column: x => x.CircularId,
                        principalTable: "Circular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentInfo_CircularId",
                table: "DocumentInfo",
                column: "CircularId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentInfo_DocumentNumber",
                table: "DocumentInfo",
                column: "DocumentNumber",
                unique: true);
        }
    }
}
