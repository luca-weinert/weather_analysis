namespace weather_analysis;

public class MeasurementList
{
    public List<Measurement> Measurements;

    public void Sort(SortBy sortBy, SortingWith sortingWith)
    {
        switch(sortingWith)
        {
            case SortingWith.BubbleSort:
            {
                BubbleSort();
                break;
            }
                
            case SortingWith.SelectionSort:
            {
                SelectionSort();
                break;
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(sortingWith), sortingWith, null);
        }
    }

    private void SelectionSort()
    {
        var listLength = Measurements.Count;

        for (var i = 0; i < listLength -1 ; i++)
        {
            var smallestVal = i;

            for (var j = i + 1; j < listLength; j++)
            {
                if (Measurements[j].Temperature < Measurements[smallestVal].Temperature)
                {
                    smallestVal = j;
                }
            }

            var tempVar = Measurements[smallestVal];
            Measurements[smallestVal] = Measurements[i];
            Measurements[i] = tempVar; 
        }
    }

    private void BubbleSort()
    {
        
    }
}