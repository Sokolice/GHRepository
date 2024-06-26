﻿using API.DTOs;

namespace API.Relations
{
    public class WeekTaskRelation
    {
        public int Week { get; set; }
        public List<GardeningTaskDTO> GardeningTasks {get; set;}
        public WeekTaskRelation()
        {
            Week = 0;
            GardeningTasks = new List<GardeningTaskDTO>();
        }
    }
}
