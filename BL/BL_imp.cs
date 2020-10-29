using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using BE;
using DAL;
using Location;

namespace BL
{
    class BL_imp : IBL
    {
        public void check_add_tester(Tester a)// OK!!!!!!!!!!!!!!!!!!!
        {
            if ((DateTime.Now.Year - a.BirthDay.Year) < 40 || (DateTime.Now.Year - a.BirthDay.Year) > 65)
            { throw new Exception("Age out of the range!(min: 40 , max: 65)"); }
            else
            { MyFactoryDal.Instance.Add_tester(a); }
        }

        public void check_add_test(Test test)
        {
            try
            {
                var myTrnee = from trnee in get_trainees()
                              where trnee.ID == test.ID_trainee
                              select trnee;
                if (myTrnee.Count() == 0)
                { throw new Exception("The trainee doesn't exist!"); }
                bool flag_month = last_month_test_trainee(test.Date_test, test.ID_trainee);
                if (!flag_month)
                { throw new Exception("The trainee must wait at least a month before retest."); }
                else
                {
                    List<Tester> list_tester = get_all_Available(test.Date_test, test.typeCar);
                    List<Tester> testers_in_radius = get_radius_tester(test.Address_test_start, 10);
                    List<Tester> temp = new List<Tester>();
                    for (int i = 0; i < list_tester.Count; i++)
                        temp.Add(list_tester[i]);
                    foreach (Tester item in list_tester)
                        if (!testers_in_radius.Contains(item))
                        { temp.Remove(item); }
                    list_tester = new List<Tester>();
                    for (int i = 0; i < temp.Count; i++)
                        list_tester.Add(temp[i]);
                    if (list_tester.Count == 0)
                        { throw new Exception("No tester available around this address at this date."); }
                        else
                        {
                            test.ID_tester = list_tester.First().ID;
                            MyFactoryDal.Instance.Add_test(test);
                        }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void check_add_trainee(Trainee trnee)// OK!!!!!!!!!!!!!!!!!!!
        {
            if ((DateTime.Now.Year - trnee.BirthDay.Year) < 18 || (DateTime.Now.Year - trnee.BirthDay.Year) > 65)
            {  throw new Exception("Age out of the range!(min: 40 , max: 65)"); }
            else
            {
                try
                { MyFactoryDal.Instance.Add_trainee(trnee); }
                catch (Exception ex)
                { throw ex;}
            }
        }

        public List<Tester> get_all_Available(DateTime dateTime, TypeCar t)//OK!!!!!!!!!!!!!!!!!!!
        {
            try
            {
                List<Tester> testers = MyFactoryDal.Instance.get_tester();
                List<Test> tests = MyFactoryDal.Instance.get_test();
                List<Tester> temp = new List<Tester>();
                List<Tester> temp2 = new List<Tester>();

                var availables = from tester in testers
                                 where tester.Work_day[(int)dateTime.DayOfWeek, dateTime.Hour-10]
                                 select tester;//get the tester who can works at this time

                if (availables.Count() == 0)
                { throw new Exception("No tester available at this date."); }

                var availablesTypeCar = from tester in testers
                                        where t == tester.Type_car
                                        select tester;
                List<Tester> availableTypecar = availablesTypeCar.ToList();
                if (availableTypecar.Count == 0)
                { throw new Exception("No tester match with this type of car!"); }
                foreach (var item1 in availables)
                { temp.Add(item1); }

                foreach (var item in availables)//check if the testers are busy in fact
                {
                    var availableDate = from test in tests
                                        where test.Date_test.Date == dateTime.Date
                                        select test;
                    foreach (Test test in availableDate)
                        if (test.ID_tester == item.ID)
                        { temp.Remove(item); }
                }
                List<Tester> tester_maxTest_available = get_all_tester_didnt_reached_maxTest(dateTime);

                for (int i = 0; i < temp.Count; i++)
                    temp2.Add(temp[i]);
                foreach (Tester item in temp)
                    if (!tester_maxTest_available.Contains(item))
                    { temp2.Remove(item); }
                temp = new List<Tester>();
                for (int i = 0; i < temp2.Count; i++)
                    temp.Add(temp2[i]);
                temp2 = new List<Tester>();

                if (temp.Count == 0)
                { throw new Exception("All tester available are in fact busy..."); }

                for (int i = 0; i < temp.Count; i++)
                    temp2.Add(temp[i]);
                foreach (Tester item in temp)
                    if (!availablesTypeCar.Contains(item))
                    { temp2.Remove(item); }
                temp = new List<Tester>();
                for (int i = 0; i < temp2.Count; i++)
                    temp.Add(temp2[i]);
                temp2 = new List<Tester>();

                if (temp.Count == 0)
                { throw new Exception("All tester available at this date don't match with the type car."); }
                return temp;
            }
            catch (Exception ex)
            { throw ex; }
            
        }

        public List<Test> get_all_test_with_condition(Predicate<Test> a)
        {
            List<Test> myListTest = MyFactoryDal.Instance.get_test();
            var set_all = from test in myListTest
                          where a(test)
                          select test;
            foreach (var item in set_all)
            { myListTest.Add(item); }
            return myListTest;
        }

        public int TraineeSuccess()// OK!!!!!!!!!!!!!!!!!!!
        {
            List<Test> tests = MyFactoryDal.Instance.get_test();
            Func<List<Test>, int> f = (x) =>
            {
                int a = 0;
                foreach (var item in x)
                    if (item.grade)
                        a++;
                return a;
            };
            int t = f(tests);
            return t;
        }

        public List<Tester> get_radius_tester(Address adrress, double x)// OK!!!!!!!!!!!!!!!!!!!
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            string a = myTI.ToLower(adrress.Street) + " " + adrress.Num + " st. " + myTI.ToTitleCase(myTI.ToLower(adrress.City)) + ", ISRAEL";
            //string a = adrress.Street + " " + adrress.Num + " " + adrress.City;
            List<Tester> testers;
            List<Tester> temp = new List<Tester>();

            Func<Address, string> func = (xy) => {// "Tostring function"
                string re = myTI.ToLower(xy.Street) + " " + xy.Num + " st. " + myTI.ToTitleCase(myTI.ToLower(xy.City)) + ", ISRAEL";
                //string re = xy.Street + " " + xy.Num + " " + xy.City;
                return re;
            };
            testers = MyFactoryDal.Instance.get_tester();
            foreach (var item in testers)
            {
                string s = func(item.address);
                if (location.PrintDrivingDistanceInMiles(a, s) <= x)
                { temp.Add(item); }
            }
            if (temp.Count == 0)
            { throw new Exception("No tester have been found around this address!"); }
            return temp;
        }

        public List<Tester> group_by_TypeCar(string typeCar ,bool a = false)// OK!!!!!!!!!!!!!!!!!!!
        {
                List<Tester> testers = MyFactoryDal.Instance.get_tester().FindAll(v => v.Type_car.ToString() == typeCar);
                List<Tester> temp = new List<Tester>();

                var vehicle_false = from item in testers
                                    orderby item.Type_car
                                    select item;
                var vehicle_true = from item in testers
                                   orderby item.Type_car descending
                                   select item;

                if (a)
                    foreach (var item in vehicle_false)
                    { temp.Add(item); }
                else
                    foreach (var item in vehicle_true)
                    { temp.Add(item); }
                return temp;
        }

        public List<Tester> group_by_location(string city ,bool a = false)// OK!!!!!!!!!!!!!!!!!!!
        {
            List<Tester> temp = new List<Tester>();
            List<Tester> testers = MyFactoryDal.Instance.get_tester().FindAll(v => v.address.City == city);
            if (a)
            {
                var contain = testers.
                OrderBy(item => item.address.City)// City is the priority key
                .ThenBy(item => item.address.Street)// Street is the secondary key 
                .ThenBy(item => item.address.Num);// Num is the third key
                foreach (var item in contain)
                { temp.Add(item); }
                return temp;
            }
            else
            {
                var contain = testers.
                OrderBy(item => item.address.Num)// City is the priority key
                .ThenBy(item => item.address.Street)// Street is the secondary key 
                .ThenBy(item => item.address.City);// Num is the third key
                foreach (var item in contain)
                { temp.Add(item); }
                return temp;
            }
        }

        public List<Trainee> get_all_trainee_success()// OK!!!!!!!!!!!!!!!!!!!
        {
            List<Trainee> temp = new List<Trainee>();
            List<Trainee> trainees = MyFactoryDal.Instance.get_trainee();
            List<Test> tests = MyFactoryDal.Instance.get_test();
            var contain = from item in tests// get the test wich the trainee succeed
                          where (item.isFinish == true && item.grade == true)
                          select item;
            foreach (var item in contain)// insert all the "success test" in the temporary(temp) list
                foreach (var item1 in trainees)
                    if (item.ID_trainee == item1.ID)
                    { temp.Add(item1); }
            return temp;
        }

        public List<Trainee> get_all_trainee_failed()// OK!!!!!!!!!!!!!!!!!!!
        {
            List<Trainee> temp = new List<Trainee>();
            List<Trainee> trainees = MyFactoryDal.Instance.get_trainee();
            List<Test> tests = MyFactoryDal.Instance.get_test();
            var contain = from item in tests// get the test wich the trainee failed
                          where (item.isFinish == true && item.grade == false)
                          select item;
            foreach (var item in contain)// insert all the "fail test" in the temporary(temp) list
                foreach (var item1 in trainees)
                    if (item.ID_trainee == item1.ID)
                    { temp.Add(item1); }
            return temp;
        }

        public bool last_month_test_trainee(DateTime date, string id)
        {
            List<Test> myListTest = MyFactoryDal.Instance.get_test();

            var mLstTest = from test0 in myListTest
                           where test0.ID_trainee == id
                           select test0;// get all the trainee's tests did
            var mLstTest1 = from myTest1 in mLstTest
                           where (date.Date - myTest1.Date_test.Date).TotalDays < 30//
                           select myTest1;// get all the test that were done less than a month ago
            if (mLstTest1.Count() == 0)
            { return true; }//if the trainee can do the test
            else
            { return false; }// he can't
        }
        public bool distance_Radius_less10Km(Address adrress, string id)
        {
            double x = 10;
            List<Tester> myTesterList = get_radius_tester(adrress, x);
            foreach (var item in myTesterList)
                if (item.ID == id)
                { return true; }
            return false;
        }

        public List<Tester> get_all_tester_didnt_reached_maxTest(DateTime date)
        {
            List<Tester> myTesterList = MyFactoryDal.Instance.get_tester();
            List<Test> myTestlist = MyFactoryDal.Instance.get_test();
            List<Tester> temp_tester = new List<Tester>();

            DateTime startWeek = date.AddDays(-(int)date.DayOfWeek);
            DateTime endtWeek = startWeek.AddDays(7);
            var test_inWeek = from test1 in myTestlist //pick all the test in the week
                              where test1.Date_test.CompareTo(startWeek) > 0 && test1.Date_test.CompareTo(endtWeek) < 0
                              select test1;

            int count = 0;
            foreach (var tester in myTesterList)
            {
                foreach (var test in test_inWeek)
                    if (tester.ID == test.ID_tester)
                        count++;
                if (count < tester.Max_test)
                    temp_tester.Add(tester);
            }

            return temp_tester;
        }

        public List<Tester> get_testers()
        { return MyFactoryDal.Instance.get_tester(); }

        public List<Test> get_tests()
        { return MyFactoryDal.Instance.get_test(); }

        public List<Trainee> get_trainees()
        { return MyFactoryDal.Instance.get_trainee(); }

        public void del_trainee(Trainee t)
        { MyFactoryDal.Instance.Del_trainee(t); }
        public void del_tester(Tester t)
        { MyFactoryDal.Instance.Del_tester(t); }

        public void update_test(Test t)
        { MyFactoryDal.Instance.Modif_test(t); }

        public void update_trainee(Trainee t)
        { MyFactoryDal.Instance.Modif_trainee(t); }

        public void update_tester(Tester t)
        { MyFactoryDal.Instance.Modif_tester(t); }

        public void up_test_fin(Test t)
        {
            try
            { MyFactoryDal.Instance.modif_isFinish(t); }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }
    }
}