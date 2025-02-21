using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiaryManagementSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class BeeQueenTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeeQueens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ColorMark = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsAlive = table.Column<bool>(type: "bit", nullable: false),
                    HiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeeQueens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeeQueens_Hives_HiveId",
                        column: x => x.HiveId,
                        principalTable: "Hives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeeQueens_HiveId",
                table: "BeeQueens",
                column: "HiveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeeQueens");
        }
    }
}
