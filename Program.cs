using ExtractInfoOpenApi.Compiling;
using ExtractInfoOpenApi.OAStructs;
using ExtractInfoOpenApi.Writing;

Console.WriteLine("Starting process...");

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
