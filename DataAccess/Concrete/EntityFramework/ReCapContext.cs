using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=ReCapProject;Trusted_Connection=true");
        }
        public DbSet<Color> Colors {get; set;}
        public DbSet<Brand> Brands {get; set;}
        public DbSet<Car> Cars {get; set;}
    }
}