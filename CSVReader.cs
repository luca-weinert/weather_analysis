﻿using System.Globalization;

namespace weather_analysis;

public class CSVReader
{
    public CSVReader()
    {
        
    }
    
    public List<Measurement> ReadCSV(string fileName)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        var reader = new StreamReader(path);
        List<Measurement> measurements = new List<Measurement>();
        
        string line;
        // ignore the first line (header)
        reader.ReadLine();
        
        while ((line = reader.ReadLine()) != null)
        {
            string[] csvLineValues = line.Split(",");
            
                if (csvLineValues.Length == 14)
                {
                    try
                    {
                        var measurement = new Measurement()
                        {
                            MeasuringStationNumber = Convert.ToInt32(csvLineValues[0]),
                            DateOfMeasurement = csvLineValues[1],
                            SunshineHours = float.Parse(csvLineValues[10],CultureInfo.InvariantCulture.NumberFormat),
                            Temperature = float.Parse(csvLineValues[5], CultureInfo.InvariantCulture.NumberFormat),
                            RainAmount = float.Parse(csvLineValues[12], CultureInfo.InvariantCulture.NumberFormat),
                        };
                        measurements.Add(measurement);
                    }
                    catch (FormatException exception)
                    {
                        Console.WriteLine($"error parsing line: {line}. Exception: {exception.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Incomplete data line (length {csvLineValues.Length}): line: {line}");
                }
        }
            
        foreach (var measurement in measurements)
        {
            Console.WriteLine($"MeasuringStationNumber: {measurement.MeasuringStationNumber} | DateOfMeasurement: {measurement.DateOfMeasurement} | SunshineHours: {measurement.SunshineHours} | Temperature: {measurement.Temperature} | RainAmount: {measurement.RainAmount}");
        }

        return measurements;
    }
}