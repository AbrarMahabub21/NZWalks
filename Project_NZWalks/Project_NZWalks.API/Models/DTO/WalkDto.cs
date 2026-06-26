using Project_NZWalks.API.Models.Domain;

namespace Project_NZWalks.API.Models.DTO
{
    public class WalkDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKM { get; set; }
        public string? WalkImageURL { get; set; }

        public DifficultyDto Difficulty { get; set; }
        public RegionDto Region { get; set; }
    }
}
