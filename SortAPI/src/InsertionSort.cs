using System;
namespace SortAPI
{
    public class InsertionSort : ISortingAlgo
    {
        public string Name { get; set; } = "insertion";
        public int[] Sort(int[] numbers)
        {
            int[] NumArray = numbers;

            for (int i = 0; i < NumArray.Count(); i++)
            {
                var item = NumArray[i];
                var currentIndex = i;
                while (currentIndex > 0 && NumArray[currentIndex - 1] > item)
                {
                    NumArray[currentIndex] = NumArray[currentIndex - 1];
                    currentIndex--;
                }
                NumArray[currentIndex] = item;
            }

            return NumArray;
        }
    }
}

