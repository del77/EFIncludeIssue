using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NpgsqlIncludeIssue.Migrations
{
    /// <inheritdoc />
    public partial class AddDirectNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DirectNav1Id",
                table: "BaseMyClasses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DirectNav2Id",
                table: "BaseMyClasses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DirectNav1",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectNav1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectNav2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectNav2", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseMyClasses_DirectNav1Id",
                table: "BaseMyClasses",
                column: "DirectNav1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BaseMyClasses_DirectNav2Id",
                table: "BaseMyClasses",
                column: "DirectNav2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseMyClasses_DirectNav1_DirectNav1Id",
                table: "BaseMyClasses",
                column: "DirectNav1Id",
                principalTable: "DirectNav1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseMyClasses_DirectNav2_DirectNav2Id",
                table: "BaseMyClasses",
                column: "DirectNav2Id",
                principalTable: "DirectNav2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseMyClasses_DirectNav1_DirectNav1Id",
                table: "BaseMyClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseMyClasses_DirectNav2_DirectNav2Id",
                table: "BaseMyClasses");

            migrationBuilder.DropTable(
                name: "DirectNav1");

            migrationBuilder.DropTable(
                name: "DirectNav2");

            migrationBuilder.DropIndex(
                name: "IX_BaseMyClasses_DirectNav1Id",
                table: "BaseMyClasses");

            migrationBuilder.DropIndex(
                name: "IX_BaseMyClasses_DirectNav2Id",
                table: "BaseMyClasses");

            migrationBuilder.DropColumn(
                name: "DirectNav1Id",
                table: "BaseMyClasses");

            migrationBuilder.DropColumn(
                name: "DirectNav2Id",
                table: "BaseMyClasses");
        }
    }
}
