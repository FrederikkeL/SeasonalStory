using Microsoft.AspNetCore.Mvc;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeasonalStoryREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class S3Controller : ControllerBase
    {
        //Client for interacting with Amazon S3
        private readonly IAmazonS3 _s3Client;
        //Name of the S3 bucket
        private readonly string _bucketName = "zealandscience";

        public S3Controller()
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                DotNetEnv.Env.Load();
            }

            var accessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID");
            var secretKey = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY");

            // Instantiate AmazonS3Client with hardcoded credentials (NOT recommended for production or in git)
            _s3Client = new AmazonS3Client(accessKey, secretKey, Amazon.RegionEndpoint.EUWest1);
        }

        //To prevent users from being able to read above private keys in the frontend, we can create a backend endpoint that generates a presigned URL for uploading files to S3
        //We send the presigned URL to the frontend, which can then use it to upload files to S3. This way, the frontend does not need to know the private keys.
        [HttpGet("get-presigned-url")]
        public IActionResult GetPresignedUrl(string fileName, string fileType)
        {
            try
            {
                // Create a pre-signed URL request
                var request = new GetPreSignedUrlRequest
                {
                    BucketName = _bucketName,
                    Key = fileName,
                    Expires = DateTime.UtcNow.AddMinutes(5), // URL valid for 5 minutes
                    Verb = HttpVerb.PUT,
                    ContentType = fileType
                };

                // Generate the pre-signed URL
                var presignedUrl = _s3Client.GetPreSignedURL(request);

                return Ok(new { url = presignedUrl });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error generating presigned URL", details = ex.Message });
            }
        }
    }
}
