namespace P04_OnlineRadioDatabase.Exceptions
{
    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        public InvalidSongSecondsException(string message = "Song seconds should be between 0 and 59.")
            : base(message)
        {

        }
    }
}
