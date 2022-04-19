using System;
namespace SortAPI
{
    public interface ISortingAlgo
    {
        string Name { get; set; }
        int[] Sort(int[] numbers);
    }
}

