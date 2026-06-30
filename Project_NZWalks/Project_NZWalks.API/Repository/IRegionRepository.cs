using Project_NZWalks.API.Models.Domain;
using Project_NZWalks.API.Models.DTO;

namespace Project_NZWalks.API.Repository
{
    public interface IRegionRepository
    {
      Task<List<Region>> getAllAsync(string? filterOn=null, string? filterQuery=null);
      Task<Region?> getByIdAsync(Guid id);
      Task<Region> CreateRegion(Region region);
      Task<Region?> UpdateRegion(Guid id, Region region);
      Task<Region?> DeleteRegion(Guid id);
    }
}
