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
                    try
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
                    catch (FormatException exception)
                    {
                        Console.WriteLine($"error parsing line: {line}. Exception: {exception.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Incomplete data line (length {WeatherData.Length}): line: {line}");
                }
        }
            
        foreach (var weatherDate in weatherDates)
        {
            Console.WriteLine($"MeasuringStationNumber: {weatherDate.MeasuringStationNumber} | DateOfMeasurement: {weatherDate.DateOfMeasurement} | SunshineHours: {weatherDate.SunshineHours} | Temperature: {weatherDate.Temperature} | RainAmount: {weatherDate.RainAmount}");
        }

        return weatherDates;
    }

    public static (int?, string?, double?) GetHighestTemperature(List<WeatherDate> weatherDates)
    {
        int ?NumberOfMeasuringStationForHighestTemperature = 0;
        string ?DateOfHighestTemperature = "";
        double ?HighestTemperature = 0;
        
        
        foreach (var weatherDate in weatherDates)
        {
            double ?currentTemperature = weatherDate.Temperature;
            if (currentTemperature > HighestTemperature)
            {
                NumberOfMeasuringStationForHighestTemperature = weatherDate.MeasuringStationNumber;
                DateOfHighestTemperature = weatherDate.DateOfMeasurement;
                HighestTemperature = currentTemperature;
            }
        }
        return (NumberOfMeasuringStationForHighestTemperature, DateOfHighestTemperature, HighestTemperature);
    }

    public static void GetAverageTemperature(List<WeatherDate> weatherData)
    {
        // weatherData[0].Temperature; 

        double ?TemperatureSum = 0; 
        
        foreach (var weatherDate in weatherData)
        {
            TemperatureSum = TemperatureSum + weatherDate.Temperature;
        }

        double ?TemperatureAverage = TemperatureSum / weatherData.Count; 
        Console.WriteLine($"the Temperature Average is: {TemperatureAverage}");
    }
    
    public static void Main(string[] args)
    {
        var weatherData = ReadCSV();
        var (NumberOfMeasuringStation, DateOfMeasuring, Temperature) = GetHighestTemperature(weatherData);
        Console.WriteLine($"the highest temperature ist {Temperature} measured from the station {NumberOfMeasuringStation} on {DateOfMeasuring}");
        GetAverageTemperature(weatherData);
    }
}