using Microsoft.EntityFrameworkCore;
using Project_NZWalks.API.Data;
using Project_NZWalks.API.Models.Domain;
using Project_NZWalks.API.Models.DTO;

namespace Project_NZWalks.API.Repository
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext NZDb;
        public SQLWalkRepository(NZWalksDbContext NZDb)
        {
            this.NZDb = NZDb;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await NZDb.Walks.AddAsync(walk);
            await NZDb.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> DeleteWalkAsync(Guid id)
        {
            var walk = await NZDb.Walks.FirstOrDefaultAsync(x=> x.Id == id);
            if(walk == null)
            {
                return null;
            }
            NZDb.Remove(walk);
            await NZDb.SaveChangesAsync();

            return walk;
        }

        public async Task<List<Walk>> GetWalkAsync(string?filterOn=null, string?filterQuery=null, string?sortBy=null, bool isAscending= true)
        {
            var allWalks = NZDb.Walks.Include("Difficulty").Include("Region").AsQueryable();
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {

                //Filtering
                if (filterOn.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    allWalks = allWalks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    allWalks = (isAscending) ? allWalks.OrderBy(x => x.Name) : allWalks.OrderByDescending(x => x.Name);
                }

                else if (sortBy.Equals("length", StringComparison.OrdinalIgnoreCase))
                {
                    allWalks = (isAscending) ? allWalks.OrderBy(x => x.LengthInKM) : allWalks.OrderByDescending(x => x.LengthInKM);
                }
            }

            return await allWalks.ToListAsync();
        }

        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var walkDM = await NZDb.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
            if(walkDM == null)
            {
                return null;
            }
            walkDM.Name = walk.Name;
            walkDM.Description = walk.Description;
            walkDM.LengthInKM = walk.LengthInKM;
            walkDM.WalkImageURL = walk.WalkImageURL;
            walkDM.DifficultyId = walk.DifficultyId;
            walkDM.RegionId = walk.RegionId;

            await NZDb.SaveChangesAsync();

            return walkDM;

        }

        public async Task<Walk?> WalkByIDAsync(Guid id)
        {

            var walk = await NZDb.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null)
            {
                return null;
            }

            return walk;
        }

        
    }
}
