using System;
using System.Collections.Generic;
using System.Text;

namespace Project__part_B_
{
    public class Band
    {
        //Private properties
        private string _bandName;
        private int _monthlyListening;
        private List<Producer> _producers;
        private List<Artist> _artists;
        
        //Public properties
        public string BandName { get; set; }
        public int MonthlyListening { get; set; }
        public List<Producer> Producers { get; set; }
        public List<Artist> Artists { get; set; }

        //Constructors
        public Band()
        {
        }

        public Band(string name, List<Producer> producers)
        {
            
            BandName = name;
            Producers = producers;

            Artists = new List<Artist>();
        }
    }
}
