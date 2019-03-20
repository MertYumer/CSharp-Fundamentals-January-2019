using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        var allMethods = classType.GetMethods(
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Public)
            .Where(m => m.Name.StartsWith("get") || m.Name.StartsWith("set"))
            .OrderBy(m => m.Name.StartsWith("set"));

        var builder = new StringBuilder();

        foreach (var method in allMethods)
        {
            if (method.Name.StartsWith("get"))
            {
                builder.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            else
            {
                builder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
        }

        return builder.ToString().Trim();
    }
}
