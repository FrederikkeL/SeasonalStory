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
        List<Photo> photos = new List<Photo>();

        public PhotosRepo()
        {
        }

        public async Task<IEnumerable<Photo>> Get()
        {
            using (var context = new SSDbContext())
            {
                photos = await context.Set<Photo>().AsNoTracking().ToListAsync();
            }
            return photos;
        }

        public async Task<Photo?> GetByID(int id)
        {
            using (var context = new SSDbContext())
            {
                return await context.Set<Photo>().FindAsync(id);
            }
        }

        public async Task<Photo> Add(Photo photo)
        {
            photo.Validate();

            using (var context = new SSDbContext())
            {
                context.Set<Photo>().Add(photo);
                await context.SaveChangesAsync();
            }
            return photo;
        }

        public async Task<Photo?> Delete(int id)
        {
            Photo? photo = await GetByID(id);

            if (photo == null) { return null; }

            using (var context = new SSDbContext())
            {
                context.Set<Photo>().Remove(photo);
                await context.SaveChangesAsync();
            }
            return photo;
        }
    }
}
