using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Project__part_B_
{
    public class Song: IMediaContent
    {
        //Public static properties
        public static string DefSongName = "Song";
        public static long DefTotalPlays = 0;
        public static Band DefBand = new Band();
        public static Genre DefGenre = Genre.Pop;
        
        //Private properties
        private string _songName;
        private long _totalPlats;
        private Band _band;
        private Genre _genre;

        //Public properties
        public string SongName 
        {
            get => _songName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Enter song name.");

                if (value.Length < 3 || value.Length > 50)
                    throw new ArgumentOutOfRangeException("Song name have to be between 3 and 50 characters.");

                _songName = value;
            }
        }
        public long TotalPlays 
        {
            get => _totalPlats;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Total plays have to be more than or equal to zero");

                _totalPlats = value;
            }
        }

        public Band Band
        {
            get => _band; 
            set => _band = value;
        }

        public Genre Genre
        {
            get => _genre; 
            set => _genre = value;
        }

        //Public methods
        public string Play()
        {
            throw new NotImplementedException();
        }

        public string Stop()
        {
            throw new NotImplementedException();
        }

        public string GetMetadata()
        {
            throw new NotImplementedException();
        }


        //Constructors
        public Song() : this (DefSongName, DefTotalPlays, DefBand, DefGenre)
        {
        }

        public Song(string name, Band band, Genre genre) : this(name, DefTotalPlays, band, genre)
        {
        }

        public Song(string name, long totalPlays, Band band, Genre genre)
        {
            SongName = name;
            TotalPlays = totalPlays;
            Band = band;
            Genre = genre;
        }
    }
}
