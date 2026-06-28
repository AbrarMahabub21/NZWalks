using System.ComponentModel.DataAnnotations;

namespace Project_NZWalks.API.Models.DTO
{
    public class AddWalkRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Give a correct name,sir.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000,ErrorMessage="You gotta put some description, MoFo!")]
        public string Description { get; set; }
        [Required]
        public double LengthInKM { get; set; }
        public string? WalkImageURL { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
