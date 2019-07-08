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


namespace foroosh.window
{
    /// <summary>
    /// Interaction logic for win_customers.xaml
    /// </summary>
    public partial class win_customer : Window
    {
        public win_customer()
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

            ShowCustomerInfo(SearchStatement);
        }
        ////// متد ارتباط با پایگاه داده و نمایش اطلاعات در دیتا گرید
        private void ShowCustomerInfo(Func<string> SearchStringForUsers)
        {
            var query = database.Database.SqlQuery<Vw_Customer>("Select * From Vw_Customer where 1=1" + SearchStringForUsers());
            //MessageBox.Show(query.ToString());
            //  var u = query.ToList();
            var u = query.ToList();
            dataGrid_customer.ItemsSource = u;
        }
        ///// تابع ساخت شرط برای نمایش اضلاعات در دیتا گرید
        private string SearchStatement()
        {

            string searchstring = " and StartDate between '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_az.Text)) + "' and '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_ta.Text)) + "'";
            if ((txt_Name.Text!= ""))
            {
                searchstring += " and CustomerName Like '%" + txt_Name.Text.Trim() + "%'";
            }
            if ((txt_address.Text != ""))
            {
                searchstring += " and CustomerAddress Like '%" + txt_address.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txt_tel.Text.Trim()))  
            {
                searchstring += " and CustomerTell Like '%" + txt_tel.Text.Trim() + "%'";
            }
            if (rdb_active.IsChecked == true)
            {
                searchstring += " and CustomerActive =1";
            }
            else if (rdb_deactive.IsChecked == true)
            {
                searchstring += " and CustomerActive = 2";
            }


            return searchstring;
        }
        
        private void imge_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void image_search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowCustomerInfo(SearchStatement);
        }

        private void btn_newcustomer_Click(object sender, RoutedEventArgs e)
        {
            win_add_edit_customer w_ae = new win_add_edit_customer();
            w_ae.win_Type = 1;//به منظور افزودن مشتری 
            w_ae.ShowDialog();
            ShowCustomerInfo(SearchStatement);
        }

        private void btn_editcustomer_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGrid_customer.SelectedItem;
            win_add_edit_customer w_ae = new win_add_edit_customer();
            w_ae.win_Type = 2;//به منظور بروزرسانی اطلاعات مشتری
            if (item==null)
            {
                MessageBox.Show("ابتدا یک مشتری را انتخاب نمایید");
                return;
            }
            w_ae.CID = Convert.ToInt32((dataGrid_customer.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            w_ae.CName= (dataGrid_customer.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            w_ae.CTel= (dataGrid_customer.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            w_ae.CAddress= (dataGrid_customer.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;


            w_ae.ShowDialog();
            ShowCustomerInfo(SearchStatement);
        }


        //
        private void btn_ActiveCustomer_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("آیا از فعال کردن مشتری اطمینان دارید؟", "فعال کردن مشتری", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    object item = dataGrid_customer.SelectedItem;
                    int CustomerID;
                    CustomerID = Convert.ToInt32((dataGrid_customer.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    Customer C = (from Cu in database.Customers where Cu.CustomerID == CustomerID select Cu).SingleOrDefault();
                    C.CustomerActive = 1;
                    database.SaveChanges();
                    MessageBox.Show("مشتری  با موفقیت فعال شد");
                    ShowCustomerInfo(SearchStatement);
                }
                catch
                {
                    MessageBox.Show("در ثبت اطلاعات مشکلی بوجود آمد");
                    return;
                }
            }
        }
        private void bt_delcustomer_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("آیا از غیرفعال کردن مشتری اطمینان دارید؟", "غیرفعال کردن مشتری", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    object item = dataGrid_customer.SelectedItem;
                    int CustomerID;
                    CustomerID = Convert.ToInt32((dataGrid_customer.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    Customer C = (from Cu in database.Customers where Cu.CustomerID == CustomerID select Cu).SingleOrDefault();
                    C.CustomerActive = 2;
                    database.SaveChanges();
                    MessageBox.Show("مشتری  با موفقیت غیرفعال شد");
                    ShowCustomerInfo(SearchStatement);
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
