using Microsoft.EntityFrameworkCore;
using SeasonalStory.EFDbContext;

namespace SeasonalStory;

public class TemperatureRepo
{
    IEnumerable<Temperature> temperatures = new List<Temperature>();
    public TemperatureRepo()
    {
    }

    public async Task<IEnumerable<Temperature>> Get()
    {
        using (var context = new SSDbContext())
        {
            temperatures = await context.Set<Temperature>().AsNoTracking().ToListAsync();
        }
        return temperatures;
    }

    public async Task<Temperature> GetLatest()
    {
        temperatures = await Get();
        return temperatures.Last();
    }

    public async Task<Temperature> AddTemperature(Temperature temperature)
    {
        temperature.Validate();
        using (var context = new SSDbContext())
        {
            context.Set<Temperature>().Add(temperature);
            await context.SaveChangesAsync();
        }
        return temperature;
    }


}
