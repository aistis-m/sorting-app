using System;
namespace SortAPI
{
    public class SortResult
    {
        public string algo { get; set; }
        public double elapsedms { get; set; }
        public string sorted { get; set; }

        public SortResult(string algo, double elapsedms, string sorted)
        {
            this.algo = algo;
            this.elapsedms = elapsedms;
            this.sorted = sorted;
        }

    }
}

