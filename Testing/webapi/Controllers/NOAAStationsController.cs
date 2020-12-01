// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;

// using domain;
// using domain.NOAAStationAggregate;
// using repository;

// namespace webapi.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class NOAAStationsController : ControllerBase
//     {
//         private readonly ILogger<NOAAStationsController> _logger;
//         private readonly IUnitOfWork _unitOfWork;

//         public NOAAStationsController(ILogger<NOAAStationsController> logger,
//                                       IUnitOfWork unitOfWork)

//         {
//             _logger = logger;
//             _unitOfWork = unitOfWork;
//         }

//         // GET: api/NOAAStations
//         // [HttpGet]
//         // public async Task<ActionResult<IEnumerable<NOAAStation>>> GetStations()
//         // {
//         //     _logger.LogInformation("VatsimMETAR Called");
//         //     return await _unitOfWork.Stations.GetAll();
//         // }

//         // GET: api/VatsimMETAR/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<NOAAStation>> GetMETARStation(string id)
//         {
//             var mETARStation = await _unitOfWork.Stations.Get(id);
//             //var mETARStation = await _context.Stations.FindAsync(id);

//             if (mETARStation == null)
//             {
//                 return NotFound();
//             }

//             return mETARStation;
//         }

//         // PUT: api/VatsimMETAR/5
//         // To protect from overposting attacks, enable the specific properties you want to bind to, for
//         // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutMETARStation(string id, NOAAStation mETARStation)
//         {
//             if (id != mETARStation.ICAO)
//             {
//                 return BadRequest();
//             }

//             //_context.Entry(mETARStation).State = EntityState.Modified;

//             try
//             {
//                 //await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!METARStationExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }

//         // POST: api/VatsimMETAR
//         // To protect from overposting attacks, enable the specific properties you want to bind to, for
//         // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//         [HttpPost]
//         public async Task<ActionResult<NOAAStation>> PostMETARStation(NOAAStation mETARStation)
//         {
//             //_context.Stations.Add(mETARStation);
//             try
//             {
//                 //await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateException)
//             {
//                 if (METARStationExists(mETARStation.ICAO))
//                 {
//                     return Conflict();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return CreatedAtAction("GetMETARStation", new { id = mETARStation.ICAO }, mETARStation);
//         }

//         // DELETE: api/VatsimMETAR/5
//         [HttpDelete("{id}")]
//         public async Task<ActionResult<NOAAStation>> DeleteMETARStation(string id)
//         {
//             //var mETARStation = await _context.Stations.FindAsync(id);
//             if (mETARStation == null)
//             {
//                 return NotFound();
//             }

//             //_context.Stations.Remove(mETARStation);
//             await _context.SaveChangesAsync();

//             return mETARStation;
//         }

//         private bool METARStationExists(string id)
//         {
//             return _context.Stations.Any(e => e.ICAO == id);
//         }
//     }
// }
