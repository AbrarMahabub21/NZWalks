using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataofRegionandDifficulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0561b51f-cf84-4d5b-ba9a-b01b015d767d"), "Easy" },
                    { new Guid("56078d10-f920-4387-8ff1-36a824f0f335"), "Hard" },
                    { new Guid("d221c450-9ebf-48b2-9689-e8bb848cd706"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { new Guid("04ff1b15-e044-421d-9d1a-1e313095a17f"), "CAN", "Canterbury", "canterbury-image.jpg" },
                    { new Guid("29b26514-dbb1-4a38-96eb-28f08ba2fd34"), "WKT", "Waikato", "waikato-image.jpg" },
                    { new Guid("60b97ace-086a-4c28-b662-31922701ef10"), "OTA", "Otago", "otago-image.jpg" },
                    { new Guid("7032e402-dfbc-4419-8609-0e3918f1c78d"), "BOP", "Bay of Plenty", "bayofplenty-image.jpg" },
                    { new Guid("a38bd9dd-ff3a-4f82-a892-96497f41f0fb"), "WLG", "Wellington", "wellington-image.jpg" },
                    { new Guid("f3a10e08-4238-451d-9845-a9df6529da77"), "AKL", "Auckland", "auckland-image.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0561b51f-cf84-4d5b-ba9a-b01b015d767d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("56078d10-f920-4387-8ff1-36a824f0f335"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d221c450-9ebf-48b2-9689-e8bb848cd706"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("04ff1b15-e044-421d-9d1a-1e313095a17f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("29b26514-dbb1-4a38-96eb-28f08ba2fd34"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("60b97ace-086a-4c28-b662-31922701ef10"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7032e402-dfbc-4419-8609-0e3918f1c78d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a38bd9dd-ff3a-4f82-a892-96497f41f0fb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f3a10e08-4238-451d-9845-a9df6529da77"));
        }
    }
}
