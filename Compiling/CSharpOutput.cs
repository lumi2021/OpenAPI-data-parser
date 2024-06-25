using ExtractInfoOpenApi.Compiling.Structs;
using ExtractInfoOpenApi.Writing;
using System.Text;

namespace ExtractInfoOpenApi.Compiling
{
    internal class CSharpOutput : Writer
    {
        public override void Write(CompRoot root)
        {

            string tempPath = "../../../";
            string outputPath = $"{tempPath}/out/";

            string namespaceRoot = "Program";

            Console.Write("Saving in ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\"{Path.GetFullPath(outputPath)}\"");
            Console.ResetColor();
            Console.WriteLine("...");

            StringBuilder buffer = new();

            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);

            if (root.TryGetNamespace("Models", out var modelsNamespace))
            {

                if (!Directory.Exists($"{outputPath}/Models/"))
                    Directory.CreateDirectory($"{outputPath}/Models/");

                foreach (var i in modelsNamespace.models)
                {
                    buffer.Clear();

                    buffer.AppendLine($"namespace {namespaceRoot}.Models\n{{");

                    buffer.AppendLine($"\tinternal class {i.name}\n\t{{");
                    buffer.AppendLine("\t}");

                    buffer.AppendLine("}");

                    File.WriteAllText($"{outputPath}/Models/{i.name}.cs", buffer.ToString());

                }
            }

        }
    }
}
