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
    /// Interaction logic for Mother.xaml
    /// </summary>
    public partial class Mother : Window
    {
        BE.Mother corentMother;
        BL.IBL myBL = BL.FactoryBL.GetBL();
        public Mother()
        {
            InitializeComponent();
            corentMother = new BE.Mother();
            this.grid1.DataContext = corentMother;
        }
        public bool IsNumber(string text)
        {
            int output;
            return int.TryParse(text, out output);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           // System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }

        private void momLastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         corentMother=   myBL.SearchMother(x => x.MomId == momIdTextBox.Text).FirstOrDefault();
            if (corentMother == null)
                MessageBox.Show("cant find this mother");
            this.grid1.DataContext = corentMother;

        }
        private bool IsTimes(string str)
        {
            if (str == "")
                return true;
            if (str[0] < '0' || str[0] > '2' || str[1] < '0' || str[1] > '9' || str[2] != ':' || str[3] < '0' || str[3] > '5' || str[4] < '0' || str[4] > '9')
                return false;//not fine
            //כאשר עת סיום קטנה יותר??.
            return true;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           // if((chsun.IsChecked==true && (IsTimes(sunS.Text) || IsTimes(sunE.Text))==false)||(chmon.IsChecked==true&&(IsTimes(monS.Text)||IsTimes(monE.Text))==false)||(chtue.IsChecked==true&&(IsTimes(tueS.Text)||IsTimes(sueE.Text))==false)||(chwed.IsChecked==true&&(IsTimes(wedS.Text)|| IsTimes(wedE.Text))==false)||(chtue.IsChecked==true&& (IsTimes(thuE.Text)|| IsTimes(thuS.Text))==false)||(thfri.IsChecked==true&& (IsTimes(friS.Text) || IsTimes(friE.Text))==false))

            if ( IsTimes(sunS.Text)==false || IsTimes(sunE.Text)==false||IsTimes(monS.Text)==false||IsTimes(monE.Text)==false||IsTimes(tueS.Text)==false||IsTimes(sueE.Text)==false||IsTimes(wedS.Text)==false|| IsTimes(wedE.Text)==false||IsTimes(thuE.Text)==false|| IsTimes(thuS.Text)==false||IsTimes(friS.Text)==false || IsTimes(friE.Text)==false)
            {            
                    MessageBox.Show("cannot add this nanny");
            }
            else
            {
                if ((chsun.IsChecked == true && (sunS.Text == "" || sunE.Text == "")) || (chmon.IsChecked == true && (monS.Text == "" || monE.Text == "")) || (chtue.IsChecked == true && (tueS.Text == "" || sueE.Text == "")) || (chwed.IsChecked == true && (wedS.Text == "" || wedE.Text == "")) || (chtue.IsChecked == true && (thuE.Text == "" || thuS.Text == "")) || (thfri.IsChecked == true && (friS.Text == "" || friE.Text == "")))
                {
                    MessageBox.Show("fill the empty fildes");
                }
                else
                {
                    //   corentMother.Times = new string[6][];
                    corentMother.Days = new bool[6];
                    for (int i = 0; i < 6; i++)
                        corentMother.Times[i] = new string[2];
                    if (chsun.IsChecked == true)
                    {
                        corentMother.Days[0] = true;
                        corentMother.Times[0][0] = sunS.Text;
                        corentMother.Times[0][1] = sunE.Text;
                    }
                    else
                    {
                        corentMother.Days[0] = false;
                        corentMother.Times[0][0] = "00:00";
                        corentMother.Times[0][1] = "00:00";
                    }
                    if (chmon.IsChecked == true)
                    {
                        corentMother.Days[1] = true;
                        corentMother.Times[1][0] = monS.Text;
                        corentMother.Times[1][1] = monE.Text;
                    }
                    else
                    {
                        corentMother.Days[1] = false;
                        corentMother.Times[1][0] = "00:00";
                        corentMother.Times[1][1] = "00:00";
                    }
                    if (chthu.IsChecked == true)
                    {
                        corentMother.Days[2] = true;
                        corentMother.Times[2][0] = tueS.Text;
                        corentMother.Times[2][1] = sueE.Text;
                    }
                    else
                    {
                        corentMother.Days[2] = false;
                        corentMother.Times[2][0] = "00:00";
                        corentMother.Times[2][1] = "00:00";
                    }
                    if (chwed.IsChecked == true)
                    {
                        corentMother.Days[3] = true;
                        corentMother.Times[3][0] = wedS.Text;
                        corentMother.Times[3][1] = wedE.Text;
                    }
                    else
                    {
                        corentMother.Days[3] = false;
                        corentMother.Times[3][0] = "00:00";
                        corentMother.Times[3][1] = "00:00";
                    }
                    if (chthu.IsChecked == true)
                    {
                        corentMother.Days[4] = true;
                        corentMother.Times[4][0] = thuS.Text;
                        corentMother.Times[4][1] = thuE.Text;
                    }
                    else
                    {
                        corentMother.Days[4] = false;
                        corentMother.Times[4][0] = "00:00";
                        corentMother.Times[4][1] = "00:00";
                    }
                    if (thfri.IsChecked == true)
                    {
                        corentMother.Days[5] = true;
                        corentMother.Times[5][0] = friS.Text;
                        corentMother.Times[5][1] = friE.Text;
                    }
                    else
                    {
                        corentMother.Days[5] = false;
                        corentMother.Times[5][0] = "00:00";
                        corentMother.Times[5][1] = "00:00";
                    }

                    try
                    {
                        myBL.AddMother(corentMother);
                        corentMother = new BE.Mother();
                        this.DataContext = corentMother;
                        MessageBox.Show("succeed!!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void momIdTextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((TextBox)(sender)).MaxLength = 9;
            if (Keyboard.IsKeyDown(Key.Back))
                return;
            ((TextBox)(sender)).SelectionStart = ((TextBox)(sender)).Text.Length;
        }

        private void momIdTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (IsNumber(e.Text) == false)
                e.Handled = true;
        }
    }
}
