using api.Model;

namespace api.Persistence
{
    public class SeedGardeningTasks
    {
        public static async Task SeedData(DataContext context)
        {

            var monthWeekMap = context.MonthWeeks.ToDictionary(x => (x.Month, x.Week));

            var tasks = new List<GardeningTask>
            {
                /*new GardeningTask
                {
                    Name = "Sklízet růžičkovou kapustu",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.January, 1)],
                        monthWeekMap[(Month.January, 2)],
                    }
                },
                 new GardeningTask
                {
                    Name = "Nasypat dřevený popel do kompustu nebo záhonu",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.January, 1)],
                        monthWeekMap[(Month.January, 2)],
                    }
                },
                 new GardeningTask
                {
                    Name = "Protřídit semínka",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.January, 3)],
                        monthWeekMap[(Month.January, 4)],
                    }
                },
                 new GardeningTask
                {
                    Name = "Dokoupit semínka",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.January, 3)],
                        monthWeekMap[(Month.January, 4)],
                    }
                }*/
                new GardeningTask
                {
                    Name = "Sklidit veškerou zimní zeleninu ze záhonů",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.February, 1)]
                    } 
                },
                new GardeningTask
                {
                    Name = "Pokud nemrzne, přerýt a zahnojit záhony",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.February, 2)]
                    }
                },
                new GardeningTask
                {
                    Name = "Nákup květináčů a truhlíků",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.February, 2)]
                    }
                }

            };

            await context.AddRangeAsync(tasks);
            await context.SaveChangesAsync();
        }
    }
}
