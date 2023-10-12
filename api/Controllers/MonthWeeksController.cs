﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Model;
using api.Persistence;
using api.Model.DTOs;
using api.Model.Relations;
using AutoMapper;
using api.Core;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthWeeksController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MonthWeeksController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
    }

        // GET: api/MonthWeeksGrouped
        [HttpGet]
        public List<MonthSewedRelation> GetMonthWeeks()
        {

            // _mapper.Map(_context.MonthWeeks, MonthWeekDTO mont)

            //var monthweeks = _mapper.Map<List<>>

            var monthweeks = _context.MonthWeeks.Include(x => x.SewedPlant).ToList();

            var monthsDictionary = monthweeks
                .GroupBy(x => x.Month)
                .ToDictionary(x => x.Key,
                    x => x.SelectMany(y => y.SewedPlant).GroupBy(y => y.Id).Select(y => y.First()).ToList());

            //var monthsDictionarySorted = monthsDictionary.OrderBy(a => Month.sortedOrderList.IndexOf(a.Key));



            return monthsDictionary.Select(y => new MonthSewedRelation
            {
                Month = y.Key,
                SewedPlants = MyMapping.MapPlants(y.Value)
            }).ToList();
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
