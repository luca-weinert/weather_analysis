namespace weather_analysis;

public class Measurement
{
    public int StationNumber;
    public DateTime Date;
    public double Temperature;

    public bool IsGreaterThan(Measurement other, SortBy sortBy)
    {
        switch (sortBy)
        {
         case SortBy.StationNumber:
             return this.StationNumber > other.StationNumber;
         case SortBy.Date:
             return this.Date > other.Date;
         case SortBy.Temperature:
             return this.Temperature > other.Temperature;
         default:
             throw new ArgumentOutOfRangeException(nameof(sortBy), sortBy, null);
        }
    }
    
    public bool IsLessThan(double other)
    {
        return Temperature < other;
    }

    public void IsGreaterThan(DateTime other)
    {
        
    }
    public void IsGreaterThan(string other)
    {
        
    }
}