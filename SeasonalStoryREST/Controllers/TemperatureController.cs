using Microsoft.AspNetCore.Mvc;
using SeasonalStory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeasonalStoryREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly TemperatureRepo _repo;

        public TemperatureController(TemperatureRepo repo)
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
        [HttpPost]
        public void Post([FromBody] Temperature newTemperature)
        {
            _repo.AddTemperature(newTemperature);
        }
    }
}
