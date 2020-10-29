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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;
using System.Text.RegularExpressions;

namespace PLWPF
{
    /// <summary>
    /// Logique d'interaction pour Add_trainee1.xaml
    /// </summary>
    public partial class Add_trainee : UserControl
    {
        public delegate void AddTraineeEventHandler(object source, EventArgs args);
        public event AddTraineeEventHandler AddTrainee;

        public Trainee newTrainee = null;
        public BE.Address newAddress;

        public Add_trainee()
        {
            InitializeComponent();
            combo_trainee_Gender.ItemsSource = Enum.GetNames(typeof(Gender));

            //****************************************************************
            //Creation Trainee for binding & validation & DataContext
            newTrainee = new BE.Trainee();

            BE.Address newAddress = new BE.Address { City = "", Num = 0, Street = "" };

            newTrainee.BirthDay = DateTime.Now;

            this.DataContext = newTrainee;

            //****************************************************************
        }

        private void button_trainee_add_Click(object sender, RoutedEventArgs e)
        {
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
                newTrainee.ID = text_trainee_ID.Text;
                newTrainee.Name = text_trainee_Name.Text;
                newTrainee.address = newAddress;
                newTrainee.Phone = text_trainee_phone.Text;
                newTrainee.BirthDay = datepicker_trainee_birthday.SelectedDate.Value;
                newTrainee.gender = (Gender)combo_trainee_Gender.SelectedIndex;
                try
                {
                    MyFactoryBL.Instance.check_add_trainee(newTrainee);
                    MessageBox.Show("Trainee was added successfully!");
                    OnAddTrainee();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }

        protected virtual void OnAddTrainee()
        {
            if (AddTrainee != null)
                AddTrainee(this, EventArgs.Empty);
        }

        private void button_trainee_Adrress_Click(object sender, RoutedEventArgs e)
        {
            if (myPopup.IsOpen == false)
            { myPopup.IsOpen = true; }
            else
            { myPopup.IsOpen = false; }
        }

    }
}
