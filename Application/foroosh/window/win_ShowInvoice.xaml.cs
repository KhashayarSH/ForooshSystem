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
using DataModelLayer;
using foroosh.Module;


namespace foroosh.window
{
    /// <summary>
    /// Interaction logic for win_ShowInvoice.xaml
    /// </summary>
    public partial class win_ShowInvoice : Window
    {
        public win_ShowInvoice()
        {
            InitializeComponent();
        }

      

        //private void InitializeComponent()
        //{
        //    throw new NotImplementedException();
        //}

        forooshEntities database = new forooshEntities();
      

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var query = from u in database.Vw_Users select u;
            //var user = query.ToList();
            //dataGrid_user.ItemsSource = user;

            ShowInvoiceInfo(SearchStatement);
        }
        ////// متد ارتباط با پایگاه داده و نمایش اطلاعات در دیتا گرید
        private void ShowInvoiceInfo(Func<string> SearchStringForUsers)
        {
            var query = database.Database.SqlQuery<vw_invoice>("Select * From vw_invoice where 1=1 and userid =  " + PublicVariable.gUserId + " "  + SearchStringForUsers());
            //MessageBox.Show(query.ToString());
            //  var u = query.ToList();
            var u = query.ToList();
            dataGrid_showinvoice.ItemsSource = u;

        }
        ///// تابع ساخت شرط برای نمایش اضلاعات در دیتا گرید
        private string SearchStatement()
        {

            string searchstring = " and InvoiceDate between '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_az.Text)) + "' and '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_ta.Text)) + "'";
            if ((txt_Name.Text!= ""))
            {
                searchstring += " and CustomerName Like '%" + txt_Name.Text.Trim() + "%'";
            }
            
            if (!string.IsNullOrEmpty(txt_tel.Text.Trim()))  
            {
                searchstring += " and CustomerTell Like '%" + txt_tel.Text.Trim() + "%'";
            }
            if (rdb_allforoosh.IsChecked == true)
            {
                searchstring += " and InvoiceType =1";
            }
            else if (rdb_allreturn.IsChecked == true)
            {
                searchstring += " and InvoiceType = 2";
            }


            return searchstring;
        }
        
        private void imge_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void image_search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowInvoiceInfo(SearchStatement);
        }

        private void btn_newInvoice_Click(object sender, RoutedEventArgs e)
        {
            win_invoice w_i = new win_invoice();
            w_i.Win_type = 1;
            w_i.ShowDialog();
            ShowInvoiceInfo(SearchStatement);
        }

        private void btn_editInvoice_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGrid_showinvoice.SelectedItem;
            win_invoice w_i = new win_invoice();

            if (item == null)
            {
                return;
            }
            else
            {
                w_i.Win_type = 2;//////////edit
                w_i.InvoiceId = Convert.ToInt32((dataGrid_showinvoice.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                w_i.CustomerName = (dataGrid_showinvoice.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                w_i.InvoiceDate = (dataGrid_showinvoice.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                w_i.InvoicePrice_foroosh = Convert.ToInt64((dataGrid_showinvoice.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text);
                w_i.InvoicePrice_kharid = Convert.ToInt64((dataGrid_showinvoice.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text);
                w_i.ShowDialog();
            }



            
            ShowInvoiceInfo(SearchStatement);
        }


        //
        private void btn_ActiveCustomer_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("آیا از فعال کردن مشتری اطمینان دارید؟", "فعال کردن مشتری", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    object item = dataGrid_showinvoice.SelectedItem;
                    int CustomerID;
                    CustomerID = Convert.ToInt32((dataGrid_showinvoice.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    Customer C = (from Cu in database.Customers where Cu.CustomerID == CustomerID select Cu).SingleOrDefault();
                    C.CustomerActive = 1;
                    database.SaveChanges();
                    MessageBox.Show("مشتری  با موفقیت فعال شد");
                    ShowInvoiceInfo(SearchStatement);
                }
                catch
                {
                    MessageBox.Show("در ثبت اطلاعات مشکلی بوجود آمد");
                    return;
                }
            }
        }
        private void bt_returnInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("آیا از برگشت دادن فاکتور اطمینان دارید؟", "برگشت دادن فاکتور", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    object item = dataGrid_showinvoice.SelectedItem;
                    int InvoiceID;
                    InvoiceID = Convert.ToInt32((dataGrid_showinvoice.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    Invoice I = (from Inv in database.Invoices where Inv.InvoiceId == InvoiceID select Inv).SingleOrDefault();
                    I.InvoiceType = 2;
                    database.SaveChanges();
                    MessageBox.Show("فاکتور با موفقیت مرجوع شد");
                    ShowInvoiceInfo(SearchStatement);
                }
                catch
                {
                    MessageBox.Show("در ثبت اطلاعات مشکلی بوجود آمد");
                    return;
                }
            }
        }
    }
}
