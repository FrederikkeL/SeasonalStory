using SeasonalStory.EFDbContext;

namespace SeasonalStory;

public class TemperatureRepo
{
    private readonly SSDbContext _dbContext;

    public TemperatureRepo()
    {
        _dbContext = new SSDbContext();
    }

    public TemperatureRepo(SSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddTemperature(Temperature newTemperature)
    {
        _dbContext.Temperatures.Add(newTemperature);
        _dbContext.SaveChanges();
    }
}
