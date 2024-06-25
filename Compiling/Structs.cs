using ExtractInfoOpenApi.Util.Typing;

namespace ExtractInfoOpenApi.Compiling.Structs
{

    public class CompRoot
    {

        public List<Namespace> namespaces = [];

        public Namespace this[string ident]
        {
            get
            {

                string[] idents = ident.Split('.');

                var ns = namespaces.FirstOrDefault(e => e.name == idents[0]);

                if (idents.Length > 1) return ns![string.Join('.', idents[1..])]!;
                else return ns!;

            }
        }

        public bool TryGetNamespace(string ident, out Namespace ns)
        {
            var namespaceRef = this[ident];
            ns = namespaceRef;

            return namespaceRef != null;
        }

    }

    public class Namespace(string name)
    {

        public string name = name;

        public List<Namespace> namespaces = [];
        public List<ClassType> models = [];

        public Namespace this[string ident]
        {
            get
            {

                string[] idents = ident.Split('.');

                var ns = namespaces.FirstOrDefault(e => e.name == idents[0]);

                if (idents.Length > 1) return ns![string.Join('.', idents[1..])]!;
                else return ns!;

            }
        }

        public bool TryGetNamespace(string ident, out Namespace ns)
        {
            var namespaceRef = this[ident];
            ns = namespaceRef;

            return namespaceRef != null;
        }
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
