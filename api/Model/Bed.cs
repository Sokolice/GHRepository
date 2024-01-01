using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace api.Model
{
    public class Bed
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public virtual List<Cell> Cells { get; set; }
        public int NumOfColumns {  get; set; }
        public int NumOfRows { get; set; }

        public Bed()
        {
            Name = string.Empty;
            Cells = new List<Cell>();
            NumOfColumns = 0;
            NumOfRows = 0;
            Width = 0;  
            Cells =  new List<Cell> { };
        }

    }
}
