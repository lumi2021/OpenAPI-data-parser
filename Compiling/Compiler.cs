using ExtractInfoOpenApi.Compiling.Structs;
using ExtractInfoOpenApi.OAStructs;
using ExtractInfoOpenApi.OAStructs.Schemes;

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

    }
}
