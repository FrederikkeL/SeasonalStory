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
  
}
