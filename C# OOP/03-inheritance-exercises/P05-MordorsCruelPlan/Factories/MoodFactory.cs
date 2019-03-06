namespace P05_MordorsCruelPlan.Factories
{
    using System;
    using Moods;

    public class MoodFactory
    {
        public Mood CreateMood(string type)
        {
            switch (type.ToLower())
            {
                case "happy":
                    return new Mood("Happy");

                case "angry":
                    return new Mood("Angry");

                case "sad":
                    return new Mood("Sad");

                case "javascript":
                    return new Mood("JavaScript");

                default:
                    throw new Exception("Invalid type!");
            }
        }
    }
}
