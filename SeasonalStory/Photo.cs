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
        public Temperature PhotoTemp { get; set; }

        [NotMapped]
        public IFormFile? UploadedImage { get; set; }

        public byte[]? Image { get; set; }

        

        public void ValidateImageFile()
        {
            //if (ImageFile == null)
            //{
            //    throw new NullReferenceException("Imagefile cannot be null");
            //}
            //if (ImageFile == "")
            //{
            //    throw new ArgumentException("Imagefile cannot be empty");
            //}
        }

        public void Validate()
        {
            ValidateImageFile();
        }
    }
}
