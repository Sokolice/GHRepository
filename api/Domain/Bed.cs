using API.Relations;
using System.ComponentModel.DataAnnotations;

namespace API.Domain
{
    public class Bed
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public virtual List<Cell> Cells { get; set; }
        public int NumOfColumns {  get; set; }
        public int NumOfRows { get; set; }
        public bool IsDesign { get; set; }
        public int CropRotation { get; set; }
        public virtual List<Plant> Plants { get; set; }
        public string Note {  get; set; }
        public virtual AppUser User { get; set; }

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
            Note = string.Empty;
            Plants = new List<Plant>();
            User = new AppUser();
        }

        public Bed(BedRelation bedRelation)
        {
            Id = bedRelation.Bed.Id;
            Name = bedRelation.Bed.Name;
            Length = bedRelation.Bed.Length;
            Width = bedRelation.Bed.Width;
            NumOfColumns = bedRelation.Bed.NumOfColumns;
            NumOfRows = bedRelation.Bed.NumOfRows;
            Cells = bedRelation.Cells;
            IsDesign = bedRelation.Bed.IsDesign;
            CropRotation = bedRelation.Bed.CropRotation;
            Note = bedRelation.Bed.Note;
        }

    }
}
