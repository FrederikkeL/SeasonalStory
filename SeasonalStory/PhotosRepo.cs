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
        private SSDbContext Context { get; set; }
        private ImageService ImageService { get; set; }

        public PhotosRepo(SSDbContext dbContext, ImageService iService)
        {
            Context = dbContext;
            ImageService = iService;
        }

        public async Task<Photo> Add(Photo photo)
        {
            photo.Validate();

            photo.Image = await ImageService.ConvertToByteArray(photo.UploadedImage);

            using (var context = new SSDbContext())
            {
                context.Set<Photo>().Add(photo);
                await context.SaveChangesAsync();
            }
            return photo;
        }
    }
}
