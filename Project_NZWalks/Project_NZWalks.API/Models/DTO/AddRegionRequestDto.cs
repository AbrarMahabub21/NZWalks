using System.ComponentModel.DataAnnotations;

namespace Project_NZWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage ="Code has to have a minimum length of 3")]
        [MaxLength(3, ErrorMessage = "Code has to have a maximum length of 3")]
        public string Code { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage ="Give correct name, you dumbass!")]
        public string Name { get; set; }
        public string? RegionImageURL { get; set; }
    }
}
