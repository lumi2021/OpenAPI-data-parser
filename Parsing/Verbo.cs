using Newtonsoft.Json.Linq;

namespace ExtractInfoOpenApi.OAStructs
{
    public class Verbo
    {

        private Verbo() {}

        public string nomeVerbo;

        public string[] tags;
        public string operationId;
        public Content requestBody;
        public Responses responses;

        public Parameter[] parameters;


        public static Verbo CreateVerbo(string verboName, JObject verboFields)
        {
            Verbo verbo = new()
            {
                nomeVerbo = verboName,

                tags = (verboFields[nameof(tags)]?.Values<string>().ToArray() as string[])! ?? Array.Empty<string>(),
                operationId = verboFields[nameof(operationId)]?.Value<string>() ?? "",
                requestBody = verboFields[nameof(requestBody)] != null ? new Content(verboFields[nameof(requestBody)]!["content"]!.Value<JObject>()!) : null!,
                responses = ProcessVerboResponses(verboFields[nameof(responses)] as JObject),

                parameters = ProcessVerboParameters(verboFields[nameof(parameters)] as JArray)
            };

            return verbo;
        }

        private static Responses ProcessVerboResponses(JObject? responsesData)
        {
            if (responsesData == null) return null!;

            var responses = new Responses();

            foreach (var i in responsesData.Value<JObject>()!)
            {
                HttpResponse response = new()
                {
                    response = i.Key,
                    description = i.Value!["description"]?.Value<string>() ?? "",
                    content = i.Value["content"] != null ? new Content(i.Value["content"]!.Value<JObject>()!)! : null!
                };

                responses.AddResponse(response);
            }

            return responses;
        }
    
        private static Parameter[] ProcessVerboParameters(JArray? parametersData)
        {
            if (parametersData == null) return Array.Empty<Parameter>();

            List<Parameter> parameters = new();

            foreach (var i in parametersData)
            {
                Parameter parameter = new()
                {
                    Name = i["name"]?.Value<string>() ?? "",
                    In = i["in"]?.Value<string>() ?? "",
                    Required = i["required"]?.Value<bool>() ?? false,
                    //Content = new(i["schema"]!)
                };
                parameters.Add(parameter);
            }

            return Array.Empty<Parameter>();
        }
    }
}
