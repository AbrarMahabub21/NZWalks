using Project_NZWalks.API.Models.Domain;

namespace Project_NZWalks.API.Repository
{
    public interface IWalkRepository
    {
        public Task<Walk> CreateAsync(Walk walk);
        public Task<List<Walk>> GetWalkAsync();
        public Task<Walk?> WalkByIDAsync(Guid id);
        public Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);
        public Task<Walk?> DeleteWalkAsync(Guid id);
    }
}
