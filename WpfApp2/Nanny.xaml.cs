
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
    /// Interaction logic for Nanny.xaml
    /// </summary>
    public partial class Nanny : Window
    {
        BE.Nanny contractNanny;
        BL.IBL myBL = BL.FactoryBL.GetBL();
        public Nanny()
        {
           
            InitializeComponent();
            contractNanny = new BE.Nanny();
            this.grid1.DataContext = contractNanny;

        }
        public bool IsNumber(string text)
        {
            int output;
            return int.TryParse(text, out output);
        }

        private void nannyExperienceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
       
        private bool IsTimes(string str)

        {
            if (str == "")
                return false;
            if (str[0] < '0' || str[0] > '2'||str[1]<'0'||str[1]>9||str[2]!=':'||str[3]<'0'||str[3]>'5'||str[4]<'0'||str[4]>'9')
                return false;
            //כאשר עת סיום קטנה יותר??.
            return true;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsTimes(sunS.Text) || IsTimes(monS.Text) || IsTimes(tueS.Text) || IsTimes(wedS.Text) || IsTimes(thuS.Text) || IsTimes(friS.Text) || IsTimes(sunE.Text) || IsTimes(monE.Text) || IsTimes(sueE.Text) || IsTimes(wedE.Text) || IsTimes(thuE.Text) || IsTimes(friE.Text))
                MessageBox.Show("cannot add this nanny");
           
            else
            {
                contractNanny.Days = new bool[6];
                for (int i = 0; i < 6; i++)
                    contractNanny.Times[i] = new string[2];
                if (chsun.IsChecked == true)
                {
                    contractNanny.Days[0] = true;
                    contractNanny.Times[0][0] = sunS.Text;
                    contractNanny.Times[0][1] = sunE.Text;
                }
                else
                {
                    contractNanny.Days[0] = false;
                    contractNanny.Times[0][0] = "00:00";
                    contractNanny.Times[0][1] = "00:00";
                }
                if (chmon.IsChecked == true)
                {
                    contractNanny.Days[1] = true;
                    contractNanny.Times[1][0] = monS.Text;
                    contractNanny.Times[1][1] = monE.Text;
                }
                else
                {
                    contractNanny.Days[1] = false;
                    contractNanny.Times[1][0] = "00:00";
                    contractNanny.Times[1][1] = "00:00";
                }
                if (chthu.IsChecked == true)
                {
                    contractNanny.Days[2] = true;
                    contractNanny.Times[2][0] = tueS.Text;
                    contractNanny.Times[2][1] = sueE.Text;
                }
                else
                {
                    contractNanny.Days[2] = false;
                    contractNanny.Times[2][0] = "00:00";
                    contractNanny.Times[2][1] = "00:00";
                }
                if (chwed.IsChecked == true)
                {
                    contractNanny.Days[3] = true;
                    contractNanny.Times[3][0] = wedS.Text;
                    contractNanny.Times[3][1] = wedE.Text;
                }
                else
                {
                    contractNanny.Days[3] = false;
                    contractNanny.Times[3][0] = "00:00";
                    contractNanny.Times[3][1] = "00:00";
                }
                if (chthu.IsChecked == true)
                {
                    contractNanny.Days[4] = true;
                    contractNanny.Times[4][0] = thuS.Text;
                    contractNanny.Times[4][1] = thuE.Text;
                }
                else
                {
                    contractNanny.Days[4] = false;
                    contractNanny.Times[4][0] = "00:00";
                    contractNanny.Times[4][1] = "00:00";
                }
                if (thfri.IsChecked == true)
                {
                    contractNanny.Days[5] = true;
                    contractNanny.Times[5][0] = friS.Text;
                    contractNanny.Times[5][1] = friE.Text;
                }
                else
                {
                    contractNanny.Days[5] = false;
                    contractNanny.Times[5][0] = "00:00";
                    contractNanny.Times[5][1] = "00:00";
                }
                try
                {

                    myBL.AddNanny(contractNanny);
                    contractNanny = new BE.Nanny();
                    this.DataContext = contractNanny;
                    MessageBox.Show("succeed!");
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tueS_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
                contractNanny = myBL.SearchNany(x => x.NannyId == nannyIdTextBox.Text).FirstOrDefault();
            this.grid1.DataContext = contractNanny;


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void nannyIdTextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((TextBox)(sender)).MaxLength = 9;
            if (Keyboard.IsKeyDown(Key.Back))
                return;
            ((TextBox)(sender)).SelectionStart = ((TextBox)(sender)).Text.Length;
        }

        private void nannyIdTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (IsNumber(e.Text) == false)
                e.Handled = true;
        }
    }
}
