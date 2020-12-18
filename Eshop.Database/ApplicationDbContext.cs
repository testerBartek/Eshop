using Eshop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
