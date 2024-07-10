using ExtractInfoOpenApi.Util.Typing;

namespace ExtractInfoOpenApi.Compiling.Structs
{

    public class CompRoot
    {
        // Contracts
        public readonly List<ClassType> contracts_Request = [];
        public readonly List<ClassType> contracts_Response = [];

        public readonly Dictionary<string, ClassType> allContracts = [];

        // Controllers
        public readonly List<ClassType> Controllers = [];
    }

    public class ClassType(string name)
    {

        public string name = name;
        public List<Property> properties = [];
        public List<Method> methods = [];

    }

    public class Property(string name, IType type)
    {

        public bool publicModfier = false;
        public string name = name;

        public IType type = type;

    }

    public class Method
    {

        public Dictionary<string, string> additionalAttributes = [];
        public IType returnType = null!;
        public string name = "";
        public List<Parameter> parametes = [];

    }

    public struct Parameter (string name, IType type)
    {
        public string name = name;
        public IType type = type;
    }
}
