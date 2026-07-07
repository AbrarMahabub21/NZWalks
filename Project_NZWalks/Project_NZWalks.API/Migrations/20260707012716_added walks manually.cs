using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class addedwalksmanually : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKM", "Name", "RegionId", "WalkImageURL" },
                values: new object[,]
                {
                    { new Guid("04ab77f0-e145-4fbf-b641-989df24e5573"), "This coastal walk takes you along the unique Boulder Bank, a long narrow bar of rocks that extends into Tasman Bay.", new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), 8.0, "Boulder Bank Walkway", new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg" },
                    { new Guid("09601132-f92d-457c-b47e-da90e117b33c"), "Explore the beautiful Botanic Garden of Wellington on this leisurely walk, with a wide variety of plants and flowers to admire.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 2.0, "Botanic Garden Walk", new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg" },
                    { new Guid("135a6e58-969f-47e1-8278-d7fbf2b3bd69"), "Explore the lush and peaceful White Pine Bush on this easy walk, with a variety of native flora and fauna to discover.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 2.0, "The White Pine Bush Track", new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg" },
                    { new Guid("1cc5f2bc-ff4b-47c0-a475-1add56c6497b"), "This walk takes you along the wild and rugged coastline of Makara Beach, with breathtaking views of the Tasman Sea.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 8.1999999999999993, "Makara Beach Walkway", new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg" },
                    { new Guid("1ea0b064-2d44-4324-91ee-6dd86c91b713"), "Explore the picturesque Maitai Valley on this easy walk, with a tranquil river and native bush to enjoy.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 5.0, "Maitai Valley Walk", new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg" },
                    { new Guid("24ef9346-17e2-467e-bfc0-d062a9042bf1"), "This walk takes you to the top of Bluff Hill, with panoramic views of Bluff and the surrounding coastline.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 6.0, "The Bluff Hill Walkway", new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "https://images.pexels.com/photos/2226900/pexels-photo-2226900.jpeg" },
                    { new Guid("2d9d6604-bef9-4b0a-805d-630240a29595"), "Enjoy panoramic views of Tauranga and Mount Maunganui on this walk through the Papamoa Hills, with a mix of bush and open farmland.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 5.0, "The Papamoa Hills Regional Park Walk", new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg" },
                    { new Guid("30d654c7-89ac-4704-8333-5065b740150b"), "This walk takes you to the summit of Mount Eden, the highest natural point in Auckland, with panoramic views of the city.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 2.0, "Mount Eden Summit Walk", new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg" },
                    { new Guid("327aa9f7-26f7-4ddb-8047-97464374bb63"), "This scenic walk takes you around the top of Mount Victoria, offering stunning views of Wellington and its harbor.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 3.5, "Mount Victoria Loop", new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg" },
                    { new Guid("43132402-3d5e-467a-8cde-351c5c7c5dde"), "This walk takes you to the geographical centre of New Zealand, with stunning views of Nelson and its surroundings.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 1.0, "Centre of New Zealand Walkway", new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg" },
                    { new Guid("a7796ab6-5426-46af-b755-65d9b9e12978"), "Experience the stunning scenery of the southern Fiordland and the coast on this challenging multi-day walk.", new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), 60.0, "The Hump Ridge Track", new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "https://images.pexels.com/photos/2226900/pexels-photo-2226900.jpeg" },
                    { new Guid("b5aa2791-3616-4db6-ab33-c54d03d17f62"), "This walk takes you to the summit of Mount Maunganui, with stunning views of the ocean and surrounding landscape.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 3.0, "Mount Maunganui Summit Walk", new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg" },
                    { new Guid("bdf28703-6d0e-4822-ad8b-e2923f4e95a2"), "This coastal walk takes you along the beautiful beaches of Takapuna and Milford, with stunning views of Rangitoto Island.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 5.0, "Takapuna to Milford Coastal Walk", new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg" },
                    { new Guid("f2b56c63-eb99-475a-881c-278f3da03e3d"), "One of New Zealand most famous walks, the Kepler Track offers stunning alpine vistas and takes you through a range of landscapes.", new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), 32.0, "The Kepler Track", new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "https://images.pexels.com/photos/2226900/pexels-photo-2226900.jpeg" },
                    { new Guid("f7578324-f025-4c86-83a9-37a7f3d8fe81"), "Explore the beautiful Cornwall Park on this leisurely walk, with a wide variety of trees, gardens, and animals to admire.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 3.0, "Cornwall Park Walk", new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("04ab77f0-e145-4fbf-b641-989df24e5573"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("09601132-f92d-457c-b47e-da90e117b33c"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("135a6e58-969f-47e1-8278-d7fbf2b3bd69"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("1cc5f2bc-ff4b-47c0-a475-1add56c6497b"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("1ea0b064-2d44-4324-91ee-6dd86c91b713"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("24ef9346-17e2-467e-bfc0-d062a9042bf1"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("2d9d6604-bef9-4b0a-805d-630240a29595"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("30d654c7-89ac-4704-8333-5065b740150b"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("327aa9f7-26f7-4ddb-8047-97464374bb63"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("43132402-3d5e-467a-8cde-351c5c7c5dde"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("a7796ab6-5426-46af-b755-65d9b9e12978"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b5aa2791-3616-4db6-ab33-c54d03d17f62"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("bdf28703-6d0e-4822-ad8b-e2923f4e95a2"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("f2b56c63-eb99-475a-881c-278f3da03e3d"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("f7578324-f025-4c86-83a9-37a7f3d8fe81"));
        }
    }
}
