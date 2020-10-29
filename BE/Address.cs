using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct Address
    {
        public string City { get; set; }
        public int Num { get; set; }
        public string Street { get; set; }
        public override string ToString()
        { return string.Format("{0} {1} {2}", City, Num, Street); }
    }
}
