using API.Domain;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace API.DTOs
{
    public class PlantRecordDTO
    {
        public Guid Id { get; set; }
        public Guid PlantId { get; set; }
        public DateTime DatePlanted { get; set; }
        public int AmountPlanted { get; set; }
        public DateTime PresumedHarvest { get; set; }

        public int Progress { get; set; }

        public string Note { get; set; }
        public string Mark {  get; set; }

        public PlantRecordDTO()
        {
            Id = Guid.NewGuid();
            PlantId = Guid.NewGuid();
            Note = string.Empty;
            
        }

        public PlantRecordDTO(PlantRecord aPlantRecord)
        {
            Id = aPlantRecord.Id;
            AmountPlanted = aPlantRecord.AmountPlanted;
            DatePlanted = aPlantRecord.DatePlanted;
            PlantId = aPlantRecord.PlantId;
            Note = aPlantRecord.Note;
            Mark = aPlantRecord.Mark;
        }



        public void calculateProgress()
        {
            var min = DatePlanted.Ticks;
            var max = PresumedHarvest.Ticks;

            var today = DateTime.Today.Ticks;

            var progress = (((today - min) * 100) / (max - min));

            if ((max - min) > 0)
                Progress = Convert.ToInt32(progress);
            else
                Progress = 0;
        }

        public void CalculatePresumedHarvest(Plant plant)
        {
            var firstSewedMonth = plant.SewingMonths.OrderBy(a => a.MonthIndex).FirstOrDefault();
            var firstHarvestMonth = plant.HarvestMonths.OrderBy(a => a.MonthIndex).FirstOrDefault();

            PresumedHarvest = DatePlanted.AddMonths(firstHarvestMonth.MonthIndex - firstSewedMonth.MonthIndex);
        }
    }
}
