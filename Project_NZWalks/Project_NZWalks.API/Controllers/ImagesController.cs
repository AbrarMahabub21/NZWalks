using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_NZWalks.API.Models.Domain;
using Project_NZWalks.API.Models.DTO;
using Project_NZWalks.API.Repository;

namespace Project_NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        //A Post Http req
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUserRequestDto request)
        {
            ValidateUploadedFile(request);
            if (ModelState.IsValid)
            {

                var imageDM = new Image
                {
                    File = request.File,
                    FileName = request.FileName,
                    FileExtention = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileDescription = request.FileDescription,
                };
                //use repo to upload image
                await imageRepository.Upload(imageDM);

                return Ok();
            }

            return BadRequest("Image Upload failed!");
        }

        private void ValidateUploadedFile(ImageUserRequestDto request)
        {
            var AllowedExtension = new string[] { ".jpg", ".png",".jpeg"};
            if (!AllowedExtension.Contains(Path.GetExtension(request.File.FileName))){ 
                ModelState.AddModelError("file", "Unsupported file extension!");
            }

            if(request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "The file is exceeded the length limitation");
            }


        }
    }
}
