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
    /// Interaction logic for Child.xaml
    /// </summary>
    public partial class Child : Window
    {
        BE.Child corentchild=new BE.Child();
        BL.IBL myBL = BL.FactoryBL.GetBL();
       
        public Child()
        {
            InitializeComponent();
            corentchild = new BE.Child();
            this.momIdComboBox.ItemsSource = myBL.GetMotherList();
            this.momIdComboBox.DisplayMemberPath = "MomId";
            this.momIdComboBox.SelectedValuePath = "MomId";
            this.grid1.DataContext = corentchild;
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                corentchild.MomId = momIdComboBox.Text;
                myBL.AddChild(corentchild);
                MessageBox.Show("succeed!!");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            corentchild = myBL.SearchChild(x => x.ChildId == childIdTextBox.Text).FirstOrDefault();
            if (corentchild == null)
                MessageBox.Show("canot fint this child");
            this.grid1.DataContext = corentchild;
        }
        public bool IsNumber(string text)
        {
            int output;
            return int.TryParse(text, out output);
        }
        private void childIdTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (IsNumber(e.Text) == false)
                e.Handled = true;
        }

        private void childIdTextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
            ((TextBox)(sender)).MaxLength = 9;
            if (Keyboard.IsKeyDown(Key.Back))
                return;
          ((TextBox)(sender)).SelectionStart = ((TextBox)(sender)).Text.Length;
        }
    }
}
