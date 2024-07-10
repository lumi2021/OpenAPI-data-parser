namespace ExtractInfoOpenApi.OAStructs
{
    public class Responses
    {
        private List<HttpResponse> _responses = new();
        public HttpResponse[] Content => _responses.ToArray();

        public HttpResponse this[int respCode] => this[$"{respCode}"];
        public HttpResponse this[string respCode] => _responses.Find(e => e.response == respCode)!;

        public void AddResponse(HttpResponse response)
        {
            _responses.Add(response);
        }
    }

    public class HttpResponse
    {
        public string response { get; set; } = null!;
        public string description { get; set; } = null!;
        public Content content { get; set; } = null!;
    }
}
