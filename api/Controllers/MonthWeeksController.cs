using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Model;
using API.Persistence;
using API.DTOs;
using AutoMapper;
using API.Core;
using API.Relations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthWeeksController : ControllerBase
    {
        private readonly DataContext _context;

        public MonthWeeksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MonthWeeksGrouped
        [HttpGet]
        [Route("GetMonthWeeksGrouped")]
        public List<MonthSewedRelation> GetMonthWeeksGrouped()
        {

            var monthweeks = _context.MonthWeeks.Include(x => x.SewedPlant).ToList();

            var monthsDictionary = monthweeks.OrderBy(a=>a.MonthIndex)
                .GroupBy(x => x.Month)
                .ToDictionary(x => x.Key,
                    x => x.SelectMany(y => y.SewedPlant).GroupBy(y => y.Id).Select(y => y.First()).ToList());

            return monthsDictionary.Select(y => new MonthSewedRelation
            {
                Month = y.Key,
                SewedPlants = MyMapping.MapPlants(y.Value).OrderBy(a=>a.Name).ToList(),
            }).ToList();
        }

        // GET: api/MonthWeeksRelation
        [HttpGet]
        [Route("GetMonthWeeksRelation")]
        public List<MonthWeekRelation> GetMonthWeeksRelation()
        {

            var monthWeeksRelations = _context.MonthWeeks.OrderBy(a => a.MonthIndex).Select(x => new MonthWeekRelation
            {
                GardeningTasks = MyMapping.MapGardeningTasks(x.GardeningTasks),
                HarvestedPlants = MyMapping.MapPlants(x.HarvestedPlant),
                MonthWeekDTO = new MonthWeekDTO{Month = x.Month, MonthIndex = x.MonthIndex, Week = x.Week},
                SewedPlants = MyMapping.MapPlants(x.SewedPlant)
            }).ToList();

            return monthWeeksRelations;
        }


        // GET: api/MonthWeeks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonthWeek>> GetMonthWeek(string id)
        {
          if (_context.MonthWeeks == null)
          {
              return NotFound();
          }
            var monthWeek = await _context.MonthWeeks.FindAsync(id);

            if (monthWeek == null)
            {
                return NotFound();
            }

            return monthWeek;
        }

        // PUT: api/MonthWeeks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthWeek(string id, MonthWeek monthWeek)
        {
            if (id != monthWeek.Month)
            {
                return BadRequest();
            }

            _context.Entry(monthWeek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthWeekExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MonthWeeks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MonthWeek>> PostMonthWeek(MonthWeek monthWeek)
        {
          if (_context.MonthWeeks == null)
          {
              return Problem("Entity set 'DataContext.MonthWeeks'  is null.");
          }
            _context.MonthWeeks.Add(monthWeek);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MonthWeekExists(monthWeek.Month))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMonthWeek", new { id = monthWeek.Month }, monthWeek);
        }

        // DELETE: api/MonthWeeks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonthWeek(string id)
        {
            if (_context.MonthWeeks == null)
            {
                return NotFound();
            }
            var monthWeek = await _context.MonthWeeks.FindAsync(id);
            if (monthWeek == null)
            {
                return NotFound();
            }

            _context.MonthWeeks.Remove(monthWeek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonthWeekExists(string id)
        {
            return (_context.MonthWeeks?.Any(e => e.Month == id)).GetValueOrDefault();
        }
    }
}
