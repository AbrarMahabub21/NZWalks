using Microsoft.AspNetCore.Identity;

namespace Project_NZWalks.API.Repository
{
    public interface ITokenRepository
    {
        public string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
