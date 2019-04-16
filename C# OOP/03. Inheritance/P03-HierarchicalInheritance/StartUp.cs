namespace P03_HierarchicalInheritance
{
    public class StartUp
    {
        public static void Main()
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Eat();

            Cat cat = new Cat();
            cat.Meow();
            cat.Eat();
        }
    }
}
