namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var classType = typeof(BlackBoxInteger);
            var instance = (BlackBoxInteger)Activator.CreateInstance(classType, true);

            while (true)
            {
                var input = Console.ReadLine().Split('_');

                if (input[0] == "END")
                {
                    break;
                }

                string methodName = input[0];
                int value = int.Parse(input[1]);

                classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(instance, new object[] { value });

                var currentValue = classType.GetField("innerValue", 
                    BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(instance);

                Console.WriteLine(currentValue);
            }
        }
    }
}
