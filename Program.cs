using weather_analysis;

class Program
{
    public static void Main(string[] args)
    {
        var measurements = new List<Measurement>
        {
            new Measurement { Temperature = 12, Date = DateTime.Now, StationNumber = 1 },
            new Measurement { Temperature = 12, Date = DateTime.Now, StationNumber = 2 },            
            new Measurement { Temperature = 12, Date = DateTime.Now, StationNumber = 3 }
        };

        var measurementList = new MeasurementList
        {
            Measurements = measurements
        };
        measurementList.Sort(SortBy.Temperature, SortingWith.SelectionSort);
    }
}