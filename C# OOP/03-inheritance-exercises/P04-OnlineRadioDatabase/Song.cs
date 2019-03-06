namespace P04_OnlineRadioDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Song
    {
        private string artistName;
        private string songName;
        private int minutes;
        private int seconds;

        public Song(string artistName, string songName, int minutes, int seconds)
        {

        }

        private string ArtistName
        {
            get => this.artistName;
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {

                }

                this.artistName = value;
            }
        }

        private string SongName
        {
            get => this.songName;
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {

                }

                this.songName = value;
            }
        }

        private int Minutes
        {
            get => this.minutes;
            set
            {
                if (value < 0 || value > 14)
                {

                }

                this.minutes = value;
            }
        }

        private int Seconds
        {
            get => this.seconds;
            set
            {
                if (value < 0 || value > 59)
                {

                }

                this.seconds = value;
            }
        }
    }
}
