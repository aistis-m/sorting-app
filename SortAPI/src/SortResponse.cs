using System;
namespace SortAPI
{
    public class SortResponse
    {
        public string input { get; set; }
        public SortResult[] results { get; set; }

        public SortResponse(string input, SortResult[] results)
        {
            this.input = input;
            this.results = results;
        }
    }
}

