using API.Model;
using Microsoft.EntityFrameworkCore;

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



        public static void calculateProgress(PlantRecordDTO record)
        {
            var min = record.DatePlanted.Ticks;
            var max = record.PresumedHarvest.Ticks;

            var today = DateTime.Today.Ticks;

            var progress = (((today - min) * 100) / (max - min));

            if ((max - min) > 0)
                record.Progress = Convert.ToInt32(progress);
            else
                record.Progress = 0;
        }

        public static void CalculatePresumedHarvest(PlantRecordDTO plantRecord, Plant plant)
        {

            var firstHarvestMonth = plant.HarvestMonths.OrderBy(a => a.MonthIndex).FirstOrDefault();

            var presumedHarvest = plantRecord.DatePlanted.AddMonths(firstHarvestMonth.MonthIndex - 1);
            plantRecord.PresumedHarvest = presumedHarvest;
        }
    }
}
