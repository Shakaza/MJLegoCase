using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegoCase.Database.Migrations
{
    /// <inheritdoc />
    public partial class TraceSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentTraces",
                columns: table => new
                {
                    EquipmentTraceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EquipmentItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PreviousState = table.Column<int>(type: "INTEGER", nullable: false),
                    NewState = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTraces", x => x.EquipmentTraceId);
                    table.ForeignKey(
                        name: "FK_EquipmentTraces_EquipmentItems_EquipmentItemId",
                        column: x => x.EquipmentItemId,
                        principalTable: "EquipmentItems",
                        principalColumn: "EquipmentItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTraces_EquipmentItemId",
                table: "EquipmentTraces",
                column: "EquipmentItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentTraces");
        }
    }
}
