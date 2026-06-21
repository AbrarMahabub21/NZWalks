using Microsoft.EntityFrameworkCore;
using Project_NZWalks.API.Data;
using Project_NZWalks.API.Models.Domain;
using Project_NZWalks.API.Models.DTO;

namespace Project_NZWalks.API.Repository
{
    public class SQLRegionRepository: IRegionRepository
    {
        private readonly NZWalksDbContext NZDb;

        public SQLRegionRepository(NZWalksDbContext NZDb)
        {
            this.NZDb = NZDb;
        }
         
        public async Task<List<Region>> getAllAsync()
        {
            var regions =  await NZDb.Regions.ToListAsync();

            return regions;
        }

        public async Task<Region> getByIdAsync(Guid id)
        {
            var region = await NZDb.Regions.FirstOrDefaultAsync(x => x.Id == id);
            return region;
        }

        public async Task<Region> CreateRegion(AddRegionRequestDto addRegion)
        {
            var region = new Region
            {
                Code = addRegion.Code,
                Name = addRegion.Name,
                RegionImageURL = addRegion.RegionImageURL
            };

            await NZDb.Regions.AddAsync(region);
            await NZDb.SaveChangesAsync();
            return region;
        }

        public async Task<Region> UpdateRegion(Guid id, UpdateRegionRequestDto updateRegion)
        {
            var region = await NZDb.Regions.FirstOrDefaultAsync(x => x.Id == id);

            region.Code = updateRegion.Code;
            region.Name = updateRegion.Name;
            region.RegionImageURL = updateRegion.RegionImageURL;

            await NZDb.SaveChangesAsync();
            return region;
        }
    }
}
