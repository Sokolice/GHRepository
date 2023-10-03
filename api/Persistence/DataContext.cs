using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; } = null!;
    }
}
