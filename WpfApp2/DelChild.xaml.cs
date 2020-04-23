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
    /// Interaction logic for DelChild.xaml
    /// </summary>
    public partial class DelChild : Window
    {
        BE.Child corentchild;
        BL.IBL myBL = BL.FactoryBL.GetBL();
        public DelChild()
        {
            InitializeComponent();
            corentchild = new BE.Child();
            this.grid1.DataContext = corentchild;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           // System.Windows.Data.CollectionViewSource childViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("childViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // childViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            corentchild = myBL.SearchChild(x => x.ChildId == childIdTextBox.Text).FirstOrDefault();
            if (corentchild == null)
                MessageBox.Show("canot fint this child");
            else
            {
                childFistNameTextBox.Text = corentchild.ChildFistName;
                momIdTextBox.Text = corentchild.MomId;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                myBL.DelChild(childIdTextBox.Text);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
