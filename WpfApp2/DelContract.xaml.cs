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
    /// Interaction logic for DelContract.xaml
    /// </summary>
    public partial class DelContract : Window
    {
        BE.Contract corentContract;
        BL.IBL myBL = BL.FactoryBL.GetBL();
        public DelContract()
        {
            InitializeComponent();
            corentContract = new BE.Contract();
            this.grid1.DataContext = corentContract;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

          //  System.Windows.Data.CollectionViewSource contractViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contractViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // contractViewSource.Source = [generic data source]
        }

        private void childIDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            corentContract = myBL.SearchContract(x => x.ContractCode == Convert.ToInt32(codeforsearch.Text)).FirstOrDefault();

            if (corentContract == null)
                MessageBox.Show("cant find this mother");
            else
            {
                childIDTextBox.Text = corentContract.ChildID;
                nannyIDTextBox.Text = corentContract.NannyID;
                momIdTextBox.Text = corentContract.MomId;
                endingDateDatePicker.Text = corentContract.EndingDate.ToLongDateString();
                startingDateDatePicker.Text = corentContract.StartingDate.ToLongDateString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                myBL.DelContract(corentContract);
                MessageBox.Show("deleted");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void childIDTextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
