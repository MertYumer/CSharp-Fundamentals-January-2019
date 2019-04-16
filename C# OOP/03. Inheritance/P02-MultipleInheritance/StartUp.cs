namespace P02_MultipleInheritance
{
    public class StartUp
    {
        public static void Main()
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Eat();

            Puppy puppy = new Puppy();
            puppy.Weep();
            puppy.Bark();
            puppy.Eat();
        }
    }
}
