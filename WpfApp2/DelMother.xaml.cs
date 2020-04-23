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
    /// Interaction logic for DelMother.xaml
    /// </summary>
    public partial class DelMother : Window
    {
        BE.Mother corentMother;
        BL.IBL myBL = BL.FactoryBL.GetBL();

        public DelMother()
        {
            InitializeComponent();
            corentMother = new BE.Mother();
            this.grid1.DataContext = corentMother;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

         //   System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            corentMother = myBL.SearchMother(x => x.MomId == momIdTextBox.Text).FirstOrDefault();
            if (corentMother == null)
                MessageBox.Show("cant find this mother");
            else
            {
                momFirstNameTextBox.Text = corentMother.MomFirstName;
                momLastNameTextBox.Text = corentMother.MomLastName;
                momPhoneTextBox.Text = corentMother.MomPhone;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                myBL.DelMother(momIdTextBox.Text);
                MessageBox.Show("deleted");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
