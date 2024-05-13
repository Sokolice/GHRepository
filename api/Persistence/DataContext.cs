using API.Domain;
using API.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace API.Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
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

        public DbSet<Stats> Stats { get; set; } = null!;
        public DbSet<Harvest> Harvests { get; set; } = null!;
        public DbSet<PlantType> PlantTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlantType>()
                .HasMany(a => a.CompanionPlantTypes)
                .WithMany(a => a.CompanionPlantTypes2)
                .UsingEntity(join => join.ToTable("PlantTypeCompanionPlant"));

            modelBuilder.Entity<PlantType>()
                .HasMany(a => a.AvoidPlantTypes)
                .WithMany(a => a.AvoidPlantTypes2)
                .UsingEntity(join => join.ToTable("PlantTypeAvoidPlant"));

            modelBuilder.Entity<Plant>()
                .HasMany(a => a.SewingMonths)
                .WithMany(b=> b.SewedPlants);

            modelBuilder.Entity<Plant>()
                .HasMany(a => a.HarvestMonths)
                .WithMany(b => b.HarvestedPlants);


            modelBuilder.Entity<PlantType>()
                .HasMany(a => a.SewingMonths)
                .WithMany(b => b.SewedPlantTypes);

            modelBuilder.Entity<PlantType>()
                .HasMany(a => a.HarvestMonths)
                .WithMany(b => b.HarvestedPlantTypes);

            modelBuilder.Entity<Plant>()
                .HasMany(a => a.PlantRecords)
                .WithOne(b => b.Plant)
                .HasForeignKey(c => c.PlantId);

            modelBuilder.Entity<GardeningTask>()
                .HasMany(a => a.MonthWeeks)
                .WithMany(b=> b.GardeningTasks);

            modelBuilder.Entity<PlantType>()
                .HasMany(a => a.Pests)
                .WithMany(b => b.Plants);

            modelBuilder.Entity<Bed>()
                .HasMany(a => a.Cells);

            modelBuilder.Entity<PlantType>()
               .HasMany(a => a.Plants)
               .WithOne(b => b.PlantType)
               .HasForeignKey(c => c.PlantTypeId);

            modelBuilder.Entity<Plant>()
                .HasMany(a => a.Users)
                .WithMany(b => b.Plants)
                .UsingEntity(c => c.ToTable("PlantUser"));
        }
    }
}
