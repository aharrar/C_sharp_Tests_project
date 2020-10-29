using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using DAL;

namespace DAL
{
    public class Dal_imp: Idal
    {
        Dal_XML_imp dXml = null;
        public Dal_imp()
        {
            dXml = new Dal_XML_imp();

            SavedLists sl = dXml.LoadFileXml();

            if (sl != null)
            {
                DataSource.list_test = sl.ListTest;

                foreach (Tester tester in sl.ListTester)
                {
                    tester.Work_day = tester.ConvertStringToBoolArray();
                }
                DataSource.list_tester = sl.ListTester;
                DataSource.list_trainee = sl.ListTrainee;
                Test.num_test = int.Parse(DataSource.list_test[DataSource.list_test.Count-1].id_test)+1;
            }

        }
        public void Add_test(Test a)
        {
            Test test = new Test(a.ID_tester,a.ID_trainee,a.Date_test,a.Address_test_start,a.Address_test_end,a.typeCar);
            DataSource.list_test.Add(test);
        }

        public void Add_tester(Tester a)
        {
            if (DataSource.list_tester.Count == 0)
            { DataSource.list_tester.Add(a); }
            else
            {
                var contain = from tester in DataSource.list_tester // LINQ 1
                              where tester.ID == a.ID
                              select tester;
                var contain2 = from trnee in DataSource.list_trainee
                               where trnee.ID == a.ID
                               select trnee;
                if (contain.Count() != 0 || contain2.Count() != 0)
                { throw new FormatException("This ID already exist"); }
                else
                { DataSource.list_tester.Add(a); }
            }
        }

        public void Add_trainee(Trainee trnee)
        {
            if (DataSource.list_trainee.Count == 0)
            { DataSource.list_trainee.Add(trnee); }
            else
            {
                var contain = from tester in DataSource.list_tester // LINQ 1
                              where tester.ID == trnee.ID
                              select tester;
                var contain2 = from trnee1 in DataSource.list_trainee
                               where trnee1.ID == trnee.ID
                               select trnee1;
                if (contain.Count() != 0 || contain2.Count() != 0)
                { throw new FormatException("This ID already exist"); }
                else
                { DataSource.list_trainee.Add(trnee); }
            }
        }

        public void Modif_tester(Tester tstr)
        {
            try
            {
                for (int i = 0; i < get_tester().Count; i++)
                    if (get_tester()[i].ID == tstr.ID)
                        DataSource.list_tester[i] = tstr;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Modif_trainee(Trainee trnee)
        {
            try
            {
                for (int i = 0; i < get_trainee().Count; i++)
                    if (get_trainee()[i].ID == trnee.ID)
                        DataSource.list_trainee[i] = trnee;
            }
            catch (Exception ex)
            { throw ex; }
                
        }

        public bool Del_tester(Tester tstr)
        { return DataSource.list_tester.Remove(tstr); }

        public bool Del_trainee(Trainee trnee)
        { return DataSource.list_trainee.Remove(trnee); }

        public List<Test> get_test()
        { return DataSource.list_test; }

        public List<Tester> get_tester()
        { return DataSource.list_tester; }

        public List<Trainee> get_trainee()
        { return DataSource.list_trainee; }

        public void Modif_test(Test test)
        {
            try
            {
                int index = 0;
                for (int i = 0; i < get_test().Count; i++)
                    if (get_test()[i].id_test == test.id_test)
                    { index = i; break; }
                if (get_test()[index].isFinish)
                { get_test()[index] = test; }
                else
                { throw new Exception("The test isn't finished yet!"); }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void modif_isFinish(Test test)
        {
            try
            {
                int index = 0;
                for (int i = 0; i < get_test().Count; i++)
                    if (get_test()[i].id_test == test.id_test)
                    { index = i; break; }
                get_test()[index].isFinish = !get_test()[index].isFinish;
            }
            catch (Exception ex)
            { throw ex; }
        }

        ~Dal_imp()
        {
            SavedLists sl = new SavedLists();
            sl.ListTest = DataSource.list_test;
            sl.ListTester = DataSource.list_tester;

            //Conversion bool array to string before serialization
            foreach (var tester in sl.ListTester)
            {
                tester.workedHoursToString = tester.ConvertBoolArrayToString();
            }

            sl.ListTrainee = DataSource.list_trainee;

            dXml.WriteXmlFileSL2(sl);
        }
    }
}
