using System;
using System.Collections.Generic;
using System.Text;

namespace Project__part_B_
{
    public class Band
    {
        //Public properties
        public string BandName { get; set; }
        public int MonthlyListening { get; set; }
        public List<Producer> Producers { get; set; }
        public List<Artist> Artists { get; set; }

        //Constructors
        public Band()
        {
            throw new NotImplementedException();
        }

        public Band(string name, List<Producer> producers)
        {
            throw new NotImplementedException();

            BandName = name;
            Producers = producers;

            Artists = new List<Artist>();
        }
    }
}
