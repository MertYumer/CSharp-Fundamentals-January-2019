﻿namespace P06_Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender = "Male")
            : base(name, age, gender)
        {

        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
