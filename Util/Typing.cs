namespace ExtractInfoOpenApi.Util.Typing
{
    public interface IType
    {
        public bool Nullable { get; set; }
    }

    public struct PrimitiveType(string val, bool nullable) : IType
    {
        public readonly string value = val;
        public bool Nullable { get; set; } = nullable;
    }
    public struct ListType(IType type, bool nullable) : IType
    {
        public readonly IType type = type;
        public bool Nullable { get; set; } = nullable;
    }
    public struct ReferenceType(string _ref, bool nullable) : IType
    {
        public readonly string reference = _ref;
        public bool Nullable { get; set; } = nullable;
    }

}
