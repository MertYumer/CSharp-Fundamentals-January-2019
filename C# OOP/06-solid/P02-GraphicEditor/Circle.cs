namespace P02_GraphicEditor
{
    using System;

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine($"I'm {this.GetType().Name}");
        }
    }
}
