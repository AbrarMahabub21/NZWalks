using Project_NZWalks.API.Models.Domain;
using Project_NZWalks.API.Models.DTO;

namespace Project_NZWalks.API.Repository
{
    public interface IRegionRepository
    {
      Task<List<Region>> getAllAsync();
      Task<Region> getByIdAsync(Guid id);
      Task<Region> CreateRegion(AddRegionRequestDto addRegion);
      Task<Region> UpdateRegion(Guid id, UpdateRegionRequestDto updateRegion);
    }
}
