using GamesTournamentsWeb.Common.Extensions;

namespace GamesTournamentsWeb.Common.Helpers;

public static class EnumHelper
{
    public class EnumInfo(int value, string name, Attribute attribute)
    {
        public int Value { get; set; } = value;
        public string Name { get; set; } = name;
        public Attribute Attribute { get; set; } = attribute;
    }
    
    public static IList<T> SelectTo<R, T>(Func<EnumInfo, T> map, Type attributeType = null)
        where R : struct, Enum
    {
        var values = Enum.GetValues<R>();

        return values
            .Select(value =>
            {
                var info = new EnumInfo(
                    Convert.ToInt32(value),
                    Enum.GetName(typeof(R), value),
                    attributeType != null ? value.GetAttribute(attributeType) : null);
                return map(info);
            })
            .ToList();
    }
}