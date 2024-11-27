using Microsoft.AspNetCore.Mvc;
using SeasonalStory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeasonalStoryREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly PhotosRepo _repo;

        public PhotosController(PhotosRepo repo)
        {
            _repo = repo;
        }


        // POST api/<PhotosController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Photo> Post([FromBody] Photo photo)
        {
            try
            {
                photo.ValidateImage();
            }
            catch(Exception e)
            {
                if (e.Message != null)
                    return BadRequest("Not Good");
            }
            Photo newPhoto = _repo.Add(photo).Result;
            return Created("", newPhoto);
        }
    }
}
