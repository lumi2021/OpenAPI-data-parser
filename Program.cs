using ExtractInfoOpenApi.Compiling;
using ExtractInfoOpenApi.OAStructs;
using ExtractInfoOpenApi.Writing;

Console.WriteLine("OpenAPI data parser ver. 1.0.0");

/*
Console.WriteLine("Please give the path and name of the desired JSON file:");

(int Left, int Top) ccorigin = Console.GetCursorPosition();
(int Left, int Top) ccbottom = (ccorigin.Left, ccorigin.Top + 1);

while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.SetCursorPosition(ccorigin.Left, ccorigin.Top);
    Console.WriteLine(Path.GetFullPath("./"));
    Console.ResetColor();

    Console.SetCursorPosition(ccbottom.Left, ccbottom.Top);
    Console.Write("> ");
    string prompt = Console.ReadLine() ?? "";


    if (Path.IsPathFullyQualified(prompt) && Directory.Exists(prompt))
    {
        Console.WriteLine(Path.GetFullPath(prompt));
        Directory.SetCurrentDirectory(Path.GetFullPath(prompt));
    }

    ccbottom = Console.GetCursorPosition();
}
*/

var jsonTxt = File.ReadAllText("jsonApibigdata.txt");
Console.WriteLine("Target file found.");

Console.WriteLine("Starting parsing...");
DataRoot obj = DataRoot.CreateFromJson(jsonTxt);

Console.WriteLine("Starting compiling...");
Compiler.FeedSource(obj);
Compiler.Compile();

Console.WriteLine("Starting writing...");
Writer writer = new CSharpOutput();
writer.Write(Compiler.Emit());

Console.WriteLine("\nProcess finished.\nPress any key to close the window.");
Console.ReadKey(true);
