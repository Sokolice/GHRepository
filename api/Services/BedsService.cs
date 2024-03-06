﻿using API.Core;
using API.Model;
using API.Persistence;
using API.Relations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BedsService: IBedsService
    {
        private readonly DataContext _context;

        public BedsService(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<List<BedRelation>>> GetBeds()
        {

            var bedsDTO = await _context.Beds
                                        .Select(a => new BedRelation(a))
                                        .ToListAsync();

            foreach (var bed in bedsDTO)
            {
                bed.GetAllCompanionPlants(_context);
                bed.GetAllAvoidPlants(_context);
            }

            return Result<List<BedRelation>>.Success(bedsDTO);
        }


        public async Task<Result<BedRelation>> PostBed(BedRelation bedRelation)
        {
            var bed = new Bed(bedRelation);

            _context.Beds.Add(bed);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
                return Result<BedRelation>.Failure("Failed to save bed", false);


            return Result<BedRelation>.Success(bedRelation);
        }

        public async Task<Result<Guid>> DeleteBed(Guid id)
        {
            var bed = await _context.Beds.FindAsync(id);

            if (bed == null)
                return Result<Guid>.Failure("Failed to delete bed. Bed with provided ID do not exists", true);

            _context.Cells.RemoveRange(bed.Cells);
            _context.Beds.Remove(bed);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result)
                return Result<Guid>.Failure("Failed to delete bed", false);

            return Result<Guid>.Success(id);
        }

        public async Task<Result<BedRelation>> GetBed(Guid id)
        {
            var bed = await _context.Beds.FindAsync(id);

            return Result<BedRelation>.Success(new BedRelation(bed));
        }

        public async Task<Result<BedRelation>> UpdateBed(Guid id, BedRelation bedRelation)
        {
            if (id != bedRelation.Bed.Id)
                return Result<BedRelation>.Failure("Failed to update bed", false);

            
                var bed = await _context.Beds.FindAsync(id);

            if (bed == null)
                return Result<BedRelation>.Failure("Failed to update bed. Bed do not exists", true);

               
                bed.Name = bedRelation.Bed.Name;
                bed.Length = bedRelation.Bed.Length;
                bed.Width = bedRelation.Bed.Width;
                bed.NumOfRows = bedRelation.Bed.NumOfRows;
                bed.NumOfColumns = bedRelation.Bed.NumOfColumns;
                bed.Cells = bedRelation.Cells;
                bed.IsDesign =  bedRelation.Bed.IsDesign;
                bed.CropRotation = bedRelation.Bed.CropRotation;

                bed.Plants = _context.Plants.Where(a => bedRelation.Plants.Select(b => b.Id).ToList().Contains(a.Id)).ToList();

               
            await _context.SaveChangesAsync();

            return Result<BedRelation>.Success(bedRelation);
        }

    }
}