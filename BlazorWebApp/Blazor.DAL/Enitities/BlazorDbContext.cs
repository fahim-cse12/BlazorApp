using Microsoft.EntityFrameworkCore;

namespace Blazor.DAL.Enitities
{
    public class BlazorDbContext : DbContext
    {
        public BlazorDbContext()
        {
            
        }
        public BlazorDbContext(DbContextOptions<BlazorDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-92H5R24\\T7SQLSERVER;Database=BlazorDB;User Id=sa;Password=12300;Trusted_Connection=True;TrustServerCertificate=true");
        //}

        public DbSet<Window> Windows { get; set; }
        public DbSet<SubElement> SubElements { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
