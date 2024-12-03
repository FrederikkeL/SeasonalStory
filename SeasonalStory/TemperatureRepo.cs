using SeasonalStory.EFDbContext;

namespace SeasonalStory;

public class TemperatureRepo
{
    public TemperatureRepo()
    {
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
