using ExtractInfoOpenApi.Compiling;
using ExtractInfoOpenApi.OAStructs;
using ExtractInfoOpenApi.Writing;

Console.WriteLine("OpenAPI data parser ver. 1.0.0");

Console.WriteLine("Please give the path and name of the desired JSON file:");

(int Left, int Top) = Console.GetCursorPosition();
(int Left, int Top) ccbottom = (Left, Top + 1);
string path = Path.GetFullPath("./");

while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.SetCursorPosition(Left, Top);
    Console.WriteLine(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(Left, Top);
    Console.WriteLine(path);
    Console.ResetColor();

    Console.SetCursorPosition(ccbottom.Left, ccbottom.Top);
    Console.Write("> ");
    string prompt = Console.ReadLine() ?? "";

    // log current dir
    if (prompt == "./")
    {
        var dirs = Directory.GetDirectories(path);
        var files = Directory.GetFiles(path);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Files in {path}:");
        Console.ResetColor();
        Console.WriteLine(new string('_', Console.WindowWidth));

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t...");
        foreach (var i in dirs) Console.WriteLine('\t' + i.Split(['\\', '/'])[^1] + '\\');

        Console.ForegroundColor = ConsoleColor.Cyan;
        foreach (var i in files) Console.WriteLine('\t' + i.Split(['\\', '/'])[^1]);

        Console.ResetColor();
        Console.WriteLine(new string('_', Console.WindowWidth));
    }

    // if rooted
    if (Path.IsPathRooted(prompt))
    {
        if (File.Exists(prompt))
        {
            path = Path.GetFullPath(prompt + "./");
            break;
        }
        else if (Directory.Exists(prompt))
        {
            path = Path.GetFullPath(prompt + "./");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\"{prompt}\" not found in disk.");
            Console.ResetColor();
        }
    }

    // if relative
    else
    {
        if (File.Exists(path + prompt))
        {
            path = Path.GetFullPath(path + prompt + "./");
            break;
        }
        else if (Directory.Exists(path + prompt))
        {
            path = Path.GetFullPath(path + prompt + "./");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\"{prompt}\" not found in current directory.");
            Console.ResetColor();
        }
    }

    ccbottom = Console.GetCursorPosition();
}

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
