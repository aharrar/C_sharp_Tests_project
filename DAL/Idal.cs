using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public interface Idal
    {
        void Add_tester(Tester tstr);
        bool Del_tester(Tester tstr);
        void Modif_tester(Tester tstr);

        void Add_trainee(Trainee trnee);
        bool Del_trainee(Trainee trnee);
        void Modif_trainee(Trainee trnee);

        void Add_test(Test test);
        void Modif_test(Test test);

        void modif_isFinish(Test test);

        List<Tester> get_tester();
        List<Trainee> get_trainee();
        List<Test> get_test();
    }
}
