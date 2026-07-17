using Project_NZWalks.API.Models.Domain;

namespace Project_NZWalks.API.Repository
{
    public interface IImageRepository
    {
        public Task<Image> Upload(Image image);
    }
}
