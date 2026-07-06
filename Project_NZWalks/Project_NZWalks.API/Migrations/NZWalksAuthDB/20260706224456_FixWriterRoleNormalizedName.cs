using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_NZWalks.API.Migrations.NZWalksAuthDB
{
    /// <inheritdoc />
    public partial class FixWriterRoleNormalizedName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47c9d899-7a2c-4db6-b98c-e314db7adc82",
                column: "NormalizedName",
                value: "WRITERROLE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47c9d899-7a2c-4db6-b98c-e314db7adc82",
                column: "NormalizedName",
                value: "WRITEROLE");
        }
    }
}
