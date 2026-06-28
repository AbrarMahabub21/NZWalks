using System.ComponentModel.DataAnnotations;

namespace Project_NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage ="Code has to have a min length of 3")]
        [MaxLength(3, ErrorMessage = "Code has to have a max length of 3")]
        public string Code { get; set; }
        [Required]
        [MaxLength(3,ErrorMessage = "Put a freaking correct name, you idiot")]
        public string Name { get; set; }
        public string? RegionImageURL { get; set; }
    }
}
