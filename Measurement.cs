namespace weather_analysis;

public class Measurement
{
    public int StationNumber;
    public DateTime Date;
    public double Temperature;

    public bool IsGreaterThan(double other)
    {
        return Temperature > other;
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