using Microsoft.EntityFrameworkCore;
using Project_NZWalks.API.Models.Domain;

namespace Project_NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    

     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //creating difficulties with having easy, medium and hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("0561b51f-cf84-4d5b-ba9a-b01b015d767d"),
                    Name= "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("d221c450-9ebf-48b2-9689-e8bb848cd706"),
                    Name= "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("56078d10-f920-4387-8ff1-36a824f0f335"),
                    Name= "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //seeding data for regions.
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("f3a10e08-4238-451d-9845-a9df6529da77"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageURL = "auckland-image.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("a38bd9dd-ff3a-4f82-a892-96497f41f0fb"),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageURL ="wellington-image.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("04ff1b15-e044-421d-9d1a-1e313095a17f"),
                    Name = "Canterbury",
                    Code = "CAN",
                    RegionImageURL = "canterbury-image.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("60b97ace-086a-4c28-b662-31922701ef10"),
                    Name = "Otago",
                    Code = "OTA",
                    RegionImageURL = "otago-image.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("29b26514-dbb1-4a38-96eb-28f08ba2fd34"),
                    Name = "Waikato",
                    Code = "WKT",
                    RegionImageURL = "waikato-image.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("7032e402-dfbc-4419-8609-0e3918f1c78d"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageURL = "bayofplenty-image.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }

        
    }
}
