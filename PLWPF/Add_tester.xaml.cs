using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace PLWPF
{
    /// <summary>
    /// Logique d'interaction pour Diff_menus.xaml
    /// </summary>
    public partial class Add_tester : System.Windows.Controls.UserControl
    {
        bool2dimListDays converter = new bool2dimListDays();
        public delegate void AddTesterEventHandler(object source, EventArgs args);
        public event AddTesterEventHandler AddTester;

        public BE.Tester newTester = null;
        public BE.Address newAddress;

        public List<work_days> listDays;
        public Add_tester()
        {
            InitializeComponent();
            for (int i = 1; i <= 99; i++)
            { combo_tester_Experience.Items.Add(i); }
            for (int i = 1; i <= 50; i++)
            { combo_tester_MaxTest.Items.Add(i); }
            listDays = new List<work_days>();
            foreach (var day in Enum.GetNames(typeof(DayWeek)))
            { listDays.Add(new work_days(day)); }

            foreach (var type in Enum.GetNames(typeof(TypeCar)))
            { combo_tester_TypeCar.Items.Add(type); }

            dataGrid_WorkDay.DataContext = listDays;

            //****************************************************************
            //Creation Tester for binding & validation & DataContext
            newTester = new BE.Tester();

            BE.Address newAddress = new BE.Address { City = "", Num = 0, Street = "" };

            newTester.BirthDay = DateTime.Now;

            this.DataContext = newTester;

            //****************************************************************
        }

        private void button_tester_add_Click(object sender, RoutedEventArgs e)
        {
            //*****Validation structure Address****
            string textToCheck = FieldValidation.IsValidText(text_City.Text);

            if (textToCheck != "")
            {
                MessageBox.Show(textToCheck + " City");
                return;
            }
            else
            { newAddress.City = text_City.Text; }

            textToCheck = FieldValidation.IsValidText(text_Street.Text);

            if (textToCheck != "")
            {
                MessageBox.Show(textToCheck + " Street");
                return;
            }
            else
            { newAddress.Street = text_Street.Text; }

            textToCheck = FieldValidation.IsValidNum(text_Num.Text);

            if (textToCheck != "")
            {
                MessageBox.Show(textToCheck + " Num Street");
                return;
            }
            else
            { newAddress.Num = int.Parse(text_Num.Text); }

            if (!FieldValidation.IsValid(this))
            { MessageBox.Show("Correct the errors before adding the Tester!"); }
            else
            {
                newTester.ID = text_tester_ID.Text;
                newTester.FirstName = text_tester_firstName.Text;
                newTester.LastName = text_tester_lastName.Text;

                //Adding Address  
                newTester.address = newAddress;

                newTester.Phone = text_tester_phone.Text;
                newTester.Xp = (int)combo_tester_Experience.SelectedItem;
                newTester.BirthDay = datepicker_tester_birthday.SelectedDate.Value;
                newTester.Max_test = (int)combo_tester_MaxTest.SelectedItem;
                newTester.Type_car = (TypeCar)combo_tester_TypeCar.SelectedIndex;
                newTester.Work_day = (bool[,])converter.ConvertBack(listDays, null, null, null);

                try
                {
                    MyFactoryBL.Instance.check_add_tester(newTester);
                    MessageBox.Show("Tester was added successfully!");
                    OnAddTester();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error); }
            }

        }

        private void button_tester_Workday_Click(object sender, RoutedEventArgs e)
        {
            if (myPopupWorkday.IsOpen == false)
            { myPopupWorkday.IsOpen = true; }
            else
            { myPopupWorkday.IsOpen = false; }
        }

        private void button_tester_Adrress_Click(object sender, RoutedEventArgs e)
        {
            if (myPopup_Address.IsOpen == false)
            { myPopup_Address.IsOpen = true; }
            else
            { myPopup_Address.IsOpen = false; }
        }

        protected virtual void OnAddTester()
        {
            if (AddTester != null)
                AddTester(this, EventArgs.Empty);
            resetfield();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        { combo_tester_TypeCar.SelectedIndex = -1; }

        public void resetfield()
        {
            InitializeComponent();
            newTester = new BE.Tester();
            newAddress = new BE.Address { City = "", Num = 0, Street = "" };
            text_City.Text = ""; text_Num.Text = ""; text_Street.Text = "";
            newTester.BirthDay = DateTime.Now;
            this.DataContext = newTester;
        }
    }
}
