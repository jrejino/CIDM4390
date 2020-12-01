using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using domain;
using domain.VatsimMETARAggregate;
using repository;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatsimMETARController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public VatsimMETARController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/VatsimMETAR
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VatsimMETAR>>> GetVatsimMETAR()
        {
            return await _context.VatsimMETAR.ToListAsync();
        }

        // GET: api/VatsimMETAR/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VatsimMETAR>> GetVatsimMETAR(string id)
        {
            var vatsimMETAR = await _context.VatsimMETAR.FindAsync(id);

            if (vatsimMETAR == null)
            {
                return NotFound();
            }

            return vatsimMETAR;
        }

        // PUT: api/VatsimMETAR/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVatsimMETAR(string id, VatsimMETAR vatsimMETAR)
        {
            if (id != vatsimMETAR.RetreivedTimeStamp)
            {
                return BadRequest();
            }

            _context.Entry(vatsimMETAR).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VatsimMETARExists(id))
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

        // POST: api/VatsimMETAR
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VatsimMETAR>> PostVatsimMETAR(VatsimMETAR vatsimMETAR)
        {
            _context.VatsimMETAR.Add(vatsimMETAR);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VatsimMETARExists(vatsimMETAR.RetreivedTimeStamp))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVatsimMETAR", new { id = vatsimMETAR.RetreivedTimeStamp }, vatsimMETAR);
        }

        // DELETE: api/VatsimMETAR/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VatsimMETAR>> DeleteVatsimMETAR(string id)
        {
            var vatsimMETAR = await _context.VatsimMETAR.FindAsync(id);
            if (vatsimMETAR == null)
            {
                return NotFound();
            }

            _context.VatsimMETAR.Remove(vatsimMETAR);
            await _context.SaveChangesAsync();

            return vatsimMETAR;
        }

        private bool VatsimMETARExists(string id)
        {
            return _context.VatsimMETAR.Any(e => e.RetreivedTimeStamp == id);
        }
    }
}
