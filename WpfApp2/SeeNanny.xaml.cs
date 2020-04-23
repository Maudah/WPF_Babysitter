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
    /// Interaction logic for SeeNanny.xaml
    /// </summary>
    /// 
    
    public partial class SeeNanny : Window
    {
        BE.Nanny contractNanny = new BE.Nanny();
        BL.IBL myBL = BL.FactoryBL.GetBL();
        public SeeNanny()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contractNanny = myBL.SearchNany(x=>x.NannyId==idnannytxt.Text).FirstOrDefault();
            List<BE.Nanny> list = new List<BE.Nanny>();
            list.Add(contractNanny);
            litstBox.ItemsSource = list;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<BE.Nanny> list = new List<BE.Nanny>();
            list = myBL.GetNannyList();
            litstBox.ItemsSource = list;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<BE.Nanny> list = new List<BE.Nanny>();
            list = myBL.TMTNanny();
            litstBox.ItemsSource = list;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
               bool chA, chO;
            if (chbAge.IsChecked == true)
                chA = true;
            else chA = false;
            if (chkOrder.IsChecked == true)
                chO = true;
            else chO = false;
            IEnumerable<IGrouping<int, BE.Nanny>> list = myBL.NannyByChildAge(chA,chO);
            List<BE.Nanny> list1 = new List<BE.Nanny>();
            
            foreach (IGrouping<int, BE.Nanny> item in list)
                foreach(BE.Nanny temp in item)
                {
                    list1.Add(temp);
                }
               
            litstBox.ItemsSource = list1;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            List<BE.Nanny> list = new List<BE.Nanny>();
          
           
            IEnumerable<BE.Nanny> nanny = myBL.NannyForSpacialNeeds();
            foreach (BE.Nanny item in nanny)
            {
                list.Add(item);
            }
            litstBox.ItemsSource = list;

        }
    }
}
