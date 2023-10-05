using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegoCase.Database.Migrations
{
    /// <inheritdoc />
    public partial class TraceUserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "EquipmentTraces",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "EquipmentTraces");
        }
    }
}
