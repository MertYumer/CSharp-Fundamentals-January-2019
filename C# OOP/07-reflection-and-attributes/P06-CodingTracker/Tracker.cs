using System;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type classType = typeof(StartUp);
        var methods = classType.GetMethods(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.Static);

        foreach (var method in methods)
        {
            var attribute = method.GetCustomAttribute<AuthorAttribute>();

            if (attribute != null)
            {
                Console.WriteLine($"{method.Name} is written by {attribute.Name}");
            }
        }
    }
}
