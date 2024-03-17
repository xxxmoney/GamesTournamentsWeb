using System.ComponentModel;
using System.Reflection;

namespace GamesTournamentsWeb.Common.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var attribute = value.GetAttribute<DescriptionAttribute>();
        return attribute == null ? value.ToString() : attribute.Description;
    }
       
    public static R GetAttribute<R>(this Enum enumValue) where R : Attribute
    {
        try
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<R>();
        }
        catch (Exception)
        {
            return null;
        }            
    }
    
    public static Attribute GetAttribute(this Enum enumValue, Type attributeType) 
    {
        try
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute(attributeType);
        }
        catch (Exception)
        {
            return null;
        }            
    }
}