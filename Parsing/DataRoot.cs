﻿using ExtractInfoOpenApi.OAStructs.Schemes;
using Newtonsoft.Json.Linq;

namespace ExtractInfoOpenApi.OAStructs
{
    public class DataRoot
    {
        private DataRoot() {}

        public List<Path> Paths { get; private set; } = new();
        public ComponentsData Components { get; private set; } = new();

        public static DataRoot CreateFromJson(string json)
        {
            try
            {
                JObject jsonObj = JObject.Parse(json);

                DataRoot root = new();

                // Desserializing paths
                JObject paths = jsonObj["paths"]!.Value<JObject>()!;
                int pathsParsed = 0;

                (int left, int top) = Console.GetCursorPosition();

                foreach (var path in paths)
                {
                    LogPathStatus(left, top, pathsParsed, paths.Count, path.Key);

                    Path pathObj = new(path.Key);

                    foreach (var item in (path.Value as JObject)!)
                    {
                        // Aqui, cada item é um verbo.

                        Verbo verbo = Verbo.CreateVerbo(item.Key, (item.Value as JObject)!);
                        pathObj.AddVerbo(verbo);
                    }

                    root.Paths.Add(pathObj);
                    pathsParsed++;
                }

                // Desserializing components
                root.Components = new();

                JObject components = jsonObj["components"]!.Value<JObject>()!;

                JObject? schemas = components["schemas"]?.Value<JObject>()! ?? null;
                if (schemas != null)
                {
                    int schemasParsed = 0;

                    (left, top) = Console.GetCursorPosition();

                    foreach (var schema in schemas)
                    {
                        LogSchemaStatus(left, top, schemasParsed, schemas.Count, schema.Key);

                        Schema newSchema = new()
                        {
                            Name = schema.Key,
                            Type = schema.Value!["type"]!.Value<string>()!
                        };

                        if (schema.Value["properties"] != null)
                        {
                            JObject propList = (schema.Value["properties"]! as JObject)!;
                            foreach (var p in propList)
                            {
                                var property = new Schema.Property
                                {
                                    Name = p.Key,

                                    Type = TypeHandler.CreateType((p.Value as JObject)!)
                                };

                                newSchema.Properties.Add(property);
                            }
                        }

                        root.Components.AddSchema(newSchema);
                        schemasParsed++;
                    }

                    Console.SetCursorPosition(left, top);
                    Console.Write(new String(' ', Console.WindowWidth * 5));
                    Console.SetCursorPosition(left, top);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Parsing schemas Finished.");
                    Console.ResetColor();

                }

                return root;
            }

            catch
            {
                // Qualquer erro aqui indica que o json é inválido
                Console.WriteLine("Invalid JSON data input!");
                throw;
            }

        }

        private static void LogPathStatus(int left, int top, int pathsParsed, int pathsCount, string path)
        {
            Console.SetCursorPosition(left, top);
            Console.Write($"processing ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{pathsParsed}/{pathsCount}]");

            Console.ResetColor();
            Console.Write(new String(' ', Console.WindowWidth * 3));
            Console.SetCursorPosition(left, top + 1);
            Console.Write($"Parsing ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\"{path}\"");
            Console.ResetColor();
            Console.WriteLine("...");
        }
        private static void LogSchemaStatus(int left, int top, int schemasParsed, int schemasCount, string schemaName)
        {
            Console.SetCursorPosition(left, top);
            Console.Write($"processing ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{schemasParsed}/{schemasCount}]");

            Console.ResetColor();
            Console.Write(new String(' ', Console.WindowWidth * 3));
            Console.SetCursorPosition(left, top + 1);
            Console.Write($"Parsing ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\"{schemaName}\"");
            Console.ResetColor();
            Console.WriteLine("...");
        }



        public class Path
        {
            public Path(string url) => this.url = url;

            public readonly string url;
            private List<Verbo> _verbos = new();
            public Verbo[] Verbos => _verbos.ToArray();

            public void AddVerbo(Verbo verbo) => _verbos.Add(verbo);
        }
        public class ComponentsData
        {

            private List<Schema> _schemas = new();
            private List<SecurityScheme> _securitySchemes = new();

            public Schema[] Schemas => _schemas.ToArray();
            public SecurityScheme[] SecuritySchemes => _securitySchemes.ToArray();

            public void AddSchema(Schema schema) => _schemas.Add(schema);
            public void AddSecScheme(SecurityScheme secScheme) => _securitySchemes.Add(secScheme);
        }

    }
}
