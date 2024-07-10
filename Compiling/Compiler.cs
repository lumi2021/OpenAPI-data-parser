using ExtractInfoOpenApi.Compiling.Structs;
using ExtractInfoOpenApi.OAStructs;
using ExtractInfoOpenApi.OAStructs.Schemes;
using ExtractInfoOpenApi.Util.Typing;
using System.Globalization;
using System.Text;

namespace ExtractInfoOpenApi.Compiling
{
    public static class Compiler
    {

        private static DataRoot? _root = null;
        private static CompRoot _compilationRoot = null!;

        public static void FeedSource(DataRoot data)
        {
            _root = data;
            _compilationRoot = null!;
        }

        public static void Compile()
        {
            if (_root == null) throw new InvalidOperationException("No data feeded!");
            _compilationRoot = new();

            Dictionary<string, List<(DataRoot.Path path, Verbo verbo)>> services = [];

            // compile schemas into class structures
            foreach (var i in _root.Components.Schemas)
            {
                GenerateModel(i);
            }
        
            // iterate though the path lists to process the contracts kinds
            foreach (var i in _root.Paths)
            {
                foreach (var verbo in i.Verbos)
                {

                    string controllerKey = TitleCase2CamelCase(RemoveDiacritics(verbo.tags[0]));

                    if (!services.ContainsKey(controllerKey))
                        services.Add(controllerKey, []);

                    services[controllerKey].Add((i, verbo));

                    var responses = verbo.responses;
                    foreach (var j in responses.Content)
                    {

                        if (j.content.contentType == Content.ContentType.Reference)
                        {
                            string key = j.content.reference[2 ..];

                            ClassType responseSchema = _compilationRoot.allContracts[key];

                            if (!_compilationRoot.contracts_Response.Contains(responseSchema))
                                _compilationRoot.contracts_Response.Add(responseSchema);
                        }
                    }

                    if (verbo.nomeVerbo == "post" || verbo.nomeVerbo == "put")
                    {

                        if (verbo.requestBody != null && verbo.requestBody.contentType == Content.ContentType.Reference)
                        {
                            string key = verbo.requestBody.reference[2..];

                            ClassType requestSchema = _compilationRoot.allContracts[key];

                            if (!_compilationRoot.contracts_Request.Contains(requestSchema))
                                _compilationRoot.contracts_Request.Add(requestSchema);
                        }

                    }

                }
            }
        
            // iterate though services to build the classes and methods
            foreach (var i in services)
            {
                string controllerName = i.Key;

                var controller = new ClassType(controllerName);

                foreach (var routes in i.Value)
                {
                    var method = new Method {
                        name = GetRouteMethodNameFromUrl(routes.path.url)};

                    var paths = routes.path.url.Split("/");
                    foreach (var path in paths)
                    {
                        if (path.StartsWith('{') && path.EndsWith('}'))
                        {
                            var pName = path[1..^1];
                            var p = routes.verbo.parameters.FirstOrDefault(e => e.Name == pName)
                            ?? routes.verbo.parameters.First(e => e.Name.Equals(pName, StringComparison.CurrentCultureIgnoreCase));

                            method.parametes.Add(new(p.Name, p.Type));
                        }
                    }

                    method.additionalAttributes.Add("requestMethod", routes.verbo.nomeVerbo.ToLower());
                    method.additionalAttributes.Add("route", routes.path.url);

                    var responseMethod = routes.verbo.responses[200].content;
                    if (responseMethod.contentType == Content.ContentType.Reference)
                    {
                        method.returnType = new ReferenceType(responseMethod.reference, false);
                    }

                    controller.methods.Add(method);
                }

                _compilationRoot.Controllers.Add(controller);
            }
        }

        public static CompRoot Emit() => _compilationRoot;

        private static void GenerateModel(Schema schema)
        {

            ClassType model = new(schema.Name);

            foreach (var prop in schema.Properties)
            {
                model.properties.Add(new(prop.Name, prop.Type));
            }


            _compilationRoot.allContracts.Add($"components/schemas/{model.name}", model);
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
        private static string TitleCase2CamelCase(string text)
        {
            var splited = text.Split((char[])[' ', '_'], StringSplitOptions.RemoveEmptyEntries);
            var processed = splited.Select(x => char.ToUpper(x[0]) + x[1..]).ToArray();
            return string.Join(string.Empty, processed)
            .Replace('-', '_')
            .Replace('/', '_')
            .Replace('\\', '_');
        }
    
        private static string GetRouteMethodNameFromUrl(string url)
        {

            var splited = url.Split("/")[1..];
            var rightBase = splited.Length - 1;

            while (splited[rightBase].StartsWith('{')) rightBase--;

            splited = splited[(Math.Max(rightBase - 3, 1))..(rightBase + 1)];

            return string.Join("", splited.Select(e => char.ToUpper(e[0]) + e[1..]));
        }
    }
}
