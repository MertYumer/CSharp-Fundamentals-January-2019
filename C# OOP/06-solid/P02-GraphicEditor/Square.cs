namespace P02_GraphicEditor
{
    using System;

    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine($"I'm {this.GetType().Name}");
        }
    }
}
