using System;
using System.Diagnostics;

namespace SortAPI
{
    public class Sorter
    {

        private int[] numbers;

        public Sorter(int[] numbers)
        {
            this.numbers = numbers;
        }

        public Task<SortResult> RunAlgorithm(ISortingAlgo algo)
        {
            return Task.Run(() =>
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                int[] result = algo.Sort(numbers);

                stopwatch.Stop();

                double time = stopwatch.Elapsed.TotalMilliseconds;
                string sorted = string.Join(" ", result);

                return new SortResult(algo.Name, time, sorted);
            });
        }
    }

}

