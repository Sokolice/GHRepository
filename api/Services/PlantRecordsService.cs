using API.Core;
using API.DTOs;
using API.Interfaces;
using API.Domain;
using API.Persistence;
using API.Relations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class PlantRecordsService: IPlantRecordsService
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;

        public PlantRecordsService(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Result<List<PlantRecordDTO>>> GetPlantRecords()
        {


            var plantsRecord = await _context.PlantRecords.Where(a=> a.User.Email == _userAccessor.GetUserEmail()).Select(a => new PlantRecordDTO(a))
                                                    .ToListAsync();

            foreach (var record in plantsRecord)
            {
                if (record.PresumedHarvest.ToString() == "01.01.0001 0:00:00")
                {
                    var plant = _context.Plants.Find(record.PlantId);
                    record.CalculatePresumedHarvest(plant);
                    await _context.SaveChangesAsync();

                }
                record.calculateProgress();
            }

            return Result<List<PlantRecordDTO>>.Success(plantsRecord);
        }

        public async Task<Result<PlantRecordDTO>> PostPlantRecord(PlantRecordDTO plantRecordDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a =>
               a.UserName == _userAccessor.GetUserName());


            var plant = _context.Plants.Find(plantRecordDTO.PlantId);

            if (plant == null)
                return Result<PlantRecordDTO>.Failure("Plant does not exists", true);

            plantRecordDTO.CalculatePresumedHarvest(plant);

            plantRecordDTO.calculateProgress();

            var newPlantRecord = new PlantRecord
            {
                Id = plantRecordDTO.Id,
                AmountPlanted = plantRecordDTO.AmountPlanted,
                DatePlanted = plantRecordDTO.DatePlanted,
                PlantId = plantRecordDTO.PlantId,
                Plant = _context.Plants.First(a => a.Id == plantRecordDTO.PlantId),
                Note = plantRecordDTO.Note,
                User = user
            };


            _context.PlantRecords.Add(newPlantRecord);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
                return Result<PlantRecordDTO>.Failure("Failed to save Plant record", false);

            return Result<PlantRecordDTO>.Success(plantRecordDTO);
        }

        public async Task<Result<Guid>> DeletePlantRecord(Guid id)
        {
            var plant = await _context.PlantRecords.FindAsync(id);
            if (plant == null)
                return Result<Guid>.Failure("Record does not exist", true);

            _context.PlantRecords.Remove(plant);
            var result  = await _context.SaveChangesAsync() > 0;

            if (!result)
                return Result<Guid>.Failure("Failed to delete plantrecord", false);

            return Result<Guid>.Success(id);
        }

        public async Task<Result<PlantRecordDTO>> UpdatePlantRecord(Guid id, PlantRecordDTO plantRecord)
        {
            if (id != plantRecord.Id)
                return Result<PlantRecordDTO>.Failure("Failed to update plant record", false);

                var record = await _context.PlantRecords.FindAsync(id);

            if (record == null)
                return Result<PlantRecordDTO>.Failure("Plant record does not exist", true);


            record.AmountPlanted = plantRecord.AmountPlanted;
            record.DatePlanted = plantRecord.DatePlanted;

            var plant = await _context.Plants.FindAsync(plantRecord.PlantId);

            if (plant == null)
                return Result<PlantRecordDTO>.Failure("Plant  does not exist", true);



            record.Plant = plant;
            record.PlantId = plantRecord.PlantId;

            await _context.SaveChangesAsync();

            return Result<PlantRecordDTO>.Success(plantRecord);
        }

        public async Task<Result<PlantRecordDTO>> GetPlant(Guid id)
        {
            var plantRecord = await _context.PlantRecords.FindAsync(id);

            if (plantRecord == null)
                return Result<PlantRecordDTO>.Failure("Plant record does not exist", true);

            return Result<PlantRecordDTO>.Success(new PlantRecordDTO(plantRecord));
        }
    }
}
