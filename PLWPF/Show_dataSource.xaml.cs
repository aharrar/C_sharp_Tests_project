using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
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
using System.Globalization;

namespace PLWPF
{
    /// <summary>
    /// Logique d'interaction pour Show_dataSource.xaml
    /// </summary>
    public partial class Show_dataSource : System.Windows.Controls.UserControl
    {
        public Update_Trainee UpTrainee { get; set; }
        public Update_Tester UpTester { get; set; }
        public Update_Test UpTest { get; set; }

        public List<string> dataContextCity;

        public Show_dataSource()
        {
            InitializeComponent();
            grid_dataSource_test.DataContext = MyFactoryBL.Instance.get_tests();
            grid_dataSource_tester.DataContext = MyFactoryBL.Instance.get_testers();
            grid_dataSource_trainee.DataContext = MyFactoryBL.Instance.get_trainees();

            refreshGroupCity();

            UpTrainee = null;
            UpTester = null;
            UpTest = null;
        }

        public void refreshGroupCity()
        {
            dataContextCity = new List<string>();
            List<Tester> testers = MyFactoryBL.Instance.get_testers();
            dataContextCity.Add("Select");
            foreach (Tester tester in testers)
                if (dataContextCity.FindAll(v => v == tester.address.City).Count == 0)
                { dataContextCity.Add(tester.address.City); }

            groupAddress.DataContext = dataContextCity;
        }

        private void OnUpTrainee(object source, EventArgs args)
        {
            refresh_datagrid_trainee();
            UpTrainee = null;
        }
        private void OnUpTester(object source, EventArgs args)
        {
            refresh_datagrid_tester();
            refreshGroupCity();
            UpTester = null;
        }
        private void OnUpTest(object source, EventArgs args)
        {
            refresh_datagrid_test();
            UpTest = null;
        }

        private void button_edit_trainee_Click(object sender, RoutedEventArgs e)
        {
            if (UpTrainee != null)
            { System.Windows.MessageBox.Show("Already editing trainee!"); }
            else
            {
                Trainee myTrnee = (Trainee)grid_dataSource_trainee.SelectedItem;
                UpTrainee = new Update_Trainee(myTrnee);
                UpTrainee.UpTrainee += OnUpTrainee;
                Thread WinUpTrnee = new Thread(new ParameterizedThreadStart(threadUpTrnee));
                WinUpTrnee.Start(UpTrainee);
            }
        }
        private void button_edit_tester_Click(object sender, RoutedEventArgs e)
        {
            if (UpTester != null)
            { System.Windows.MessageBox.Show("Already editing Tester!"); }
            else
            {
                Tester myTester = (Tester)grid_dataSource_tester.SelectedItem;
                
                UpTester = new Update_Tester(myTester);
                UpTester.UpTester += OnUpTester;
                Thread WinUpTester = new Thread(new ParameterizedThreadStart(threadUptester));
                WinUpTester.Start(UpTester);
            }
        }

        public void threadUpTrnee(object Win)
        {
            Update_Trainee myUpTrainee = (Update_Trainee)Win;
            myUpTrainee.Dispatcher.Invoke(() => { myUpTrainee.Show(); });
        }
        public void threadUptester(object Win)
        {
            Update_Tester myUpTester = (Update_Tester)Win;
            myUpTester.Dispatcher.Invoke(() => { myUpTester.Show(); });
        }
        public void threadUpTest(object Win)
        {
            Update_Test myUpTest = (Update_Test)Win;
            myUpTest.Dispatcher.Invoke(() => { myUpTest.Show(); });
        }

        private void button_remove_trainee_Click(object sender, RoutedEventArgs e)
        {
            DialogResult msg = System.Windows.Forms.MessageBox.Show("SURE??", "", MessageBoxButtons.OKCancel);
            if (msg == DialogResult.OK)
            {
                DataGridRow row = (DataGridRow)grid_dataSource_trainee.ItemContainerGenerator.ContainerFromItem(grid_dataSource_trainee.CurrentItem);
                Trainee trainee = (Trainee)row.Item;
                MyFactoryBL.Instance.del_trainee(trainee);

                refresh_datagrid_trainee();
                System.Windows.MessageBox.Show("Trainee was deleted successfully!");
            }
        }
        public void refresh_datagrid_trainee()
        {
            grid_dataSource_trainee.ItemsSource = null;
            grid_dataSource_trainee.ItemsSource = MyFactoryBL.Instance.get_trainees();
        }

        public void refresh_datagrid_test()
        {
            grid_dataSource_test.ItemsSource = null;
            grid_dataSource_test.ItemsSource = MyFactoryBL.Instance.get_tests();
        }

        public void refresh_datagrid_tester()
        {
            grid_dataSource_tester.ItemsSource = null;
            grid_dataSource_tester.ItemsSource = MyFactoryBL.Instance.get_testers();
        }

        private void button_remove_tester_Click(object sender, RoutedEventArgs e)
        {
            DialogResult msg = System.Windows.Forms.MessageBox.Show("SURE??", "", MessageBoxButtons.OKCancel);
            if (msg == DialogResult.OK)
            {
                DataGridRow row = (DataGridRow)grid_dataSource_tester.ItemContainerGenerator.ContainerFromItem(grid_dataSource_tester.CurrentItem);
                Tester tester = (Tester)row.Item;
                MyFactoryBL.Instance.del_tester(tester);

                refresh_datagrid_tester();
                System.Windows.MessageBox.Show("Tester was deleted successfully!");
            }
        }

        private void button_show_workday_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button mybutton = sender as System.Windows.Controls.Button;
            StackPanel stackPanel = mybutton.Content as StackPanel;
            System.Windows.Controls.Primitives.Popup pp = stackPanel.Children[1] as System.Windows.Controls.Primitives.Popup;
            if (pp.IsOpen == false)
            { pp.IsOpen = true; }
            else
            { pp.IsOpen = false; }
        }
        
        /*private void exp_com_test_Expanded(object sender, RoutedEventArgs e)
        {

        }*/

        private void button_edit_test_Click(object sender, RoutedEventArgs e)
        {
            if (UpTest != null)
            { System.Windows.MessageBox.Show("Already editing Test!"); }
            else
            {
                Test myTest = (Test)grid_dataSource_test.SelectedItem;
                UpTest = new Update_Test(myTest);
                UpTest.UpTest += OnUpTest;
                Thread WinUpTest = new Thread(new ParameterizedThreadStart(threadUpTest));
                WinUpTest.Start(UpTest);
            }
        }

        private void groupAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { grid_Select.DataContext = MyFactoryBL.Instance.group_by_location((string)groupAddress.SelectedItem, (bool)Add_check.IsChecked); }

        private void groupTypeCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (groupTypeCar.SelectedIndex == 0)
            { grid_Select.DataContext = MyFactoryBL.Instance.group_by_TypeCar("Car", (bool)TypeCar_check.IsChecked); }
            else if (groupTypeCar.SelectedIndex == 1)
            { grid_Select.DataContext = MyFactoryBL.Instance.group_by_TypeCar("Motorbike", (bool)TypeCar_check.IsChecked); }
            else if (groupTypeCar.SelectedIndex == 2)
            { grid_Select.DataContext = MyFactoryBL.Instance.group_by_TypeCar("Truck", (bool)TypeCar_check.IsChecked); }
            else if (groupTypeCar.SelectedIndex == 3)
            { grid_Select.DataContext = MyFactoryBL.Instance.group_by_TypeCar("Van", (bool)TypeCar_check.IsChecked); }
        }
    }
}
