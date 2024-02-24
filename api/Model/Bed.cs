using API.Core;
using API.Relations;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace API.Model
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
        public bool IsDesign { get; set; }
        public int CropRotation { get; set; }
        public virtual List<Plant> Plants { get; set; }

        public Bed()
        {
            Name = string.Empty;
            Cells = new List<Cell>();
            NumOfColumns = 0;
            NumOfRows = 0;
            Width = 0;  
            Cells =  new List<Cell> { };
            IsDesign = false;
            CropRotation = 0;
        }

        public Bed(BedRelation aBedRelation)
        {
            Id = aBedRelation.Bed.Id;
            Name = aBedRelation.Bed.Name;
            Length = aBedRelation.Bed.Length;
            Width = aBedRelation.Bed.Width;
            NumOfColumns = aBedRelation.Bed.NumOfColumns;
            NumOfRows = aBedRelation.Bed.NumOfRows;
            Cells = aBedRelation.Cells;
            IsDesign = aBedRelation.Bed.IsDesign;
            CropRotation = aBedRelation.Bed.CropRotation;
        }

    }
}
