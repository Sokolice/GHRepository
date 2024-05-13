using API.Domain;

namespace API.Persistence
{
    public class SeedGardeningTasks
    {
        public static async Task SeedData(DataContext context)
        {

            var monthWeekMap = context.MonthWeeks.ToDictionary(x => (x.Month, x.Week));


            
                

            var users = context.Users.ToList();

            foreach (var user in users)
            {
                var tasks = new List<GardeningTask>
            {
                new GardeningTask
                {
                    Name = "Sklízet růžičkovou kapustu",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.January, 1)]
                    },
                    User = user,
                },
                 new GardeningTask
                {
                    Name = "Sklízet růžičkovou kapustu",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.January, 2)]
                    },
                    User = user,
                },
                 new GardeningTask
                {
                    Name = "Nasypat dřevený popel do kompustu nebo záhonu",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.January, 1)]
                    },
                    User = user,
                }
                 ,
                 new GardeningTask
                {
                    Name = "Nasypat dřevený popel do kompustu nebo záhonu",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.January, 2)],
                    },
                    User = user,
                },
                 new GardeningTask
                {
                    Name = "Protřídit semínka",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.January, 3)]
                    },
                    User = user,
                },
                 new GardeningTask
                {
                    Name = "Protřídit semínka",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.January, 4)],
                    },
                    User = user,
                },
                 new GardeningTask
                {
                    Name = "Dokoupit semínka",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.January, 3)]
                    },
                    User = user,
                },
                 new GardeningTask
                {
                    Name = "Dokoupit semínka",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.January, 4)],
                    },
                    User = user,
                },
                new GardeningTask
                {
                    Name = "Sklidit veškerou zimní zeleninu ze záhonů",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.February, 1)]
                    },
                    User = user,
                },
                new GardeningTask
                {
                    Name = "Pokud nemrzne, přerýt a zahnojit záhony",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.February, 2)]
                    },
                    User = user,
                },
                new GardeningTask
                {
                    Name = "Nákup květináčů a truhlíků",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.February, 2)]
                    },
                    User = user,
                },
                new GardeningTask
                {
                    Name = "V případě sucha zalít keře a stromy",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.February, 3)]
                    },
                    User = user,
                }
                ,
                new GardeningTask
                {
                    Name = "Zkontrolovat a připravit sudy a nádrže na vody",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.February, 4)]
                    },
                    User = user,
                } ,
                new GardeningTask
                {
                    Name = "Prořezat rybízy, maliníky a ostružiníky",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.February, 4)]
                    },
                    User = user,
                },
                new GardeningTask
                {
                    Name = "Výchovné a tvarovací řezy ovocných stromků",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.March, 1)]
                    },
                    User = user,
                },
                new GardeningTask
                {
                    Name = "Ochrana záhonů před slimáky",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.May, 1)]
                    },
                    User = user,
                },
                new GardeningTask
                {
                    Name = "Mulčování záhonů posekanou trávou",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.May, 2)]
                    },
                    User = user,
                },
                new GardeningTask
                {
                    Name = "Výsadba sazenic na venkovní záhony",
                    MonthWeeks = new List<MonthWeek>
                    {
                        monthWeekMap[(Month.May, 3)]
                    },
                    User = user,
                }
                };

                await context.AddRangeAsync(tasks);
            }

            await context.SaveChangesAsync();
        }
    }
}
