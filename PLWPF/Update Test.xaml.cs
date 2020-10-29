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
    /// Logique d'interaction pour Update_Test.xaml
    /// </summary>
    public partial class Update_Test : Window
    {
        public delegate void UpTestEventHandler(object source, EventArgs args);
        public event UpTestEventHandler UpTest;

        public Test myT;
        public Address newAddress1;
        public Address newAddress2;
        public dateHour H;
        public Update_Test(Test t)
        {
            InitializeComponent();
            myT = new Test(t);
            myGrid.DataContext = myT;
            combo_test_typecar.ItemsSource = Enum.GetValues(typeof(TypeCar));
            combo_test_typecar.SelectedItem = myT.typeCar;

            H = new dateHour();
            H.Hour = myT.Date_test.Hour - 9;
            combo_test_hour.Items.Add("Select");
            for (int i = 10; i < 20; i++)
            { combo_test_hour.Items.Add(string.Format("F{0}T{1}", i, i + 1)); }
            combo_test_hour.DataContext = H;
            //combo_test_hour.SelectedItem = ;

            newAddress1 = myT.Address_test_start;
            newAddress2 = myT.Address_test_end;

            myPopup_AddresStart.DataContext = newAddress1;
            myPopup_AddressEnd.DataContext = newAddress2;
        }

        private void OnUpTest()
        {
            if (UpTest != null)
                UpTest(this, EventArgs.Empty);
        }

        private void myWin_Closed(object sender, EventArgs e)
        { OnUpTest(); }

        private void button_test_update_Click(object sender, RoutedEventArgs e)
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

            if (!FieldValidation.IsValid(this))
            { MessageBox.Show("Correct the errors before adding the Tester!"); }
            else
            {
                myT.Address_test_start = newAddress1;
                myT.Address_test_end = newAddress2;
                myT.Date_test = datepicker_test_date.SelectedDate.Value.AddHours(combo_test_hour.SelectedIndex + 9);
                myT.typeCar = (TypeCar)combo_test_typecar.SelectedIndex;
                try
                {
                    MyFactoryBL.Instance.update_test(myT);
                    myWin.Close();
                    MessageBox.Show("Test was Updated successfully!");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }

        private void button_tester_AdrresStart_Click(object sender, RoutedEventArgs e)
        {
            if (myPopup_AddresStart.IsOpen == false)
            { myPopup_AddresStart.IsOpen = true; }
            else
            { myPopup_AddresStart.IsOpen = false; }
        }

        private void button_tester_AdrressEnd_Click(object sender, RoutedEventArgs e)
        {
            if (myPopup_AddressEnd.IsOpen == false)
            { myPopup_AddressEnd.IsOpen = true; }
            else
            { myPopup_AddressEnd.IsOpen = false; }
        }

    }
}
