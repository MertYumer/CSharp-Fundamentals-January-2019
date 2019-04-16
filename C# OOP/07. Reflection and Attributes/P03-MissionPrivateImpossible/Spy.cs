using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        var builder = new StringBuilder();

        builder.AppendLine($"All Private Methods of Class: {className}");
        builder.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in privateMethods)
        {
            builder.AppendLine(method.Name);
        }

        return builder.ToString().Trim();
    }
}
