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
        var measurementsCount = Measurements.Count;
        
        // the outer loop controls the current position where the next smallest element should be placed
        // by start it is zero
        for (var i = 0; i < measurementsCount -1 ; i++)
        {
            // holds current index for the smallest value in list
            var indexSmallestVal = i;
            
            // iterates to the unsorted portion of the list, starting from the element right after the current position
            for (var j = i + 1; j < measurementsCount; j++)
            { 
                // checks if the temperature of the current element (j at start 1) is less then
                // the temperature of the element at the index of Smallest Value (at start 0)
                // e.g. if measurement[1] <  measurement[0]
                if (Measurements[j].IsLessThan(Measurements[indexSmallestVal].Temperature))
                {
                    // if true indexSmallestVal value is set to the new index e.g to one
                    indexSmallestVal = j;
                }
            }
            
            // temporarily stores the smallest element found in the current iteration
            var smallestElement = Measurements[indexSmallestVal];
            
            // replace the element at the indexSmallestVal with the element of current position
            Measurements[indexSmallestVal] = Measurements[i];
            
            // place the temporarily stored smallest element into the current position i
            Measurements[i] = smallestElement; 
        }
    }

    private void BubbleSort()
    {
        var measurementsCount = Measurements.Count;

        for (int i = 0; i < measurementsCount -1; i++)
        {
            for (int j = 0; j < measurementsCount - i - 1; j++)
            {
                if(Measurements[j].Temperature > Measurements[j + 1].Temperature)
                {
                    var tempVar = Measurements[j];
                    Measurements[j] = Measurements[j + 1];
                    Measurements[j + 1] = tempVar;
                }
            }
        }
    }
}