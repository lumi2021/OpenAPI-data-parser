using ExtractInfoOpenApi.Compiling.Structs;
using ExtractInfoOpenApi.OAStructs;
using ExtractInfoOpenApi.OAStructs.Schemes;
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

            Dictionary<string, List<(DataRoot.Path, Verbo)>> controllers = [];

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

                    if (!controllers.ContainsKey(controllerKey))
                        controllers.Add(controllerKey, []);

                    controllers[controllerKey].Add((i, verbo));

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
        
            // iterate though controllers to build the classes and methods
            foreach (var i in controllers)
            {
                string controllerName = i.Key;

                var controller = new ClassType(controllerName);

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
            return string.Join(string.Empty, processed).Replace('/', '_').Replace('\\', '_');
        }
    }
}
