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
    /// Interaction logic for SeeMothers.xaml
    /// </summary>
    public partial class SeeMothers : Window
    {
        BE.Mother corentMother = new BE.Mother();
        BL.IBL myBL = BL.FactoryBL.GetBL();
        public SeeMothers()
        {
           
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            corentMother = myBL.SearchMother(x => x.MomId == momidtxt.Text).FirstOrDefault();
            List<BE.Mother> list = new List<BE.Mother>();
            list.Add(corentMother);
            listBox.ItemsSource = list;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<BE.Mother> temp = myBL.GetMotherList();
            listBox.ItemsSource = temp;
        }

        private void listBox_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }
    }
}
