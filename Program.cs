using System.Globalization;
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
            string[] WeatherData = line.Split(",");
            
                Console.WriteLine(WeatherData);
                
                if (WeatherData.Length == 14)
                {
                    var weatherDate = new WeatherDate()
                    {
                        MeasuringStationNumber = Convert.ToInt32(WeatherData[0]),
                        DateOfMeasurement = WeatherData[1],
                        SunshineHours = float.Parse(WeatherData[10],CultureInfo.InvariantCulture.NumberFormat),
                        Temperature = float.Parse(WeatherData[5], CultureInfo.InvariantCulture.NumberFormat),
                        RainAmount = float.Parse(WeatherData[12], CultureInfo.InvariantCulture.NumberFormat),
                    };
                    weatherDates.Add(weatherDate);
                }
        }
            
        foreach (var weatherDate in weatherDates)
        {
            Console.WriteLine($"MeasuringStationNumber: {weatherDate.MeasuringStationNumber} | DateOfMeasurement: {weatherDate.DateOfMeasurement} | SunshineHours: {weatherDate.SunshineHours} | Temperature: {weatherDate.Temperature} | RainAmount: {weatherDate.RainAmount}");
        }

        return weatherDates;
    }

    public static (int, string, double) GetHighestTemperature(List<WeatherDate> weatherDates)
    {
        int NumberOfMeasuringStationForHighestTemperature = 0;
        string DateOfHighestTemperature = "";
        double HighestTemperature = 0;
        
        
        foreach (var weatherDate in weatherDates)
        {
            double currentTemperature = weatherDate.Temperature;
            if (currentTemperature > HighestTemperature)
            {
                NumberOfMeasuringStationForHighestTemperature = weatherDate.MeasuringStationNumber;
                DateOfHighestTemperature = weatherDate.DateOfMeasurement;
                HighestTemperature = currentTemperature;
            }
        }
        return (NumberOfMeasuringStationForHighestTemperature, DateOfHighestTemperature, HighestTemperature);
    }
    
    public static void Main(string[] args)
    {
        var weatherDates = ReadCSV();
        var (NumberOfMeasuringStation, DateOfMeasuring, Temperature) = GetHighestTemperature(weatherDates);
        Console.WriteLine($"the highest temperature ist {Temperature} measured from the station {NumberOfMeasuringStation} on {DateOfMeasuring}");
    }
}