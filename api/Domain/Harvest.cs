using API.Domain;
using API.DTOs;

namespace API.Model
{
    public class Harvest
    {
        public Guid Id { get; set; }
        public virtual Plant Plant { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }  
        public int Rating { get; set; }
        public string Note { get; set; }

        public virtual AppUser User { get; set; }
        public Harvest()
        {
            Id = Guid.NewGuid();
            Plant = new Plant();
            Date = DateTime.Now;
            Rating = 0;
            Note = string.Empty;
            Amount = 0;
        }

    }
}
