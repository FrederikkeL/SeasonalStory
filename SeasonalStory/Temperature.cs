using System.ComponentModel.DataAnnotations;

namespace SeasonalStory;

public class Temperature
{
    [Key]
    public int Id { get; set; }
    public int Value { get; set; }
    public DateTime Timestamp { get; set; }
}
