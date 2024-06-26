﻿using API.DTOs;

namespace API.Relations
{
    public class PlantRelation
    {
        public PlantDTO Plant { get; set; }

        public List<MonthWeekDTO> SewingMonths { get; set; }
        public List<MonthWeekDTO> HarvestMonths { get; set; }

        public List<PlantDTO> CompanionPlants { get; set; }

        public List<PlantDTO> AvoidPlants { get; set; }
        public virtual List<PlantRecordDTO> PlantRecords { get; set; }

        public virtual List<PestDTO> Pests { get; set; }

        public PlantRelation()
        {
            Plant = new PlantDTO();
            SewingMonths = new List<MonthWeekDTO>();
            HarvestMonths = new List<MonthWeekDTO>();
            CompanionPlants = new List<PlantDTO>();
            AvoidPlants = new List<PlantDTO>();
            PlantRecords = new List<PlantRecordDTO>();
            Pests = new List<PestDTO>();
        }
    }
}
