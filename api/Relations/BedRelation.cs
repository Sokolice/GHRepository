using API.DTOs;
using API.Model;

namespace API.Relations
{
    public class BedRelation
    {
        public BedDTO Bed {  get; set; }
        public List<Cell> Cells { get; set; }

        public BedRelation()
        {
            Cells = new List<Cell>();
            Bed = new BedDTO();
        }
    }
}
