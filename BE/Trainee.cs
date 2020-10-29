using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Serializable]
    public class Trainee: IComparable<Trainee>, IComparer<Trainee>
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender gender { get; set; }
        public string Phone { get; set; }
        public Address address { get; set; }

        public Trainee(string id,string nm, DateTime brthdy, Gender gndr, string phn, Address addrss)
        {
            ID = id;
            Name = nm;
            BirthDay = brthdy;
            gender = gndr;
            Phone = phn;
            address = addrss;
        }

        public Trainee()
        { }

        public Trainee(Trainee trnee)
        {
            ID = trnee.ID;
            Name = trnee.Name;
            BirthDay = trnee.BirthDay;
            gender = trnee.gender;
            Phone = trnee.Phone;
            address = trnee.address;
        }

        public override string ToString()
        {
            return "";
        }

        public int CompareTo(Trainee other)
        { return ID.CompareTo(other.ID); }
        

        public int Compare(Trainee x, Trainee y)
        { return x.CompareTo(y); }
    }
}
