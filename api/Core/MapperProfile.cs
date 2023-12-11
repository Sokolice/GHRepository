using api.DTOs;
using api.Model;
using AutoMapper;

namespace api.Core
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Plant, PlantDTO>();
            CreateMap<MonthWeek, MonthWeekDTO>();
            CreateMap<PlantRecord, PlantRecordDTO>();
            CreateMap<GardeningTask, GardeningTaskDTO>();
            CreateMap<Pest, PestDTO>();
        }
    }
}
