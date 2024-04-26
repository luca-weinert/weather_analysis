namespace weather_analysis;

public class MeasurementController
{
    public List<Measurement> Measurements { get; set; }
    
    public MeasurementController()
    {
    }

    public void GetLowestTemperature()
    {
        double LowestTemperature = 0;
        
        foreach (var Measurement in Measurements)
        {
            if (LowestTemperature >= Measurement.Temperature)
            {
                LowestTemperature = Measurement.Temperature;
            }
        }
        
        Console.WriteLine($"the lowest Temperature is: {LowestTemperature}");
    }
    
    public void GetAverageTemperature()
    {
        double ?TemperatureSum = 0; 
        
        foreach (var Measurement in Measurements)
        {
            TemperatureSum = TemperatureSum + Measurement.Temperature;
        }

        double ?TemperatureAverage = TemperatureSum / Measurements.Count; 
        Console.WriteLine($"the Temperature Average is: {TemperatureAverage}");
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

    public int[] Sort(int[] array)
    {
        // use bubble Sort

        var n = array.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1 ; j++)
            {
                if (array[j] > array[j + 1])
                {
                    var tempVar = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = tempVar;
                }
            }
        }
        
        return array;
    } 
}