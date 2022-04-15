using System.Linq;

public class BubbleSort : ISortingAlgo
{   
    public string Name {get;set;} = "bubble";
    public int[] Sort(int[] numbers)
    {
        int[] NumArray = numbers;
        var itemMoved = false;
        do
        {
            itemMoved = false;
            for (int i = 0; i < NumArray.Count() - 1; i++)
            {
                if (NumArray[i] > NumArray[i + 1])
                {
                    var lowerValue = NumArray[i + 1];
                    NumArray[i + 1] = NumArray[i];
                    NumArray[i] = lowerValue;
                    itemMoved = true;
                }
            }
        } while (itemMoved);
        return NumArray;
    }
}