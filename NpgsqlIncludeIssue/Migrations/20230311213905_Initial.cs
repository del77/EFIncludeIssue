using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NpgsqlIncludeIssue.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nav1",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nav1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nav2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nav2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseMyClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BaseEntityProperty = table.Column<bool>(type: "boolean", nullable: false),
                    Information_Boolean = table.Column<bool>(type: "boolean", nullable: false),
                    Information_Nav1Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Information_Nav2Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseMyClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseMyClasses_Nav1_Information_Nav1Id",
                        column: x => x.Information_Nav1Id,
                        principalTable: "Nav1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseMyClasses_Nav2_Information_Nav2Id",
                        column: x => x.Information_Nav2Id,
                        principalTable: "Nav2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseMyClasses_Information_Nav1Id",
                table: "BaseMyClasses",
                column: "Information_Nav1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BaseMyClasses_Information_Nav2Id",
                table: "BaseMyClasses",
                column: "Information_Nav2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseMyClasses");

            migrationBuilder.DropTable(
                name: "Nav1");

            migrationBuilder.DropTable(
                name: "Nav2");
        }
    }
}
