using ExtractInfoOpenApi.Compiling.Structs;
using ExtractInfoOpenApi.Util.Typing;
using ExtractInfoOpenApi.Writing;
using System.Text;

namespace ExtractInfoOpenApi.Compiling
{
    internal class CSharpOutput : Writer
    {

        readonly StringBuilder buffer = new();

        public override void Write(CompRoot root)
        {

            string tempPath = "../../../";
            string outputPath = $"{tempPath}/out-cs/";

            string namespaceRoot = "Program";

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

        private void WriteServiceInBuffer(CompRoot root, ClassType ctrl,  string namespaceString)
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

                buffer.Append($" {i.name}(");

                buffer.Append(string.Join(", ", i.parametes.Select(e => $"{GetAsCsharpType(e.type, root)} {e.name}")));

                buffer.AppendLine(")\n\t\t{");

                buffer.AppendLine("\t\t\t/*");
                buffer.AppendLine($"\t\t\t* method: {method.ToUpper()}");
                buffer.AppendLine($"\t\t\t* url: {route}");
                buffer.AppendLine("\t\t\t*/");

                buffer.AppendLine("\t\t\tthrow new NotImplementedException();");
                buffer.AppendLine("\t\t}");

                buffer.AppendLine();

            }

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
