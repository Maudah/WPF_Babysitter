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
    /// Interaction logic for Contract.xaml
    /// </summary>
    public partial class Contract : Window
    {
        BE.Contract corentContract;
        BL.IBL myBL = BL.FactoryBL.GetBL();

        public Contract()
        {
            InitializeComponent();
            corentContract = new BE.Contract();
            this.grid1.DataContext = corentContract;
        }

        public Contract(string momid,string childid,string nannyid)
        {
            InitializeComponent();
            corentContract = new BE.Contract();
            this.grid1.DataContext = corentContract;
            corentContract.MomId = momid;
            corentContract.NannyID = nannyid;
            corentContract.ChildID = childid;
 
            childIDTextBox.IsEnabled = false;
           
            momIdTextBox.IsEnabled = false;
            
           nannyIDTextBox.IsEnabled = false;
            codeforsearch.IsEnabled = false;
            lbl.IsEnabled = false;
            btn.IsEnabled = false;




        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //System.Windows.Data.CollectionViewSource contractViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contractViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // contractViewSource.Source = [generic data source]
        }
        public bool IsNumber(string text)
        {
            int output;
            return int.TryParse(text, out output);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            corentContract = myBL.SearchContract(x => x.ContractCode==Convert.ToInt32(codeforsearch.Text)).FirstOrDefault();
            if (corentContract == null)
                MessageBox.Show("cant find this contract");
            this.grid1.DataContext = corentContract;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (startingDateDatePicker.DisplayDate >= endingDateDatePicker.DisplayDate || startingDateDatePicker.DisplayDate < DateTime.Now)
                    MessageBox.Show("הקש תאריכים חוקיים!");
                else
                {
                    myBL.AddContract(corentContract);
                    MessageBox.Show("succeed!");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void childIDTextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((TextBox)(sender)).MaxLength = 9;
            if (Keyboard.IsKeyDown(Key.Back))
                return;
            ((TextBox)(sender)).SelectionStart = ((TextBox)(sender)).Text.Length;

        }

        private void nannyIDTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           

        }

        private void childIDTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (IsNumber(e.Text) == false)
                e.Handled = true;
        }
    }
}
