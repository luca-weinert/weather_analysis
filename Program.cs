﻿using weather_analysis;

class Program
{

    
    public static void Main(string[] args)
    {
        var CSVReader = new CSVReader();
        var MeasurementController = new MeasurementController();
        MeasurementController.Measurements = CSVReader.ReadCSV("weatherData.csv");
        var (NumberOfMeasuringStation, DateOfMeasuring, Temperature) = MeasurementController.GetHighestTemperature();
        Console.WriteLine($"the highest temperature ist {Temperature} measured from the station {NumberOfMeasuringStation} on {DateOfMeasuring}");
        /*GetAverageTemperature(weatherData);*/
    }
}