using Microsoft.AspNetCore.Mvc;
using SeasonalStory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeasonalStoryREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturesController : ControllerBase
    {
        private readonly TemperatureRepo _repo;

        public TemperaturesController(TemperatureRepo repo)
        {
            _repo = repo;
        }


        // GET: api/<TempController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<TempController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] int value)
        {
            var temperature = new Temperature
            {
                Value = value,
                Timestamp = DateTime.Now
            };
            var newTemperature = await _repo.AddTemperature(temperature);
            return Created("", newTemperature);
        }
    }
}
