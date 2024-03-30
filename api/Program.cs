using Microsoft.EntityFrameworkCore;
using API.Persistence;
using API.Services;
using API.Extensions;
using Microsoft.AspNetCore.Identity;
using API.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using API.Interfaces;
using API.Security;
using System.IdentityModel.Tokens.Jwt;

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

            builder.Services.AddControllers(opt =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(opt =>
            {
                opt.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("MyGarden"));
            });

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    //policy.AllowAnyHeader().WithOrigins("http://localhost:5180");
                });
            });

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<IUserAccessor, UserAccessor>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddIdentityServices(builder.Configuration);
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                context.Database.Migrate();

                //await SeedUser.SeedData(context, userManager);
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