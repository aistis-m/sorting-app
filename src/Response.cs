class Response{
    public string input { get; set; }
    public SortResult[] results { get; set; }

    public Response(string input,SortResult[] results){
        this.input = input;
        this.results = results;
    }
}