using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Business.Models
{
    public class AddDbContext:IdentityDbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext>options) :base (options) { }
        public  DbSet<Team> Teams { get; set; }
        public  DbSet<AppUser> AppUsers { get; set; }

    }
}
