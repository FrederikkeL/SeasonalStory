using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeasonalStory;

public class Temperature
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int Value { get; set; }
    public DateTime Timestamp { get; set; }

 

    public void ValidateValue()
    {
        if (Value < -30 || Value > 40)
            throw new ArgumentOutOfRangeException("Invalid temperature");
    }


    public void Validate()
    {
        ValidateValue();   
    }

    public override string ToString()
    {
        return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Value)}={Value.ToString()}, {nameof(Timestamp)}={Timestamp.ToString()}}}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Temperature temperature &&
               Value == temperature.Value &&
               Timestamp == temperature.Timestamp;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, Timestamp);
    }
}
