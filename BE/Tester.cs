using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Serialization;


namespace BE
{
    [Serializable]
    public class Tester : IComparable<Tester>, IComparer<Tester>
    {
        public string ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public int Xp { get; set; }
        public int Max_test { get; set; }
        public TypeCar Type_car { get; set; }
        [XmlIgnore]
        public bool[,] Work_day { get; set; }
        public Address address { get; set; }
        public string workedHoursToString { get; set; }

        public string ConvertBoolArrayToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Work_day[i, j])
                    {
                        sb.Append("1");
                        sb.Append(";");
                    }
                    else
                    {
                        sb.Append("0");
                        sb.Append(";");
                    }
                }

            }
            return sb.ToString();
        }

        public bool[,] ConvertStringToBoolArray()
        {
            bool[,] mybool = new bool[7, 10];

            char[] separator = { ';' };

            String[] result = workedHoursToString.Split(separator[0]);

            int count = 0;
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (result[count] != "")
                    {
                        if (result[count] == "1")
                        {
                            mybool[j, i] = true;
                        }
                        else mybool[j, i] = false;
                    }
                    count++;
                }
            }

            return mybool;
        }

        public Tester()
        { }

        public Tester(string id, string lstNm, string frstNm, DateTime brthDy, string phn, int xp, int mxTst, TypeCar tpCr, bool[,] wrkDy, Address addrss)
        {
            ID = id;
            LastName = lstNm;
            FirstName = frstNm;
            BirthDay = brthDy;
            Phone = phn;
            Xp = xp;
            Max_test = mxTst;
            Type_car = tpCr;
            Work_day = new bool[7, 10];
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 10; j++)
                    Work_day[i, j] = wrkDy[i, j];

            address = addrss;
        }

        public Tester(Tester t)
        {
            ID = t.ID;
            LastName = t.LastName;
            FirstName = t.FirstName;
            BirthDay = t.BirthDay;
            Phone = t.Phone;
            Xp = t.Xp;
            Max_test = t.Max_test;
            Type_car = t.Type_car;
            Work_day = t.Work_day;
            address = t.address;
        }

        public override string ToString()
        {
            return "";
        }

        public int CompareTo(Tester other)
        { return ID.CompareTo(other.ID); }

        public int Compare(Tester x, Tester y)
        { return x.CompareTo(y); }
    }
}
