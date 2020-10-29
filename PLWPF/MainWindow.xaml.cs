using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Show_dataSource myDataSource { get; set; }
        Add_trainee myTrainee { get; set; }
        Add_tester myTester { get; set; }
        Add_test myTest { get; set; }

        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            

            bl = MyFactoryBL.Instance;

            myDataSource = ShowDataSource;
            myTrainee = NewTrainee;
            myTest = NewTest;
            myTester = NewTester;

            myTrainee.AddTrainee += OnAddTrainee;
            myTest.AddTest += OnAddTest;
            myTester.AddTester += OnAddTester;

            //bool[,] mybool = new bool[7,10];
            //for (int i = 0; i < 7; i++)
            //    for (int j = 0; j < 10; j++)
            //        mybool[i, j] = true;
            //Address add = new Address(); add.City = "jerusalem"; add.Num = 45; add.Street = "pisga";
            //Test newTest = new Test(1); newTest.ID_trainee = "333333333"; newTest.typeCar = TypeCar.Car; newTest.Date_test = DateTime.Now.AddYears(1);
            //newTest.Address_test_end = add; newTest.Address_test_start = add;
            //Tester tstr = new Tester("222222222","2","2",DateTime.Now.AddYears(-45),"3",2,2,TypeCar.Car,mybool,add);
            //MyFactoryBL.Instance.check_add_tester(tstr);
            //Trainee trnee = new Trainee("333333333","2", DateTime.Now.AddYears(-45), Gender.Male,"1",add);
            //MyFactoryBL.Instance.check_add_trainee(trnee);
            //MyFactoryBL.Instance.check_add_test(newTest);
        }

        private void Add_Tester_Click(object sender, RoutedEventArgs e)
        {
            NewTest.Visibility = Visibility.Hidden;
            NewTrainee.Visibility = Visibility.Hidden;
            ShowDataSource.Visibility = Visibility.Hidden;

            if (NewTester.Visibility == Visibility.Hidden)
            { NewTester.Visibility = Visibility.Visible; }
            else
            { NewTester.Visibility = Visibility.Hidden; }
        }

        private void Add_Trainee_Click(object sender, RoutedEventArgs e)
        {
            NewTest.Visibility = Visibility.Hidden;
            NewTester.Visibility = Visibility.Hidden;
            ShowDataSource.Visibility = Visibility.Hidden;

            if (NewTrainee.Visibility == Visibility.Hidden)
            { NewTrainee.Visibility = Visibility.Visible; }
            else
            { NewTrainee.Visibility = Visibility.Hidden; }
        }

        private void Add_Test_Click(object sender, RoutedEventArgs e)
        {
            NewTester.Visibility = Visibility.Hidden;
            NewTrainee.Visibility = Visibility.Hidden;
            ShowDataSource.Visibility = Visibility.Hidden;

            if (NewTest.Visibility == Visibility.Hidden)
            { NewTest.Visibility = Visibility.Visible; }
            else
            { NewTest.Visibility = Visibility.Hidden; }
        }

        private void Show_DataSource_Click(object sender, RoutedEventArgs e)
        {
            NewTester.Visibility = Visibility.Hidden;
            NewTrainee.Visibility = Visibility.Hidden;
            NewTest.Visibility = Visibility.Hidden;

            if (ShowDataSource.Visibility == Visibility.Hidden)
            { ShowDataSource.Visibility = Visibility.Visible; }
            else
            { ShowDataSource.Visibility = Visibility.Hidden; }
        }

        public void OnAddTrainee(object source, EventArgs args)
        { myDataSource.refresh_datagrid_trainee(); }

        public void OnAddTest(object source, EventArgs args)
        { myDataSource.refresh_datagrid_test(); }

        public void OnAddTester(object source, EventArgs args)
        { myDataSource.refresh_datagrid_tester(); }
    }
}
