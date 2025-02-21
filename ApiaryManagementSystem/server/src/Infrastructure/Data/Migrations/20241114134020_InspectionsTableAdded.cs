using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiaryManagementSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InspectionsTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ColonyStrength = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FramesWithCappedBrood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FramesWithUncappedBrood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FramesWithHoney = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FramesWithPollen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FramesWithFreeSpace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BroodPattern = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BeeBehaviour = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SwarmingState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsQueenPresent = table.Column<bool>(type: "bit", nullable: false),
                    AreEggsPresent = table.Column<bool>(type: "bit", nullable: false),
                    AreQueenCellsPresent = table.Column<bool>(type: "bit", nullable: false),
                    AreDroneCellsPresent = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspections_Hives_HiveId",
                        column: x => x.HiveId,
                        principalTable: "Hives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_HiveId",
                table: "Inspections",
                column: "HiveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspections");
        }
    }
}
