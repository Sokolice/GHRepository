using API.Core;
using API.Relations;

namespace API.Interfaces
{
    public interface IMonthWeeksService
    {
        Task<Result<List<MonthSewedRelation>>> GetMonthWeeksGrouped();
        Task<Result<List<MonthWeekRelation>>> GetMonthWeeksRelation();
    }
}
