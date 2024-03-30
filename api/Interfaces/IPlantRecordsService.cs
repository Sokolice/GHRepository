using API.Core;
using API.DTOs;

namespace API.Interfaces
{
    public interface IPlantRecordsService
    {
        Task<Result<List<PlantRecordDTO>>> GetPlantRecords();
        Task<Result<PlantRecordDTO>> PostPlantRecord(PlantRecordDTO plantRecordDTO);
        Task<Result<Guid>> DeletePlantRecord(Guid id);
        Task<Result<PlantRecordDTO>> UpdatePlantRecord(Guid id, PlantRecordDTO plantRecord);
        Task<Result<PlantRecordDTO>> GetPlant(Guid id);
    }
}
