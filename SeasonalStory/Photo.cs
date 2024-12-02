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
        public byte[]? Billede { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(PhotoSeason)}={PhotoSeason.ToString()}, {nameof(PhotoTemp)}={PhotoTemp.ToString()}, {nameof(Billede)}={Billede}}}";
        }





        //public void ValidateUploadedImage()
        //{
        //    if (UploadedImage == null)
        //    {
        //        throw new NullReferenceException("UploadedImage cannot be null");
        //    }
        //    if (UploadedImage.Length > 10 * 1024 * 1024)
        //    {
        //        throw new ArgumentException("UploadedImage cannot be bigger than 10 MB");
        //    }
        //}

        //public void ValidateImage()
        //{
        //    if (Image == null)
        //    {
        //        throw new NullReferenceException("Image cannot be null");
        //    }
        //}
    }
}
