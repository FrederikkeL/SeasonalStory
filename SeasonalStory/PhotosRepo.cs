using Microsoft.EntityFrameworkCore;
using SeasonalStory.EFDbContext;
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
        public PhotosRepo()
        {
        }

        public async Task<Photo> Add(Photo photo)
        {
            //photo.Validate();

            using (var context = new SSDbContext())
            {
                context.Set<Photo>().Add(photo);
                await context.SaveChangesAsync();
            }
            return photo;
        }
    }
}
