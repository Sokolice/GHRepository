using API.Core;
using API.DTOs;
using API.Model;

namespace API.Relations
{
    public class BedRelation
    {
        public BedDTO Bed {  get; set; }
        public List<Cell> Cells { get; set; }
        public List<PlantDTO> Plants { get; set; }

        public BedRelation()
        {
            Cells = new List<Cell>();
            Bed = new BedDTO();
            Plants = new List<PlantDTO>();
        }

        public BedRelation(Bed aBed)
        {
            Bed = new BedDTO(aBed);
            Cells = aBed.Cells.OrderBy(x => x.Y).ToList().OrderBy(x => x.X).ToList();

            Plants = MyMapping.MapPlantList(aBed.Plants);
        }
    }
}
