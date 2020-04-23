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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Nanny().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Child().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new Nanny().ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new DelNanny().ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new Mother().ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            new DelChild().ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            new DelMother().ShowDialog();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            new Contract().ShowDialog();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            new DelContract().ShowDialog();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            new SeeMothers().ShowDialog();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            new SeeContract().ShowDialog();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            new SeeChild().ShowDialog();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            new SeeNanny().ShowDialog();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            new BuildContract().ShowDialog();
        }



        //private void Button_Click_9(object sender, RoutedEventArgs e)
        //{
        //    BE.Mother c=new BE.Mother();
        //    BL.IBL myBL = BL.FactoryBL.GetBL();
        //    c.BabyAddress = "jngkjfdgjfdkn";
        //    c.Hearot1 = "dfsfds f ffdsf";
        //    c.MomAddress = "fretetre re";
        //    c.MomFirstName = "sdfdgfdg";
        //    c.MomId = "54646456";
        //    c.MomLastName = "fdsfd";
        //    c.MomPhone = "435435435443";
        //    c.Days = new bool[6];
        //    c.Times = new string[6][];
        //    for(int i=0;i<2;i++)
        //    {
        //        c.Days[i] = true;
        //        c.Times[i] = new string[2];
        //        c.Times[i][0] = "12:00";
        //        c.Times[i][1] = "18:00";
        //    }
        //    for(int i=2;i<6;i++)
        //    {
        //        c.Days[i] = false;
        //        c.Times[i] = new string[2];
        //        c.Times[i][0] = "00:00";
        //        c.Times[i][1] = "00:00";
        //    }
        //    myBL.AddMother(c);
        //}
    }
}
