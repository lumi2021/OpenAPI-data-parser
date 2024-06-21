using ExtractInfoOpenApi.Compiling;
using ExtractInfoOpenApi.OAStructs;

Console.WriteLine("Starting process...");

var jsonTxt = File.ReadAllText("jsonApibigdata.json");
Console.WriteLine("Target file found.");

Console.WriteLine("Starting parsing...");
DataRoot obj = DataRoot.CreateFromJson(jsonTxt);

Console.WriteLine("Starting compiling...");
Compiler.FeedSource(obj);
Compiler.Compile();

Console.WriteLine("\nProcess finished.\nPress any key to close the window.");
Console.ReadKey(true);
