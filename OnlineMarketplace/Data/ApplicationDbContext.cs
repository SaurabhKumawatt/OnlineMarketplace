using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineMarketplace.Models;

namespace OnlineMarketplace.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

    // Categories table
    public DbSet<Category> Categories { get; set; }

        // Products table
        public DbSet<Product> Products { get; set; }
    }

}
