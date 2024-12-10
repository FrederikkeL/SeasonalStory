using Microsoft.EntityFrameworkCore;
using SeasonalStory.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SeasonalStory.Enums;
using System.ComponentModel.Design;

namespace SeasonalStory
{
    public class PhotosRepo
    {
        IEnumerable<Photo> photos = new List<Photo>();

        public PhotosRepo()
        {
        }

        public async Task<IEnumerable<Photo>> Get(string? seasonEnabled = null, int? temperatureInterval = null)
        {
            using (var context = new SSDbContext())
            {
                photos = await context.Set<Photo>().AsNoTracking().ToListAsync();
            }
            if (seasonEnabled != null)
            {
                photos = photos.Where(p => p.PhotoSeason == GetSeason());
            }
            if (temperatureInterval != null)
            {
                photos = photos.Where(p => p.PhotoTemp == GetTemperature(temperatureInterval));
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

        public Season? GetSeason()
        {
            switch (DateTime.Now.Month)
            {
                case 1:
                    return Season.Winter;
                case 2:
                    return Season.Winter;
                case 3:
                    return Season.Spring;
                case 4:
                    return Season.Spring;
                case 5:
                    return Season.Spring;
                case 6:
                    return Season.Summer;
                case 7:
                    return Season.Summer;
                case 8:
                    return Season.Summer;
                case 9:
                    return Season.Fall;
                case 10:
                    return Season.Fall;
                case 11:
                    return Season.Fall;
                case 12:
                    return Season.Winter;
                default:
                    return null;
            }
        }

        public TemperatureIntervals GetTemperature(int? temperature)
        {
            switch (temperature)
            {
                case < 0:
                    return TemperatureIntervals.BelowZero;
                case <= 12:
                    return TemperatureIntervals.OneToTwelve;
                case <= 18:
                    return TemperatureIntervals.ThirteenToEigthteen;
                case <= 23:
                    return TemperatureIntervals.NineteenToTwentythree;
                case <= 30:
                    return TemperatureIntervals.TwentyfourToThirty;
                default:
                    return TemperatureIntervals.AboveThirtyone;
            }
        }
    }
}
