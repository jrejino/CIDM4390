using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using webapi.Models;
using webapi.Data;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatsimMETARController : ControllerBase
    {
        private readonly ILogger<VatsimMETARController> _logger;
        private readonly WebApiDbContext _context;

        public VatsimMETARController(ILogger<VatsimMETARController> logger,
                                     WebApiDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/VatsimMETAR
        [HttpGet]
        public async Task<ActionResult<IEnumerable<METARStation>>> GetStations()
        {
            _logger.LogInformation("VatsimMETAR Called");
            return await _context.Stations.ToListAsync();
        }

        // GET: api/VatsimMETAR/5
        [HttpGet("{id}")]
        public async Task<ActionResult<METARStation>> GetMETARStation(string id)
        {
            var mETARStation = await _context.Stations.FindAsync(id);

            if (mETARStation == null)
            {
                return NotFound();
            }

            return mETARStation;
        }

        // PUT: api/VatsimMETAR/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMETARStation(string id, METARStation mETARStation)
        {
            if (id != mETARStation.ICAO)
            {
                return BadRequest();
            }

            _context.Entry(mETARStation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!METARStationExists(id))
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
        public async Task<ActionResult<METARStation>> PostMETARStation(METARStation mETARStation)
        {
            _context.Stations.Add(mETARStation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (METARStationExists(mETARStation.ICAO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMETARStation", new { id = mETARStation.ICAO }, mETARStation);
        }

        // DELETE: api/VatsimMETAR/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<METARStation>> DeleteMETARStation(string id)
        {
            var mETARStation = await _context.Stations.FindAsync(id);
            if (mETARStation == null)
            {
                return NotFound();
            }

            _context.Stations.Remove(mETARStation);
            await _context.SaveChangesAsync();

            return mETARStation;
        }

        private bool METARStationExists(string id)
        {
            return _context.Stations.Any(e => e.ICAO == id);
        }
    }
}
