using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIAdmin.Models;
using WebAPIAdmin.Models.Context;

namespace WebAPIAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class achivementsController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public achivementsController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/achivements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<achivement>>> Getachivements()
        {
            return await _context.achivements.ToListAsync();
        }

        // GET: api/achivements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<achivement>> Getachivement(int id)
        {
            var achivement = await _context.achivements.FindAsync(id);

            if (achivement == null)
            {
                return NotFound();
            }

            return achivement;
        }
        /// search by name
        // GET: api/Searcg/name
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<achivement>>> Search(string name)
        {
            return await _context.achivements.Where(a => a.name.Contains(name)).ToListAsync();
        }
        // PUT: api/achivements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putachivement(int id, achivement achivement)
        {
            if (id != achivement.id)
            {
                return BadRequest();
            }

            _context.Entry(achivement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!achivementExists(id))
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
        //active achivement though id
        [HttpPut("active/{id}")]
        public async Task<IActionResult> ActiveAchivement(int id)
        {

            achivement b = _context.achivements.FirstOrDefault(u => u.id == id && u.status == false);
            if (b != null) b.status = true; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!achivementExists(id))
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
        ///disable achivement though id
        [HttpPut("disable/{id}")]
        public async Task<IActionResult> DisableCategory(int id)
        {

            achivement b = _context.achivements.FirstOrDefault(u => u.id == id && u.status == true);
            if (b != null) b.status = false; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!achivementExists(id))
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
        // POST: api/achivements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<achivement>> Postachivement(achivement achivement)
        {
            _context.achivements.Add(achivement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getachivement", new { id = achivement.id }, achivement);
        }

        // DELETE: api/achivements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteachivement(int id)
        {
            var achivement = await _context.achivements.FindAsync(id);
            if (achivement == null)
            {
                return NotFound();
            }

            _context.achivements.Remove(achivement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool achivementExists(int id)
        {
            return _context.achivements.Any(e => e.id == id);
        }
    }
}
