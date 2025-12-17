using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Project__part_B_
{
    public class Band
    {
        //Public static properties
        public static string DefName = "Band";
        public static int DefMonthlyListening = 0;
        public static List<Producer> DefProducers = new List<Producer>();

        //Private properties
        private string _bandName;
        private int _monthlyListening;
        private List<Producer> _producers;
        private List<Artist> _artists;
        
        //Public properties
        public string BandName {
            get => _bandName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Enter band name.");

                if (value.Length < 3 || value.Length > 50)
                    throw new ArgumentOutOfRangeException("Band name have to be between 3 and 50 characters.");

                _bandName = value;
            }
        }
        public int MonthlyListening {
            get => _monthlyListening;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Monthly listenings have to be more than or equal to zero");

                _monthlyListening = value;
            }
        }

        public List<Producer> Producers
        {
            get => _producers;
            set => _producers = value;
        }

        public List<Artist> Artists
        {
            get => _artists;
            set => _artists = value;
        }

        //Constructors
        public Band() : this(DefName, DefMonthlyListening, DefProducers)
        {
        }

        public Band(string name, List<Producer> producers): this(name, DefMonthlyListening, producers)
        {
        }

        public Band(string name, int monthlyListening, List<Producer> producers)
        {

            BandName = name;
            Producers = producers;
            MonthlyListening = monthlyListening;

            Artists = new List<Artist>();
        }
    }
}
