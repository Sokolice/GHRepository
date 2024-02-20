using api.Model;

namespace api.DTOs
{
    public class BedDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int NumOfColumns { get; set; }
        public int NumOfRows { get; set; }
        public bool isDesign {  get; set; }
        public int CropRotation { get; set; }
    }
}
