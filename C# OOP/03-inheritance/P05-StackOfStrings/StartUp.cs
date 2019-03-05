namespace P05_StackOfStrings
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var stack = new StackOfStrings();
            stack.Push("fish");
            stack.Push("lion");
            stack.Push("bear");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.IsEmpty());
        }
    }
}
