using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_NZWalks.API.Models.DTO;

namespace Project_NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        //A Post Http req
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUserRequestDto request)
        {
            ValidateUploadedFile(request);
            if (ModelState.IsValid)
            {
                //use repo to upload image
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
