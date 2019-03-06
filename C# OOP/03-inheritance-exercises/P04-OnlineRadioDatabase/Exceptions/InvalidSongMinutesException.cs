namespace P04_OnlineRadioDatabase.Exceptions
{
    public class InvalidSongMinutesException : InvalidSongLengthException
    {
        public InvalidSongMinutesException(string message = "Song minutes should be between 0 and 14.")
            : base (message)
        {

        }
    }
}
