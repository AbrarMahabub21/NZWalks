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
         
        public async Task<List<Region>> getAllAsync(string? filterOn=null, string? filterQuery=null)
        {
            var regions =  NZDb.Regions.AsQueryable();
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("name",StringComparison.OrdinalIgnoreCase))
                {
                    regions = regions.Where(x => x.Name.Contains(filterQuery));
                }
            }

            return await regions.ToListAsync();
        }

        public async Task<Region?> getByIdAsync(Guid id)
        {
            var region = await NZDb.Regions.FirstOrDefaultAsync(x => x.Id == id);
            return region;
        }

        public async Task<Region> CreateRegion(Region region)
        {
            await NZDb.Regions.AddAsync(region);
            await NZDb.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateRegion(Guid id, Region region)
        {
            var regionDM = await NZDb.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(regionDM == null)
            {
                return null;
            }
            regionDM.Code = region.Code;
            regionDM.Name = region.Name;
            regionDM.RegionImageURL = region.RegionImageURL;

            await NZDb.SaveChangesAsync();
            return regionDM;
        }

        public async Task<Region?> DeleteRegion(Guid id)
        {
            var region = await NZDb.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(region == null)
            {
                return null;
            }
            NZDb.Remove(region);
            await NZDb.SaveChangesAsync();
            return region;
        }
    }
}
