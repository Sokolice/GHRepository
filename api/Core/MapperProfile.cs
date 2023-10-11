using api.Model;
using api.Model.DTOs;
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
