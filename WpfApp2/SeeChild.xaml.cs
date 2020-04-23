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
    /// Interaction logic for SeeChild.xaml
    /// </summary>
    public partial class SeeChild : Window
    {
        BE.Child corentchild = new BE.Child();
        BL.IBL myBL = BL.FactoryBL.GetBL();
        public SeeChild()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            corentchild = myBL.SearchChild(x => x.ChildId == idchildtxt.Text).FirstOrDefault();
            List<BE.Child> list = new List<BE.Child>();
            list.Add(corentchild);
            listBox.ItemsSource = list;
        }

        private void ListBox_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<BE.Child> list = new List<BE.Child>();
            list = myBL.GetChildMothers(momidtxt.Text);
            listBox.ItemsSource = list;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<BE.Child> list = new List<BE.Child>();
            list = myBL.ChildWithoutNanny();
            listBox.ItemsSource = list;
        }

        private void listBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            BuildContract frm = new BuildContract(((BE.Child)(listBox.SelectedItem)).ChildId);
            frm.Show();
            this.Close();
        }
    }
}
