using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Serializable]
    public class SavedLists
    {
        #region Properties

        private List<Test> _listTest;
        public List<Test> ListTest
        {
            get { return _listTest; }
            set { _listTest = value; }
        }

        private List<Trainee> _listTrainee;
        public List<Trainee> ListTrainee
        {
            get { return _listTrainee; }
            set { _listTrainee = value; }
        }

        private List<Tester> _listTrainer;
        public List<Tester> ListTester
        {
            get { return _listTrainer; }
            set { _listTrainer = value; }
        }

        #endregion Properties

        #region Constructors

        public SavedLists() { }

        #endregion
    }
}
