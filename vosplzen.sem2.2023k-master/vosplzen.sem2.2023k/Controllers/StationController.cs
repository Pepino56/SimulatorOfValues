using Microsoft.AspNetCore.Mvc;
using vosplzen.sem2._2023k.Data;
using vosplzen.sem2._2023k.Data.Model;

namespace vosplzen.sem2._2023k.Controllers
{
    [ApiController]
    [Route("api")]
    public class StationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("stations")]
        public IActionResult GetListOfStations()
        {
            var stations = _context.Stations.ToList();
            return Ok(stations);
        }

        [HttpPost]
        [Route("stations")]
        public IActionResult AddStation([FromBody] Station station)
        {
            if (station == null)
            {
                return BadRequest("Station object is null");
            }

            if (_context.Stations.Any(x => x.Title.Equals(station.Title)))
            {
                return Conflict("Duplicities are not allowed. Sorry.");
            }

            _context.Stations.Add(station);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetListOfStations), new { id = station.Id }, station);
        }
    }
}
