﻿using API.Model;
using Microsoft.AspNetCore.Identity;

namespace API.Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public virtual List<PlantRecord> PlantRecords { get; set; }
        public virtual List<Bed> Beds { get; set; }
        public virtual List<GardeningTask> Tasks {get; set;}
        public virtual List<Harvest> Harvests { get; set; } 
        public virtual List<Stats> Stats { get; set; }
        public virtual List<Plant> Plants { get; set; }

        public AppUser()
        {
            PlantRecords = new List<PlantRecord>();
            Beds = new List<Bed>();
            Tasks = new List<GardeningTask>();
            Harvests = new List<Harvest>();
            Stats = new List<Stats>();
            DisplayName = string.Empty;
            Plants = new List<Plant>();
        }

    }
}
