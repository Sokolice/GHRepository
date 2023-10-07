using api.Model.DTOs;

namespace api.Model.Relations
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
    }
}
