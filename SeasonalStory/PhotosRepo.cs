using Microsoft.EntityFrameworkCore;
using SeasonalStory.EFDbContext;
using SeasonalStory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SeasonalStory
{
    public class PhotosRepo
    {
        
        private ImageService ImageService { get; set; }

        public PhotosRepo()
        {
        }

        public async Task<Photo> Add(Photo photo)
        {
            //photo.ValidateUploadedImage();

            //photo.Image = photo.UploadedImage;

            //photo.Image = ImageService.ConvertToByteArray(photo.UploadedImage);

            //photo.ValidateImage();

            using (var context = new SSDbContext())
            {
                context.Set<Photo>().Add(photo);
                await context.SaveChangesAsync();
            }
            return photo;
        }
    }
}
