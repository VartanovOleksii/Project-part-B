using System;
using System.Collections.Generic;
using System.Text;

namespace Project__part_B_
{
    public class RecordLabel
    {
        //Public static properties
        public static string DefName = "Label";
        public static List<Band> DefBands = new List<Band>();  

        //Private properties
        private string _recordLabelName;
        private List<Band> _bands;

        //Public properties
        public string RecordLabelName
        {
            get => _recordLabelName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Enter label name.");

                if (value.Length < 3 || value.Length > 50)
                    throw new ArgumentOutOfRangeException("Label name have to be between 3 and 50 characters.");

                _recordLabelName = value;
            }
        }

        public List<Band> Bands
        {
            get => _bands; 
            set => _bands = value;
        }

        //Public methods
        public void SignBand(Band band)
        {
            _bands.Add(band);
        }

        public void SignBand(List<Band> bands)
        {
            _bands.AddRange(bands);
        }

        public bool UnsignBand(int index)
        {
            throw new NotImplementedException();
        }

        public bool UnsignBand(string name)
        {
            throw new NotImplementedException();
        }

        //Constructors
        public RecordLabel()
        {
            RecordLabelName = DefName;
            _bands = new List<Band>();
        }

        public RecordLabel(string name, List<Band> bands)
        {
            RecordLabelName = name;
            Bands = bands;
        }
    }
}
