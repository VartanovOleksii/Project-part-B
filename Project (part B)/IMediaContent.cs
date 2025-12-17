using System;
using System.Collections.Generic;
using System.Text;

namespace Project__part_B_
{
    internal interface IMediaContent
    {
        public string Play();
        public string Stop();
        public string GetMetadata();
    }
}
