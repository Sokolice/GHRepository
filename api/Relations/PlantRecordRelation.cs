using API.DTOs;

namespace API.Relations
{
    public class PlantRecordRelation
    {
        public PlantRecordDTO PlantRecord { get; set; }
        public PlantDTO Plant { get; set; }

        public PlantRecordRelation()
        {
            PlantRecord = new PlantRecordDTO();
            Plant = new PlantDTO();
        }
    }
}
