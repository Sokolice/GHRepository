using api.Model.DTOs;

namespace api.Model.Relations
{
    public class PlantRecordRelation
    {
        public PlantRecordDTO PlantRecord { get; set; }
        public PlantDTO Plant { get; set; }
    }
}
