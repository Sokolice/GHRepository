using Microsoft.EntityFrameworkCore;
using API.Persistence;
using API.Services;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IPestsService, PestsService>();
            builder.Services.AddTransient<ICellsService, CellsService>();
            builder.Services.AddTransient<IBedsService, BedsService>();
            builder.Services.AddTransient<IGardeningTasksService, GardeningTasksService>();
            builder.Services.AddTransient<IMonthWeeksService, MonthWeeksService>();
            builder.Services.AddTransient<IPlantRecordsService, PlantRecordsService>();
            builder.Services.AddTransient<IPlantsService, PlantsService>();
            builder.Services.AddTransient<IHarvestService, HarvestService>();
            builder.Services.AddTransient<IStatsService, StatsService>();

            builder.Services.AddControllers();
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    //policy.AllowAnyHeader().WithOrigins("http://localhost:5180");
                });
            });
            builder.Services.AddDbContext<DataContext>(opt =>
            {
                opt.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("MyGarden"));
            });
           
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("CorsPolicy");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                context.Database.Migrate();

               //await SeedPlants.SeedData(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");
            }

            app.Run();
        }
    }
}