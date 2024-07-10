using Newtonsoft.Json.Linq;
using ExtractInfoOpenApi.Util.Typing;

namespace ExtractInfoOpenApi.OAStructs.Schemes
{
    public class Schema
    {

        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;

        public List<Property> Properties { get; set; } = [];


        public struct Property
        {
            public string Name { set; get; }
            public IType Type { set; get; }
        }
    }
    
    public class SecurityScheme
    {

    }

    public static class TypeHandler
    {

        public static IType CreateType(JObject prop)
        {
            if (prop["type"] != null)
            {
                string type = prop["type"]!.Value<string>()!;

                if (type == "array") return new ListType(CreateType((prop["items"] as JObject)!),
                    prop["Nullable"]?.Value<bool>() ?? false);

                else return new PrimitiveType(prop["format"]?.Value<string>() ?? type,
                    prop["Nullable"]?.Value<bool>() ?? false);

            }

            else if (prop["$ref"] != null)
            {
                return new ReferenceType(prop["$ref"]?.Value<string>()!,
                    prop["Nullable"]?.Value<bool>() ?? false);
            }

            return null!;
        }

    }
}
