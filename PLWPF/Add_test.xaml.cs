using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
using System.Text.RegularExpressions;


namespace PLWPF////////////////////// Verification of the field in XAML with regex
{
    /// <summary>
    /// Logique d'interaction pour Add_T.xaml
    /// </summary>
    public partial class Add_test : UserControl
    {
        public delegate void AddTestEventHandler(object source, EventArgs args);
        public event AddTestEventHandler AddTest;

        public Test newTest = null;
        public Address newAddress1;
        public Address newAddress2;
        public dateHour H;
        public Add_test()
        {
            InitializeComponent();
            foreach (var type in Enum.GetNames(typeof(TypeCar)))
            { combo_test_typecar.Items.Add(type); }

            combo_test_hour.Items.Add("Select");
            for (int i = 10; i < 20; i++)
            { combo_test_hour.Items.Add(string.Format("F{0}T{1}",i,i+1)); }

            //****************************************************************
            //Creation Test for binding & validation & DataContext
            int a = 0;
            newTest = new BE.Test(a);

            BE.Address newAddress1 = new BE.Address { City = "", Num = 0, Street = "" };
            BE.Address newAddress2 = new BE.Address { City = "", Num = 0, Street = "" };
            H = new dateHour();
            H.Hour = 0;

            newTest.Date_test = DateTime.Now;
            combo_test_hour.DataContext = H;
            this.DataContext = newTest;

            //****************************************************************
        }

        private void button_test_add_Click(object sender, RoutedEventArgs e)
        {
            //*****Validation structure Address**** (First address)
            string textToCheck = FieldValidation.IsValidText(text_City_AddS.Text);
            if (textToCheck != "")
            {
                MessageBox.Show(textToCheck + " City");
                return;
            }
            else
            { newAddress1.City = text_City_AddS.Text; }

            textToCheck = FieldValidation.IsValidText(text_Street_AddS.Text);
            if (textToCheck != "")
            {
                MessageBox.Show(textToCheck + " Street");
                return;
            }
            else
            { newAddress1.Street = text_Street_AddS.Text; }

            textToCheck = FieldValidation.IsValidNum(text_Num_AddS.Text);
            if (textToCheck != "")
            {
                MessageBox.Show(textToCheck + " Num Street");
                return;
            }
            else
            { newAddress1.Num = int.Parse(text_Num_AddS.Text); }

            //*****Validation structure Address**** (Second address)
            textToCheck = FieldValidation.IsValidText(text_City_AddE.Text);
            if (textToCheck != "")
            {
                MessageBox.Show(textToCheck + " City");
                return;
            }
            else
            { newAddress2.City = text_City_AddE.Text; }

            textToCheck = FieldValidation.IsValidText(text_Street_AddE.Text);
            if (textToCheck != "")
            {
                MessageBox.Show(textToCheck + " Street");
                return;
            }
            else
            { newAddress2.Street = text_Street_AddE.Text; }

            textToCheck = FieldValidation.IsValidNum(text_Num_AddE.Text);
            if (textToCheck != "")
            {
                MessageBox.Show(textToCheck + " Num Street");
                return;
            }
            else
            { newAddress2.Num = int.Parse(text_Num_AddE.Text); }

            if (DateTime.Now.CompareTo(datepicker_test_date.SelectedDate.Value) >= 0)
            {
                MessageBox.Show("the date has already passed");
                return;
            }

            /*if (combo_test_hour.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a hour!");
                return;
            }*/

            if (!FieldValidation.IsValid(this))
            { MessageBox.Show("Correct the errors before adding the Tester!"); }
            else
            {
                newTest.Address_test_start = newAddress1;
                newTest.Address_test_end = newAddress2;
                newTest.Date_test = datepicker_test_date.SelectedDate.Value.AddHours(H.Hour + 9);
                newTest.ID_trainee = text_test_traineeID.Text;
                newTest.typeCar = (TypeCar)combo_test_typecar.SelectedIndex;
                try
                {
                    MyFactoryBL.Instance.check_add_test(newTest);
                    MessageBox.Show("Test was added successfully!");
                    OnAddTest();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }

        private void button_tester_AdrressEnd_Click(object sender, RoutedEventArgs e)
        {
            if (myPopup_AddressEnd.IsOpen == false)
            { myPopup_AddressEnd.IsOpen = true; }
            else
            { myPopup_AddressEnd.IsOpen = false; }
        }

        private void button_tester_AdrresStart_Click(object sender, RoutedEventArgs e)
        {
            if (myPopup_AddresStart.IsOpen == false)
            { myPopup_AddresStart.IsOpen = true; }
            else
            { myPopup_AddresStart.IsOpen = false; }
        }
        protected virtual void OnAddTest()
        {
            if (AddTest != null)
                AddTest(this, EventArgs.Empty);
            resetfield();
        }
        private void resetfield()////////////// OK!
        {
            InitializeComponent();
            int a = 0;
            newTest = new BE.Test(a);
            newAddress1 = new BE.Address { City = "", Num = 0, Street = "" };
            newAddress2 = new BE.Address { City = "", Num = 0, Street = "" };
            text_City_AddS.Text = ""; text_Num_AddS.Text = ""; text_Street_AddS.Text = "";
            text_City_AddE.Text = ""; text_Num_AddE.Text = ""; text_Street_AddE.Text = "";
            newTest.Date_test = DateTime.Now;
            H.Hour = 0;
            this.DataContext = newTest;
        }
    }
    public class dateHour
    {
        public int Hour { get; set; }
    }
}
