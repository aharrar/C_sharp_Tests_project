using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Serializable]
    public class Test: IComparable<Test>,IComparer<Test>
    {
        public static int num_test = 1;

        public string id_test { get; set; }
        public string ID_tester { get; set; }
        public string ID_trainee { get; set; }
        public DateTime Date_test { get; set; }
        public TypeCar typeCar { get; set; }
        public Address Address_test_start { get; set; }
        public Address Address_test_end { get; set; }
        public bool isFinish { get; set; }
        public bool grade { get; set; }
        public string comment { get; set; }

        public Test( string IDtstr,string IDtrnee, DateTime datetst, Address addrsststStart, Address addrsststEnd, TypeCar tpcr, bool isfnsh = false)
        {
            string num_zero = "0000000";// test id
            num_zero.Substring(0, 7 - num_test.ToString().Length);
            num_zero += num_test++;
            id_test = num_zero;
            ID_trainee = IDtrnee;
            Date_test = datetst;
            Address_test_start = addrsststStart;
            Address_test_end = addrsststEnd;
            typeCar = tpcr;
            grade = false;
            comment = "";
            isFinish = isfnsh;
            ID_tester = IDtstr;
        }

        public override string ToString()
        {
            return "";
        }

        public int CompareTo(Test other)
        {
            long id_this = long.Parse(id_test);
            long id_other = long.Parse(other.id_test);
            return id_this.CompareTo(id_other);
        }

        public int Compare(Test x, Test y)
        { return x.CompareTo(y); }

        public Test(Test t, string IDtstr, string IDtrnee, DateTime datetst, Address addrsststStart, Address addrsststEnd, TypeCar tpcr)//Check!
        {
            id_test = t.id_test;
            ID_trainee = t.ID_trainee;
            Date_test = t.Date_test;
            Address_test_start = t.Address_test_start;
            Address_test_end = t.Address_test_end;
            typeCar = t.typeCar;
            grade = t.grade;
            comment = t.comment;
            isFinish = t.isFinish;
            ID_tester = t.ID_tester;
        }

        public Test(Test t)
        {
            id_test = t.id_test;
            ID_trainee = t.ID_trainee;
            Date_test = t.Date_test;
            Address_test_start = t.Address_test_start;
            Address_test_end = t.Address_test_end;
            typeCar = t.typeCar;
            grade = t.grade;
            comment = t.comment;
            isFinish = t.isFinish;
            ID_tester = t.ID_tester;
        }

        public Test(int a)
        {
            id_test = "00000000";
            ID_trainee = "";
            Date_test = new DateTime();
            Address_test_start = new Address();
            Address_test_end = new Address();
            typeCar = new TypeCar();
            grade = false;
            comment = "";
            isFinish = false;
            ID_tester = "";
        }

        public Test()
        { }
    }
}
