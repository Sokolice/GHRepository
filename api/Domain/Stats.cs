using API.Core;
using API.DTOs;
using API.Persistence;
using API.Relations;
using Humanizer;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing.Drawing2D;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using API.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class Stats
    {
        public Guid Id { get; set; }
        public DateTime Date {  get; set; }
        public DateTime WeatherChecked { get; set; }
        public bool FreezeAlert { get; set; }
        public bool HighTemperatureAlert { get; set; }
        public bool RainPeriodAlert { get; set; }
        public int MissingSowingThisWeekAmount { get; set; }
        public int MissingTaskThisWeekAmount { get; set; }
        public int CanBeSowedRepeatedlyAmount { get; set; }
        public int ReadyToHarvestAmount { get; set; }
        public string CanBeSowedThisWeek { get; set; }
        public string CanBeSowedRepeatedly { get; set; }
        public string ReadyToHarvest { get; set; }
        public virtual AppUser User { get; set; }

        public Stats()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            CanBeSowedThisWeek = string.Empty;
            CanBeSowedRepeatedly = string.Empty;
            ReadyToHarvest = string.Empty;
            CanBeSowedRepeatedlyAmount = 0;
            ReadyToHarvestAmount = 0;
        }
    }
}
