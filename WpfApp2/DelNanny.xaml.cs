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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for DelNanny.xaml
    /// </summary>
    public partial class DelNanny : Window
    {
        BE.Nanny contractNanny;
        BL.IBL myBL = BL.FactoryBL.GetBL();
        public DelNanny()
        {
            InitializeComponent();
            contractNanny = new BE.Nanny();
            this.grid1.DataContext = contractNanny;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contractNanny=myBL.SearchNany(x => x.NannyId == nannyIdTextBox.Text).FirstOrDefault();
            if (contractNanny.NannyId != nannyIdTextBox.Text)
                MessageBox.Show("canot find this nanny");
            else
            {
                nannyBirthDatePicker.Text = contractNanny.NannyBirth.ToLongDateString();
                nannyFirstNameTextBox.Text = contractNanny.NannyFirstName;
                nannyAddressTextBox.Text = contractNanny.NannyAddress;
                nannyLastNameTextBox.Text = contractNanny.NannyLastName;
                nannyPhoneTextBox.Text = contractNanny.NannyPhone;

            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                myBL.DelNanny(nannyIdTextBox.Text);
                MessageBox.Show("deleted");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nannyIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
