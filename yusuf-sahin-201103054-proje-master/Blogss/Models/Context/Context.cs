using Microsoft.EntityFrameworkCore;

namespace Blogss.Models.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost; Database=SonBionlukBlog; Trusted_Connection=SSPI; Encrypt=false; TrustServerCertificate=true");

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
