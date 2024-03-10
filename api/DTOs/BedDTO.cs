using API.Model;

namespace API.DTOs
{
    public class BedDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public int NumOfColumns { get; set; }
        public int NumOfRows { get; set; }
        public bool IsDesign {  get; set; }
        public int CropRotation { get; set; }
        public string Note { get; set; }

        public BedDTO(Bed aBed)
        {
            Id = aBed.Id;
            Name = aBed.Name;
            Width = aBed.Width;
            Length = aBed.Length;   
            NumOfColumns = aBed.NumOfColumns;
            NumOfRows = aBed.NumOfRows;
            IsDesign = aBed.IsDesign;
            CropRotation = aBed.CropRotation;  
            Note = aBed.Note;
        }

        public BedDTO()
        {
            Name = string.Empty;
            Note = string.Empty;
        }
    }
}
