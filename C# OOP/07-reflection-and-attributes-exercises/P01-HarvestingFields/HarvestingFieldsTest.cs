namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type classType = typeof(HarvestingFields);

            while (true)
            {
                string command = Console.ReadLine();

                List<FieldInfo> fields = new List<FieldInfo>();

                switch (command)
                {
                    case "protected":
                        fields = classType.GetFields(
                            BindingFlags.NonPublic |
                            BindingFlags.Instance)
                            .Where(f => f.IsFamily)
                            .ToList();
                        break;

                    case "private":
                        fields = classType.GetFields(
                            BindingFlags.NonPublic |
                            BindingFlags.Instance)
                            .Where(f => f.IsPrivate)
                            .ToList();
                        break;

                    case "public":
                        fields = classType.GetFields(
                            BindingFlags.Public |
                            BindingFlags.Instance)
                            .ToList();
                        break;

                    case "all":
                        fields = classType.GetFields(
                            BindingFlags.Public |
                            BindingFlags.Instance |
                            BindingFlags.NonPublic |
                            BindingFlags.Static)
                            .ToList();
                        break;

                    case "HARVEST":
                        return;
                }

                foreach (var field in fields)
                {
                    string accessModifier = 
                        field.IsPublic 
                        ? "public" 
                        : field.IsPrivate 
                        ? "private" 
                        : "protected";

                    Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}
