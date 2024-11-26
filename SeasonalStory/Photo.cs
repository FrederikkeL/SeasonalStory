using Microsoft.AspNetCore.Http;
using SeasonalStory.Enums;
using System.Reflection;

namespace SeasonalStory
{
    public class Photo
    {
        public int Id { get; set; }
        public Season PhotoSeason { get; set; }
        public Temperature PhotoTemp { get; set; }
        public string ImageFile { get; set; }

        public void ValidateImageFile()
        {
            if (ImageFile == null)
            {
                throw new NullReferenceException("Imagefile cannot be null");
            }
            if (ImageFile == "")
            {
                throw new ArgumentException("Imagefile cannot be empty");
            }
        }

        public void Validate()
        {
            ValidateImageFile();
        }
    }
}
