using api.Model.DTOs;

namespace api.Model.Relations
{
    public class MonthSewedRelation
    {
        public string Month { get; set; }
        public virtual List<PlantDTO> SewedPlants { get; set; }

    }
}
