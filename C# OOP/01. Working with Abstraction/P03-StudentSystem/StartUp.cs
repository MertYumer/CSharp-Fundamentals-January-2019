namespace P03_StudentSystem
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Exit")
                {
                    break;
                }

                else if (input[0] == "Create")
                {
                    studentSystem.AddStudent(input);
                }

                else if (input[0] == "Show")
                {
                    var name = input[1];
                    studentSystem.ShowStudent(name);
                }
            }
        }
    }
}
