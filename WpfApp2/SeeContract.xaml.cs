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
    /// Interaction logic for SeeContract.xaml
    /// </summary>
    public partial class SeeContract : Window
    {
        BE.Contract corentContract=new BE.Contract();
        BL.IBL myBL = BL.FactoryBL.GetBL();
        public SeeContract()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            corentContract = myBL.SearchContract(x => x.ContractCode == Convert.ToInt32(idtxt.Text)).FirstOrDefault();
            List<BE.Contract> list = new List<BE.Contract>();
            list.Add(corentContract);
            listBox.ItemsSource = list;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<BE.Contract> list = new List<BE.Contract>();
            list = myBL.GetCOntracts();
            listBox.ItemsSource = list;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            corentContract = myBL.SearchContract(x => x.MomId == idmomtxxt.Text).FirstOrDefault();
            List<BE.Contract> list = new List<BE.Contract>();
            list.Add(corentContract);
            listBox.ItemsSource = list;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            corentContract = myBL.SearchContract(x => x.NannyID == idnannytxt.Text).FirstOrDefault();
            List<BE.Contract> list = new List<BE.Contract>();
            list.Add(corentContract);
            listBox.ItemsSource = list;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            IEnumerable<BE.Contract> contract = myBL.SearchContract(x => x.ChildID == idchildtxt.Text);
            List<BE.Contract> list = new List<BE.Contract>();
            foreach (BE.Contract item in contract)
                list.Add(item);     
            listBox.ItemsSource = list;
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
