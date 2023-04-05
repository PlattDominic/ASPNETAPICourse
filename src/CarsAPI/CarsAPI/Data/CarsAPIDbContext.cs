using CarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI.Data
{
    public class CarsAPIDbContext : DbContext
    {
        public CarsAPIDbContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<Car> Cars { get; set; }
    }
}
