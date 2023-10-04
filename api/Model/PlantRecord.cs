using System.ComponentModel.DataAnnotations;

namespace api.Model
{
    public class PlantRecord
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PlantId { get; set; }
        public virtual Plant Plant { get; set; }
        public DateTime DatePlanted { get; set; }
        public int AmountPlanted { get; set; }

        public PlantRecord()
        {
            Id = Guid.NewGuid();
            Plant = new Plant();
            PlantId = Guid.NewGuid();
        }
    }
}
