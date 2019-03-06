namespace P04_OnlineRadioDatabase.Core
{
    using P04_OnlineRadioDatabase.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<Song> playlist;

        public Engine()
        {
            this.playlist = new List<Song>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var input = Console.ReadLine().Split(';');

                    if (input.Length != 3)
                    {
                        throw new InvalidSongException();
                    }

                    string artistName = input[0];
                    string songName = input[1];
                    var length = input[2].Split(':');

                    if (!int.TryParse(length[0], out int minutes) || !int.TryParse(length[1], out int seconds))
                    {
                        throw new InvalidSongLengthException();
                    }

                    var song = new Song(artistName, songName, minutes, seconds);
                    playlist.Add(song);
                    Console.WriteLine("Song added.");
                }

                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            int totalSeconds = playlist.Sum(s => (s.Minutes * 60) + s.Seconds);
            TimeSpan duration = TimeSpan.FromSeconds(totalSeconds);
            Console.WriteLine($"Songs added: {playlist.Count}");
            Console.WriteLine($"Playlist length: {duration.Hours}h {duration.Minutes}m {duration.Seconds}s");
        }
    }
}
