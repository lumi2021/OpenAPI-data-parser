using Newtonsoft.Json.Linq;

namespace ExtractInfoOpenApi.OAStructs
{
    public class Content
    {
        public string valueKind;

        public ContentType contentType;
        public string reference;

        public Content(JToken tkn)
        {
            var kind = tkn.Children<JProperty>().ToArray()[0] ?? throw new InvalidDataException();
            valueKind = kind.Name;

            var schema = kind.Value["schema"]!;

            // verify the type
            if (schema["type"] != null)
            {
                if (schema["type"]!.Value<string>() == "Array")
                {
                    contentType = ContentType.Array;
                    schema = schema["items"]!;
                }
                
                else if (schema["type"]!.Value<string>() == "Object")
                    contentType = ContentType.Object;
            }

            // verify the reference
            if (schema["$ref"] != null)
            {
                contentType = ContentType.Reference;
                reference = schema["$ref"]!.Value<string>()!;
            }

            else reference = "";
        }

        public enum ContentType
        {
            Object,
            Array,
            Reference
        };
    }
}
