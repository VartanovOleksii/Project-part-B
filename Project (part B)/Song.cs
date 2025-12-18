using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace Project__part_B_
{
    public class Song: IMediaContent, IComparable<Song>
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
            _totalPlats++;
            string result = $"Now is playing: {SongName}";

            return result;
        }

        public string Stop()
        {
            string result = $"On pause: {SongName}";

            return result;
        }

        public string GetMetadata()
        {
            string result = $"Name: {SongName}\n" +
                            $"Author: {Band.BandName}\n" +
                            $"Genre: {Genre}\n" +
                            $"Total plays: {TotalPlays}";

            return result;
        }

        public int CompareTo(Song? other)
        {
            if (other == null)
                throw new ArgumentNullException("Incorrect value.");
            return SongName.CompareTo(other.SongName);
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
