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
    /// Logique d'interaction pour Update_Trainee.xaml
    /// </summary>
    public partial class Update_Trainee : Window
    {
        public delegate void UpTraineeEventHandler(object source, EventArgs args);
        public event UpTraineeEventHandler UpTrainee;

        public Trainee t1 = null;
        public Address upAddress;
        public Update_Trainee(Trainee trnee)
        {
            InitializeComponent();
            t1 = new Trainee(trnee);
            UpdateTrainee.DataContext = t1;

            combo_trainee_Gender.ItemsSource = Enum.GetValues(typeof(Gender));
            combo_trainee_Gender.SelectedIndex = (int)t1.gender;

            upAddress = t1.address;
            myPopup.DataContext = upAddress;
        }

        private void button_trainee_update_Click(object sender, RoutedEventArgs e)
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
                t1.gender = (Gender)combo_trainee_Gender.SelectedIndex;
                t1.address = upAddress;
                try
                {
                    MyFactoryBL.Instance.update_trainee(t1);
                    myWin.Close();
                    MessageBox.Show("Trainee was Updated successfully!");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }

        private void button_trainee_Adrress_Click(object sender, RoutedEventArgs e)
        {
            if (myPopup.IsOpen == false)
            { myPopup.IsOpen = true; }
            else
            { myPopup.IsOpen = false; }
        }

        protected virtual void OnUpTrainee()
        {
            if (UpTrainee != null)
                UpTrainee(this, EventArgs.Empty);
        }

        private void myWin_Closed(object sender, EventArgs e)
        { OnUpTrainee(); }
    }
}
