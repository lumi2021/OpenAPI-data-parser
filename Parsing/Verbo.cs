using Newtonsoft.Json.Linq;

namespace ExtractInfoOpenApi.OAStructs
{
    public class Verbo
    {

        public string nomeVerbo = null!;

        public string[] tags = [];
        public string operationId = null!;
        public Content requestBody = null!;
        public Responses responses = null!;

        public Parameter[] parameters = [];


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
            if (parametersData == null) return [];

            List<Parameter> parameters = [];

            foreach (var i in parametersData)
                parameters.Add(new(i));

            return [.. parameters];
        }
    }
}

