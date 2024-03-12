namespace weather_analysis;

public class MeasurementController
{
    public List<Measurement> Measurements { get; set; }
    
    public MeasurementController()
    {
        
    }
    
    public void GetAverageTemperature(List<Measurement> weatherData)
    {
        double ?TemperatureSum = 0; 
        
        foreach (var weatherDate in weatherData)
        {
            TemperatureSum = TemperatureSum + weatherDate.Temperature;
        }

        double ?TemperatureAverage = TemperatureSum / weatherData.Count; 
        Console.WriteLine($"the Temperature Average is: {TemperatureAverage}");
    }

    public void GetMaximumMeasurement()
    {
        
    }   
    public void GetMinimumMeasurement()
    {
        
    }
    
    public (int?, string?, double?) GetHighestTemperature()
    {
        int ?NumberOfMeasuringStationForHighestTemperature = 0;
        string ?DateOfHighestTemperature = "";
        double ?HighestTemperature = 0;
        
        foreach (var Measurement in Measurements)
        {
            double ?currentTemperature = Measurement.Temperature;
            if (currentTemperature > HighestTemperature)
            {
                NumberOfMeasuringStationForHighestTemperature = Measurement.MeasuringStationNumber;
                DateOfHighestTemperature = Measurement.DateOfMeasurement;
                HighestTemperature = currentTemperature;
            }
        }
        return (NumberOfMeasuringStationForHighestTemperature, DateOfHighestTemperature, HighestTemperature);
    }
}