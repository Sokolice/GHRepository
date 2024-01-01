using api.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace api.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; } = null!;
        public DbSet<PlantRecord> PlantRecords { get; set; } = null!;
        public DbSet<MonthWeek> MonthWeeks{ get; set; } = null!;
        public DbSet<GardeningTask> Tasks{ get; set; } = null!;
        public DbSet<Pest> Pests { get; set; } = null!;
        public DbSet<Bed> Beds { get; set; } = null!;
        public DbSet<Cell> Cells { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //lazy loading
            modelBuilder.Entity<Plant>()
                .HasMany(a => a.CompanionPlants);

            modelBuilder.Entity<Plant>()
                .HasMany(a => a.AvoidPlants);


            modelBuilder.Entity<Plant>()
                .HasMany(a => a.SewingMonths)
                .WithMany(b=> b.SewedPlant);


            modelBuilder.Entity<Plant>()
                .HasMany(a => a.HarvestMonths)
                .WithMany(b => b.HarvestedPlant);

            modelBuilder.Entity<Plant>()
                .HasMany(a => a.PlantRecords)
                .WithOne(b => b.Plant)
                .HasForeignKey(c => c.PlantId);


            modelBuilder.Entity<GardeningTask>()
                .HasMany(a => a.MonthWeeks)
                .WithMany(b=> b.GardeningTasks);

            modelBuilder.Entity<Plant>()
                .HasMany(a => a.Pests)
                .WithMany(b => b.Plants);

            modelBuilder.Entity<Bed>()
                .HasMany(a => a.Cells);
        }
    }
}
