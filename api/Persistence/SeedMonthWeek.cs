using API.Model;
using Microsoft.AspNetCore.Routing;
using System;
using System.Diagnostics;
using System.Drawing;

namespace API.Persistence
{
    public class SeedMonthWeek
    {
        public static async Task SeedData(DataContext context)
        {
            //await context.Plants.re;

            var monthweeks = new List<MonthWeek>
            {
                new MonthWeek{Month = Month.January, Week = 1, MonthIndex=1},
                new MonthWeek{Month = Month.January, Week = 2, MonthIndex=1},
                new MonthWeek{Month = Month.January, Week = 3, MonthIndex=1},
                new MonthWeek{Month = Month.January, Week = 4, MonthIndex = 1},

                new MonthWeek{Month = Month.February, Week = 1, MonthIndex=2},
                new MonthWeek{Month = Month.February, Week = 2, MonthIndex = 2},
                new MonthWeek{Month = Month.February, Week = 3, MonthIndex = 2},
                new MonthWeek{Month = Month.February, Week = 4, MonthIndex = 2},

                new MonthWeek{Month = Month.March, Week = 1, MonthIndex = 3},
                new MonthWeek{Month = Month.March, Week = 2, MonthIndex = 3},
                new MonthWeek{Month = Month.March, Week = 3, MonthIndex = 3},
                new MonthWeek{Month = Month.March, Week = 4, MonthIndex = 3},

                new MonthWeek{Month = Month.April, Week = 1, MonthIndex = 4},
                new MonthWeek{Month = Month.April, Week = 2, MonthIndex = 4},
                new MonthWeek{Month = Month.April, Week = 3, MonthIndex = 4},
                new MonthWeek{Month = Month.April, Week = 4, MonthIndex = 4},

                new MonthWeek{Month = Month.May, Week = 1, MonthIndex = 5},
                new MonthWeek{Month = Month.May, Week = 2, MonthIndex = 5},
                new MonthWeek{Month = Month.May, Week = 3, MonthIndex = 5},
                new MonthWeek{Month = Month.May, Week = 4, MonthIndex = 5},

                new MonthWeek{Month = Month.June, Week = 1, MonthIndex = 6},
                new MonthWeek{Month = Month.June, Week = 2, MonthIndex = 6},
                new MonthWeek{Month = Month.June, Week = 3, MonthIndex = 6},
                new MonthWeek{Month = Month.June, Week = 4, MonthIndex = 6},

                new MonthWeek{Month = Month.July, Week = 1, MonthIndex = 7},
                new MonthWeek{Month = Month.July, Week = 2, MonthIndex = 7},
                new MonthWeek{Month = Month.July, Week = 3, MonthIndex = 7},
                new MonthWeek{Month = Month.July, Week = 4, MonthIndex = 7},

                new MonthWeek{Month = Month.August, Week = 1, MonthIndex = 8},
                new MonthWeek{Month = Month.August, Week = 2, MonthIndex = 8},
                new MonthWeek{Month = Month.August, Week = 3, MonthIndex = 8},
                new MonthWeek{Month = Month.August, Week = 4, MonthIndex = 8},

                new MonthWeek{Month = Month.September, Week = 1, MonthIndex = 9},
                new MonthWeek{Month = Month.September, Week = 2, MonthIndex = 9},
                new MonthWeek{Month = Month.September, Week = 3, MonthIndex = 9},
                new MonthWeek{Month = Month.September, Week = 4, MonthIndex = 9},

                new MonthWeek{Month = Month.October, Week = 1, MonthIndex = 10},
                new MonthWeek{Month = Month.October, Week = 2, MonthIndex = 10},
                new MonthWeek{Month = Month.October, Week = 3, MonthIndex = 10},
                new MonthWeek{Month = Month.October, Week = 4, MonthIndex = 10},

                new MonthWeek{Month = Month.November, Week = 1, MonthIndex = 11},
                new MonthWeek{Month = Month.November, Week = 2, MonthIndex = 11},
                new MonthWeek{Month = Month.November, Week = 3, MonthIndex = 11},
                new MonthWeek{Month = Month.November, Week = 4, MonthIndex = 11},

                new MonthWeek{Month = Month.December, Week = 1, MonthIndex = 12},
                new MonthWeek{Month = Month.December, Week = 2, MonthIndex = 12},
                new MonthWeek{Month = Month.December, Week = 3, MonthIndex = 12},
                new MonthWeek{Month = Month.December, Week = 4, MonthIndex = 12},
            };


            await context.MonthWeeks.AddRangeAsync(monthweeks);
            await context.SaveChangesAsync();

        }
    }
}
