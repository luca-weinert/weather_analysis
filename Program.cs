using weather_analysis;

class Program
{
    public static List<WeatherDate> ReadCSV()
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            @"weatherData.csv");
        var reader = new StreamReader(path);
        List<WeatherDate> weatherDates = new List<WeatherDate>();
        
        string line;
        // ignore the first line (header)
        reader.ReadLine();
        
        while ((line = reader.ReadLine()) != null)
        {
            string[] WheatherData = line.Split(",");
            
                Console.WriteLine(WheatherData);
                
                if (WheatherData.Length == 14)
                {
                    WeatherDate weatherDate = new WeatherDate()
                    {
                        MeasuringStationNumber = WheatherData[0],
                        SunshineHours = WheatherData[10],
                        Temperature = WheatherData[5],
                        RainAmount = "test"
                    };
                    weatherDates.Add(weatherDate);
                }
        }
            
        foreach (WeatherDate weatherDate in weatherDates)
        {
            Console.WriteLine($"MeasuringStationNumber: {weatherDate.MeasuringStationNumber}, SunshineHours: {weatherDate.SunshineHours}, Temperature: {weatherDate.Temperature}, RainAmount: {weatherDate.RainAmount}");
        }

        return weatherDates;
    }

    public static string GetHighestTemperature(List<WeatherDate> weatherDates)
    {

        return "test";
    }
    
    public static void Main(string[] args)
    {
        var weatherDates = ReadCSV();
        var highestTemperature =  GetHighestTemperature(weatherDates);
    }
}