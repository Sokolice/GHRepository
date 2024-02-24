using API.Model;
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

        public PlantRecordDTO()
        {
            Id = Guid.NewGuid();
            PlantId = Guid.NewGuid();
        }

        public PlantRecordDTO(PlantRecord aPlantRecord)
        {
            Id = aPlantRecord.Id;
            AmountPlanted = aPlantRecord.AmountPlanted;
            DatePlanted = aPlantRecord.DatePlanted;
            PlantId = aPlantRecord.PlantId;
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

            var firstHarvestMonth = plant.HarvestMonths.OrderBy(a => a.MonthIndex).FirstOrDefault();

            PresumedHarvest = DatePlanted.AddMonths(firstHarvestMonth.MonthIndex - 1);
        }
    }
}
