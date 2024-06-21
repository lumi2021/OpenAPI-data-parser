using Newtonsoft.Json.Linq;

namespace ExtractInfoOpenApi.OAStructs.Schemes
{
    public class Schema
    {

        public string Type { get; set; }
        public string Name { get; set; }

        public List<Property> Properties { get; set; } = [];


        public struct Property
        {
            public string Name { set; get; }
            public IType Type { set; get; }
            public bool Nullable { get; set; }
        }
    }
    
    public class SecurityScheme
    {

    }


    public interface IType {}

    public struct PrimitiveType(string val) : IType
    {
        public readonly string value = val;
    }
    public struct ListType(IType type) : IType
    {
        public readonly IType type = type;
    }
    public struct ReferenceType(string _ref) : IType
    {
        public readonly string reference = _ref;
    }


    public static class TypeHandler
    {

        public static IType CreateType(JObject prop)
        {
            if (prop["type"] != null)
            {
                string type = prop["type"]!.Value<string>()!;

                if (type == "array") return new ListType(CreateType((prop["items"] as JObject)!));

                else return new PrimitiveType(prop["format"]?.Value<string>() ?? type);

            }

            else if (prop["$ref"] != null)
            {
                return new ReferenceType(prop["$ref"]?.Value<string>()!);
            }

            return null!;
        }

    }
}
