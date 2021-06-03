using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.Qualification;

namespace CarryDoggyGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationsController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public QualificationsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        //// GET: api/Qualifications
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Qualification>>> GetQualifications()
        //{
        //    return await _context.Qualifications.ToListAsync();
        //}

        //// GET: api/Qualifications/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Qualification>> GetQualification(int id)
        //{
        //    var qualification = await _context.Qualifications.FindAsync(id);

        //    if (qualification == null)
        //    {
        //        return NotFound();
        //    }

        //    return qualification;
        //}

        //// PUT: api/Qualifications/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutQualification(int id, Qualification qualification)
        //{
        //    if (id != qualification.QualificationId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(qualification).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!QualificationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Qualifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Qualification>> PostQualification([FromBody] CreateQualification model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Qualification qualification = new Qualification
            {
                Score = model.Score,
                Reason = model.Reason,
                Recommendation = model.Recommendation
            };

            _context.Qualifications.Add(qualification);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(model);
        }

        //// DELETE: api/Qualifications/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteQualification(int id)
        //{
        //    var qualification = await _context.Qualifications.FindAsync(id);
        //    if (qualification == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Qualifications.Remove(qualification);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool QualificationExists(int id)
        //{
        //    return _context.Qualifications.Any(e => e.QualificationId == id);
        //}
    }
}
