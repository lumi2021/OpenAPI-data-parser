using ExtractInfoOpenApi.Compiling.Structs;

namespace ExtractInfoOpenApi.Writing
{
    public abstract class Writer
    {

        public abstract void Write(CompRoot stream, string namespaceBase);

    }
}
