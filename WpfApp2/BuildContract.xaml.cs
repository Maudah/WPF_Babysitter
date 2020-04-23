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
    /// Interaction logic for BuildContract.xaml
    /// </summary>
    public partial class BuildContract : Window
    {
       List<BE.Nanny> contractNannyList=new List<BE.Nanny>();
        BL.IBL myBL = BL.FactoryBL.GetBL();
        BE.Mother mother = new BE.Mother();
        BE.Child child = new BE.Child();
        public BuildContract()
        {
            InitializeComponent();
        }
        public BuildContract(string id)
        {
            InitializeComponent();
            ChilIdtxt.Text = id;
            ChilIdtxt.IsEnabled = false;
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           // System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // nannyViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {               
                child= myBL.SearchChild(x => x.ChildId == ChilIdtxt.Text).FirstOrDefault();
                if (child == null)
                    throw new Exception("הילד המבוקש לא נימצא");
                mother = myBL.SearchMother(x => x.MomId == child.MomId).FirstOrDefault();
                BE.Nanny contractNanny = new BE.Nanny();
                contractNannyList = myBL.PotentionNanny(myBL.SearchChild(x => x.ChildId == ChilIdtxt.Text).FirstOrDefault());
                nannyDataGrid.ItemsSource = contractNannyList;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(contractNannyList.Count==0&& child != null)
            {
                //MessageBox.Show(" לא נמצאו נתונים!להציג את הכי טובים?ו", "no findings!", MessageBoxButton.OKCancel, MessageBoxImage.Hand);
                MessageBoxResult anser= MessageBox.Show(" לא נמצאו נתונים!להציג את הכי טובים?", "no findings!", MessageBoxButton.OKCancel, MessageBoxImage.Hand);
                if(anser==MessageBoxResult.OK)
                {
                    try
                    {
                        child = myBL.SearchChild(x => x.ChildId == ChilIdtxt.Text).FirstOrDefault();
                        mother = myBL.SearchMother(x => x.MomId == child.MomId).FirstOrDefault();
                        BE.Nanny contractNanny = new BE.Nanny();
                        contractNannyList = myBL.FivePotentionNanny(myBL.SearchChild(x => x.ChildId == ChilIdtxt.Text).FirstOrDefault());
                        nannyDataGrid.ItemsSource = contractNannyList;
                        if(contractNannyList.Count==0)
                        {
                            MessageBox.Show("מצטערים אין מטפלת מתאימות כלל");
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void nannyDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            //new Contract(mother.MomId, child.ChildId, nannyDataGrid.SelectedItem.ToString());
        }

        private void nannyDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Contract frm=  new Contract(mother.MomId, child.ChildId, ((BE.Nanny)(nannyDataGrid.SelectedItem)).MyToString());
            frm.Show();
            this.Close();
        }
    }
}
