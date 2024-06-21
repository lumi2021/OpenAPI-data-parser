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

            // compile models
            _compilationRoot.namespaces.Add(new Namespace("Models"));
            foreach (var i in _root.Components.Schemas)
                GenerateModel(i);
            
        }


        private static void GenerateModel(Schema schema)
        {

            ClassType model = new(schema.Name);

            foreach (var prop in schema.Properties)
            {
                Console.WriteLine(prop.Name);
            }


            _compilationRoot["Models"].models.Add(model);
        }

    }
}
