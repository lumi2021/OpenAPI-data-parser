using ExtractInfoOpenApi.Compiling.Structs;
using ExtractInfoOpenApi.Util.Typing;
using ExtractInfoOpenApi.Writing;
using System.Text;

namespace ExtractInfoOpenApi.Compiling
{
    internal class CSharpOutput : Writer
    {

        readonly StringBuilder buffer = new();
        readonly Queue<(string key, string value)> url_constants = [];

        public override void Write(CompRoot root, string namespaceRoot)
        {

            string tempPath = "../../../";
            string outputPath = $"{tempPath}/out-cs/";

            Console.Write("Saving in ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\"{Path.GetFullPath(outputPath)}\"");
            Console.ResetColor();
            Console.WriteLine("...");

            buffer.Clear();

            if (Directory.Exists(outputPath))
                Directory.Delete(outputPath, true);

            Directory.CreateDirectory(outputPath);

            if (!Directory.Exists($"{outputPath}/Services/"))
                Directory.CreateDirectory($"{outputPath}/Services/");
            
            if (!Directory.Exists($"{outputPath}/Contracts/Request/"))
                Directory.CreateDirectory($"{outputPath}/Contracts/Request/");
            if (!Directory.Exists($"{outputPath}/Contracts/Response/"))
                Directory.CreateDirectory($"{outputPath}/Contracts/Response/");

            foreach (var i in root.contracts_Request)
            {
                buffer.Clear();

                WriteModelInBuffer(root, i, $"{namespaceRoot}.Contracts.Request");

                File.WriteAllText($"{outputPath}/Contracts/Request/{i.name}.cs", buffer.ToString().Replace("\t", "    "));

            }
            
            foreach (var i in root.contracts_Response)
            {
                buffer.Clear();

                WriteModelInBuffer(root, i, $"{namespaceRoot}.Contracts.Response");

                File.WriteAllText($"{outputPath}/Contracts/Response/{i.name}.cs", buffer.ToString().Replace("\t", "    "));

            }
        
            foreach (var i in root.Controllers)
            {
                buffer.Clear();

                WriteServiceInBuffer(root, i, $"{namespaceRoot}.Services");

                File.WriteAllText($"{outputPath}/Services/{i.name}.cs", buffer.ToString().Replace("\t", "    "));
            }

            buffer.Clear();
            WriteConstantsInBuffer(root, $"{namespaceRoot}.Services");
            File.WriteAllText($"{outputPath}/Services/Constants.cs", buffer.ToString().Replace("\t", "    "));

        }

        private void WriteModelInBuffer(CompRoot root, ClassType model, string namespaceString)
        {
            buffer.AppendLine($"namespace {namespaceString}\n{{");

            buffer.AppendLine($"\tpublic class {model.name}\n\t{{");

            // Write properties
            foreach (var prop in model.properties)
            {

                string type = GetAsCsharpType(prop.type, root);
                buffer.AppendLine($"\t\tpublic {type} {prop.name} {{ get; set; }}");

            }

            buffer.AppendLine("\t}");

            buffer.AppendLine("}");
        }

        private void WriteServiceInBuffer(CompRoot root, ClassType ctrl, string namespaceString)
        {
            buffer.AppendLine($"namespace {namespaceString}\n{{");

            buffer.AppendLine($"\tpublic class {ctrl.name}Service\n\t{{");

            buffer.AppendLine();

            foreach (var i in ctrl.methods)
            {
                var method = i.additionalAttributes["requestMethod"];
                var route = i.additionalAttributes["route"];

                buffer.Append($"\t\tpublic ");

                buffer.Append(GetAsCsharpType(i.returnType, root));

                buffer.Append($" {i.name}{method.ToUpper()}(");

                buffer.Append(string.Join(", ",
                    i.parametes.Select(e => $"{GetAsCsharpType(e.type, root)} {e.name}")));

                buffer.AppendLine(")\n\t\t{");

                buffer.AppendLine("\t\t\t/*");
                buffer.AppendLine($"\t\t\t* method: {method.ToUpper()}");
                buffer.AppendLine($"\t\t\t* url: {route}");
                buffer.AppendLine("\t\t\t*/");

                var paths = route.Split("/")[1..];

                StringBuilder path = new();
                List<string> args = [];

                foreach (var p in paths)
                {
                    if (p.StartsWith('{') && p.EndsWith('}'))
                    {
                        string paramName = p[1..^1];
                        var param = i.parametes.Where(e => e.kind == Parameter.ParameterKind.Path)
                            .FirstOrDefault(e => e.name == paramName);

                        if (param != null)
                        {
                            args.Add(param.name);
                            path.Append($"/{{{args.Count-1}}}");
                        }

                        else path.Append("/undefined");

                    }
                    else path.Append($"/{p}");
                }

                var constantName = $"url_{ctrl.name}{i.name}{method.ToUpper()}";
                url_constants.Enqueue((constantName, path.ToString()));

                buffer.Append($"\t\t\tUriBuilder url = new(Constants.{constantName});");

                foreach (var q in i.parametes.Where(e => e.kind == Parameter.ParameterKind.Query))
                {
                    if (q.type.Nullable && q.type is PrimitiveType @p)
                    {
                        if (p.value == "string")
                        {
                            buffer.Append($"\t\t\tif ({q.name} != null) ");
                            buffer.AppendLine($"url += $\"{q.name}={{{q.name}}}&\";");
                        }
                    }

                    else if (q.type.Nullable)
                    {
                        buffer.Append($"\t\t\tif ({q.name}.HasValue) ");
                        buffer.AppendLine($"url += $\"{q.name}={{{q.name}.Value}}&\";");
                    }

                    else buffer.AppendLine($"\t\t\turl += $\"{q.name}={{{q.name}}}&\";");

                }

                buffer.AppendLine("\n\t\t\tthrow new NotImplementedException();");
                buffer.AppendLine("\t\t}");

                buffer.AppendLine();

            }

            buffer.AppendLine("\t}");
            buffer.AppendLine("}");
        }

        private void WriteConstantsInBuffer(CompRoot root, string namespaceString)
        {
            buffer.AppendLine($"namespace {namespaceString}\n{{");

            buffer.AppendLine($"\tpublic static class Constants\n\t{{");

            foreach(var i in url_constants)
                buffer.AppendLine($"\t\tpublic static readonly {i.key} = \"{i.value}\";");

            buffer.AppendLine("\t}");
            buffer.AppendLine("}");
        }

        private static string GetAsCsharpType(IType typeRef, CompRoot root)
        {
            if (typeRef is PrimitiveType @primitive)
                return GetPrimitiveType(primitive.value) + (primitive.Nullable ? "?" : "");

            else if (typeRef is ReferenceType @ref)
                return root.allContracts[@ref.reference[2 ..]].name + (@ref.Nullable ? "?" : "");

            else if (typeRef is ListType @list)
                return $"List<{GetAsCsharpType(list.type, root)}>" + (list.Nullable ? "?" : "");

            return "void";
        }

        private static string GetPrimitiveType(string typeName)
            => typeName switch
            {
                "int8" => "byte",
                "int16" => "short",
                "int32" => "int",
                "int64" => "long",
                "boolean" => "bool",

                //"uuid" => typeof(Guid).Name,
                "date-time" => typeof(DateTime).Name,

                _ => typeName
            };

    }
}
