using Microsoft.AspNetCore.Http;
using SeasonalStory.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.ComponentModel;


namespace SeasonalStory
{
    public class Photo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Season PhotoSeason { get; set; }
        public TemperatureIntervals PhotoTemp { get; set; }
        public string? UploadedImage { get; set; }
        public DateOnly DateAdded { get; set; }


        public void Validate()
        {
            if (UploadedImage == null)
            {
                throw new NullReferenceException("Image cannot be null");
            }
            if (UploadedImage == "")
            {
                throw new ArgumentException("Image cannot be empty");
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(PhotoSeason)}={PhotoSeason.ToString()}, {nameof(PhotoTemp)}={PhotoTemp.ToString()}, {nameof(UploadedImage)}={UploadedImage}}}";
        }
    }
}
