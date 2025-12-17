using System;
using System.Collections.Generic;
using System.Text;

namespace Project__part_B_
{
    public class RecordLabel
    {
        //Public properties
        public string RecordLabelName { get; set; }
        public List<Band> Bands { get; set; }

        //Public methods
        public void SignBand(Band band)
        {
            throw new NotImplementedException();
        }

        public void SignBand(List<Band> bands)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public RecordLabel(string name, List<Band> bands)
        {
            throw new NotImplementedException();

            RecordLabelName = name;
            Bands = bands;
        }
    }
}
