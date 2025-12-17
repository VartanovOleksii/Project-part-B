using System;
using System.Collections.Generic;
using System.Text;

namespace Project__part_B_
{
    public class Song: IMediaContent
    {
        //Public properties
        public string SongName { get; set; }
        public long TotalPlays { get; set; }

        public Band Band { get; set; }
        public Genre Genre { get; set; }

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
        public Song()
        {
            throw new NotImplementedException();
        }

        public Song(string name, Band band, Genre genre)
        {
            throw new NotImplementedException();

            SongName = name;
            Band = band;
            Genre = genre;
        }
    }
}
