using Project_NZWalks.API.Data;
using Project_NZWalks.API.Models.Domain;

namespace Project_NZWalks.API.Repository
{
    public class LocalImageUploadRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LocalImageUploadRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NZWalksDbContext NZDb)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.NZDb = NZDb;
        }

        public NZWalksDbContext NZDb { get; }

        public async Task<Image> Upload(Image image)
        {
            var LocalFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images",
               $"{image.FileName}{image.FileExtention}");

            using var stream = new FileStream(LocalFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            //https://localhost:1234/Images/chinaPic.jpg should be the address
            var PicAddress = $"{httpContextAccessor.HttpContext.Request.Scheme}://" +
                $"{httpContextAccessor.HttpContext.Request.Host}" +
                $"{httpContextAccessor.HttpContext.Request.PathBase}/Images/" +
                $"{image.FileName}{image.FileExtention}";

            image.FilePath = PicAddress;

            await NZDb.Images.AddAsync(image);
            await NZDb.SaveChangesAsync();

            return image;

        }
    }
}
