using api.DTOs;
using api.Model;

namespace api.Relations
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
