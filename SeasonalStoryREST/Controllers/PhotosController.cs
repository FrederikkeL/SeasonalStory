using Microsoft.AspNetCore.Mvc;
using SeasonalStory;
using SeasonalStory.Enums;

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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photo>>> Get()
        {
            IEnumerable<Photo> result = await _repo.Get();

            if (result.Count() < 1)
            {
                return NotFound("No photos found");
            }
            return Ok(result);
        }

        // POST api/<PhotosController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromForm] string UploadedImage, [FromForm] Season PhotoSeason, [FromForm] TemperatureIntervals PhotoTemp)
        {
            if (UploadedImage == null || UploadedImage.Length == 0)
            {
                return BadRequest("No image file was uploaded.");
            }

            //byte[] imageData;
            //using (var memoryStream = new MemoryStream())
            //{
            //    await UploadedImage.CopyToAsync(memoryStream);
            //    imageData = memoryStream.ToArray(); // Convert the file into a byte array
            //}

            // Create a new Photo object
            var photo = new Photo
            {
                PhotoSeason = PhotoSeason,
                PhotoTemp = PhotoTemp,
                UploadedImage = UploadedImage
            };

            var newPhoto = await _repo.Add(photo);

            return Created("", newPhoto); // Return the newly created photo
        }
    }
}
