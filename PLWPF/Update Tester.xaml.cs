using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    
    /// <summary>
    /// Logique d'interaction pour Update_Tester.xaml
    /// </summary>
    public partial class Update_Tester : Window
    {
        public delegate void UpTesterEventHandler(object source, EventArgs args);
        public event UpTesterEventHandler UpTester;
        public List<work_days> listDays { get; set; }
        public bool2dimListDays myConverter = new bool2dimListDays();

        public Tester t1;
        public Address upAddress;
        public Update_Tester(Tester t)
        {
            InitializeComponent();
            t1 = new Tester(t);
            gridUpTester.DataContext = t1;
            for (int i = 1; i <= 99; i++)
            { combo_tester_Experience.Items.Add(i); }
            combo_tester_Experience.SelectedItem = t1.Xp;
            for (int i = 1; i <= 50; i++)
            { combo_tester_MaxTest.Items.Add(i); }
            combo_tester_MaxTest.SelectedItem = t1.Max_test;
            listDays = (List<work_days>)myConverter.Convert(t1.Work_day,null,null,null);
            combo_tester_TypeCar.ItemsSource = Enum.GetValues(typeof(TypeCar));
            combo_tester_TypeCar.SelectedItem = t1.Type_car;
            dataGrid_WorkDay.DataContext = listDays;
            upAddress = t1.address;
            myPopup_Address.DataContext = upAddress;
        }

        private void button_tester_Up_Click(object sender, RoutedEventArgs e)
        {
            string textToCheck = FieldValidation.IsValidText(text_City.Text);

            if (textToCheck != "")
            {
                MessageBox.Show(textToCheck + " City");
                return;
            }
            else
            { upAddress.City = text_City.Text; }

            textToCheck = FieldValidation.IsValidText(text_Street.Text);

            if (textToCheck != "")
            {
                MessageBox.Show(textToCheck + " Street");
                return;
            }
            else
            { upAddress.Street = text_Street.Text; }

            textToCheck = FieldValidation.IsValidNum(text_Num.Text);

            if (textToCheck != "")
            {
                MessageBox.Show(textToCheck + " Num Street");
                return;
            }
            else
            { upAddress.Num = int.Parse(text_Num.Text); }

            if (!FieldValidation.IsValid(this))
            { MessageBox.Show("Correct the errors before adding the Tester!"); }
            else
            {
                /*string i = text_tester_ID.Text;
                string n1 = text_tester_firstName.Text;
                string n2 = text_tester_lastName.Text;
                Address A = new Address(); A.City = text_City.Text; A.Num = int.Parse(text_Num.Text); A.Street = text_Street.Text;
                string p = text_tester_phone.Text;
                int x = (int)combo_tester_Experience.SelectedItem;
                DateTime d = (DateTime)datepicker_tester_birthday.SelectedDate;
                int m = (int)combo_tester_MaxTest.SelectedItem;
                TypeCar typ = (TypeCar)combo_tester_TypeCar.SelectedIndex;
                bool[,] w = (bool[,])myConverter.ConvertBack(listDays, null, null, null);
                Tester tester = new Tester(i, n2, n1, d, p, x, m, typ, w, A);*/
                t1.Work_day = (bool[,])myConverter.ConvertBack(listDays, null, null, null);
                t1.address = upAddress;
                t1.Xp = combo_tester_Experience.SelectedIndex + 1;
                t1.Type_car = (TypeCar)combo_tester_TypeCar.SelectedIndex;
                t1.Max_test = combo_tester_MaxTest.SelectedIndex + 1;
                try
                {
                    MyFactoryBL.Instance.update_tester(t1);
                    myWin.Close();
                    MessageBox.Show("Tester was updated successfully!");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }

        private void OnUpTester()
        {
            if (UpTester != null)
                UpTester(this, EventArgs.Empty);
        }

        private void button_tester_Adrress_Click(object sender, RoutedEventArgs e)
        {
            if (myPopup_Address.IsOpen == false)
            { myPopup_Address.IsOpen = true; }
            else
            { myPopup_Address.IsOpen = false; }
        }

        private void button_tester_Workday_Click(object sender, RoutedEventArgs e)
        {
            if (myPopupWorkday.IsOpen == false)
            { myPopupWorkday.IsOpen = true; }
            else
            { myPopupWorkday.IsOpen = false; }
        }

        private void Window_Closed(object sender, EventArgs e)
        { OnUpTester(); }
    }
}
