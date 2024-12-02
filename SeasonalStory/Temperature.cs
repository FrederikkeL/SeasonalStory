using System.ComponentModel.DataAnnotations;

namespace SeasonalStory;

public class Temperature
{
    [Key]
    public int Id { get; set; }
    public int Value { get; set; }
    public DateTime Timestamp { get; set; }

    public Temperature(int value)
    {
        Value = value;
    }

    public Temperature()
    {
    }

    public void ValidateValue()
    {
        if (Value < -30 || Value > 40)
            throw new ArgumentOutOfRangeException("Invalid temperature");
    }


    public void Validate()
    {
        ValidateValue();   
    }
  
}
