using API.Core;
using API.Relations;

namespace API.Services
{
    public interface IMonthWeeksService
    {
        Task<Result<List<MonthSewedRelation>>> GetMonthWeeksGrouped();
        Task<Result<List<MonthWeekRelation>>> GetMonthWeeksRelation();
    }
}
