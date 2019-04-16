namespace P04_OnlineRadioDatabase.Exceptions
{
    using System;

    public class InvalidSongException : FormatException
    {
        public InvalidSongException(string message = "Invalid song.")
            : base (message)
        {

        }
    }
}
