using Microsoft.EntityFrameworkCore;
using Project_NZWalks.API.Data;
using Project_NZWalks.API.Models.Domain;

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

        public async Task<List<Walk>> GetWalkAsync()
        {
            var allWalks = await NZDb.Walks.ToListAsync();

            return allWalks;
        }
    }
}
