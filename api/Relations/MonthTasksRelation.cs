using api.DTOs;
using api.Model;

namespace api.Relations
{
    public class MonthTaskRelation
    {
        public string Month { get; set; }
        public virtual List<WeekTaskRelation> WeekTaskRelations { get; set; }
        public int Index { get; internal set; }

        public MonthTaskRelation()
        {
           Month = string.Empty;
           WeekTaskRelations = new List<WeekTaskRelation>();
        }

    }
}
