using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
namespace BL
{

    public interface IBL
    {

        void check_add_tester(Tester tstr);
        void check_add_trainee(Trainee trnee);
        void check_add_test(Test tst);
        List<Tester> get_all_Available(DateTime dateTime, TypeCar t);
        List<Test> get_all_test_with_condition(Predicate<Test> a);
        List<Tester> get_radius_tester(Address a, double x);
        List<Tester> group_by_TypeCar(string typeCar ,bool a);
        List<Tester> group_by_location(string city ,bool a);
        List<Trainee> get_all_trainee_success();
        List<Trainee> get_all_trainee_failed();
        List<Tester> get_all_tester_didnt_reached_maxTest(DateTime date);
        int TraineeSuccess();//1
        List<Tester> get_testers();
        List<Test> get_tests();
        List<Trainee> get_trainees();
        void del_trainee(Trainee t);
        void del_tester(Tester t);
        void update_test(Test t);
        void up_test_fin(Test t);
        void update_trainee(Trainee t);
        void update_tester(Tester t);
    }
}
