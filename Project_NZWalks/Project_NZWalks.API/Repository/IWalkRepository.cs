using Project_NZWalks.API.Models.Domain;

namespace Project_NZWalks.API.Repository
{
    public interface IWalkRepository
    {
        public Task<Walk> CreateAsync(Walk walk);
        public Task<List<Walk>> GetWalkAsync();
    }
}
