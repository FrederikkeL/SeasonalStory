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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("get-latest")]
        public async Task<ActionResult<Temperature>> GetLatest()
        {
            var temperature = await _repo.GetLatest();
            if (temperature == null) { return NotFound("Not found"); }
            return Ok(temperature);
        }

        // POST api/<TempController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] TemperatureData data)
        {
            var temperature = new Temperature
            {
                Value = data.Value,
                Timestamp = DateTime.Now
            };
            var newTemperature = await _repo.AddTemperature(temperature);
            return Created("", newTemperature);
        }

        public class TemperatureData
        {
            public int Value { get; set; }
        }
    }
}
