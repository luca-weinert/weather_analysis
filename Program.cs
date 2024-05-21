using weather_analysis;

class Program
{
    public static void Main(string[] args)
    {
        var measurements = new List<Measurement>
        {
            new Measurement { Temperature = 40, Date = DateTime.Now, StationNumber = 1 },
            new Measurement { Temperature = 1, Date = DateTime.Now, StationNumber = 2 },
            new Measurement { Temperature = 90, Date = DateTime.Now, StationNumber = 3 },
            new Measurement { Temperature = 4, Date = DateTime.Now, StationNumber = 3 },
            new Measurement { Temperature = 2, Date = DateTime.Now, StationNumber = 3 }
        };

        var measurementList = new MeasurementList
        {
            Measurements = measurements
        };
        
        foreach (var measurement in measurementList.Measurements)
        {
            Console.WriteLine(measurement.Temperature);
        }
        
       measurementList.Sort(SortBy.Temperature, SortingWith.SelectionSort);

       Console.WriteLine("------------");
       
       foreach (var measurement in measurementList.Measurements)
       {
           Console.WriteLine(measurement.Temperature);
       }
    }
}