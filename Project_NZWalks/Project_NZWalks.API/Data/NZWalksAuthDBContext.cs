using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Project_NZWalks.API.Data

{
    public class NZWalksAuthDBContext : IdentityDbContext
    {
        public NZWalksAuthDBContext(DbContextOptions<NZWalksAuthDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 2 roles
            var ReaderRoleId = "8d380b49-28e0-461d-9a2d-a1da2346a22b";
            var WriterRoleId = "47c9d899-7a2c-4db6-b98c-e314db7adc82";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = ReaderRoleId,
                    ConcurrencyStamp = ReaderRoleId,
                    Name = "ReaderRole",
                    NormalizedName = "ReaderRole".ToUpper()
                },

                new IdentityRole
                {
                    Id = WriterRoleId,
                    ConcurrencyStamp =WriterRoleId,
                    Name = "WriterRole",
                    NormalizedName = "WriterRole".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);


        }
    }
}
