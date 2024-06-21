namespace ExtractInfoOpenApi.OAStructs
{
    public class Responses
    {
        private List<HttpResponse> _responses = new();
        public HttpResponse[] Content => _responses.ToArray();

        // TODO indexing operator

        public void AddResponse(HttpResponse response)
        {
            _responses.Add(response);
        }
    }

    public class HttpResponse
    {
        public string response { get; set; }
        public string description { get; set; }
        public Content content { get; set; }
    }
}
