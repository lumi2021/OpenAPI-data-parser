using ExtractInfoOpenApi.Util.Typing;

namespace ExtractInfoOpenApi.Compiling.Structs
{

    public class CompRoot
    {

        public readonly List<ClassType> contracts_Request = [];
        public readonly List<ClassType> contracts_Response = [];

        public readonly Dictionary<string, ClassType> allContracts = [];
    }

    public class ClassType(string name)
    {

        public string name = name;
        public List<Property> properties = [];

    }

    public class Property(string name, IType type)
    {

        public bool publicModfier = false;
        public string name = name;

        public IType type = type;

    }

    public class Method
    {

    }

}
