using ExtractInfoOpenApi.Util.Typing;
using Newtonsoft.Json.Linq;

namespace ExtractInfoOpenApi.OAStructs
{
    public class Parameter
    {

        public string Name { get; set; } = null!;
        public IType Type { get; set; } = null!;
        public string ParamKind { get; set; } = "";

        public Parameter(JToken data)
        {
            Name = data["name"]!.Value<string>()!;

            var schema = data["schema"]!;

            var fine = false;
            while(!fine)
            {
                fine = true;

                if (schema["type"] != null)
                {
                    var t = schema["type"]!.Value<string>()!;

                    if (t == "Array" || t == "Object")
                        Type = null!;
                    
                    else if (t == "integer") {
                        Type = new PrimitiveType(schema["format"]!.Value<string>()!,
                        !(data["required"]?.Value<bool>() ?? false));
                    }

                    else
                        Type = new PrimitiveType(t, !(data["required"]?.Value<bool>() ?? false));
                }

                // verify the reference
                if (schema["$ref"] != null)
                {
                    Type = new ReferenceType(schema["$ref"]!.Value<string>()!,
                    !(data["required"]?.Value<bool>() ?? false));
                }
            }

            ParamKind = data["in"]?.Value<string>() ?? "";
        }

    }
}
