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
    /// Interaction logic for win_product.xaml
    /// </summary>
    public partial class win_product : Window
    {
        public win_product()
        {
            InitializeComponent();
        }

     
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
            cmb_status.Items.Add("همه");
            cmb_status.Items.Add("موجود");
            cmb_status.Items.Add("ناموجود");
            cmb_status.SelectedIndex = 0;

            ShowProductInfo(SearchStatement);
        }
        ////// متد ارتباط با پایگاه داده و نمایش اطلاعات در دیتا گرید
        private void ShowProductInfo(Func<string> SearchStringForUsers)
        {
            var query = database.Database.SqlQuery<Vw_product>("Select * From Vw_product " + SearchStringForUsers());
            //MessageBox.Show(query.ToString());
            //  var u = query.ToList();
            var u = query.ToList();
            dataGrid_product.ItemsSource = u;
        }
        ///// تابع ساخت شرط برای نمایش اضلاعات در دیتا گرید
        private string SearchStatement()
        {

            string searchstring = " where ProductStartDate between '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_az.Text)) + "' and '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_ta.Text)) + "'";
            if ((txt_Name.Text!= ""))
            {
                searchstring += " and ProductName Like '%" + txt_Name.Text.Trim() + "%'";
            }
            if (cmb_status.SelectedIndex == 1)
            {
                searchstring += " and ProductLastSuply >0";
            }
            else if(cmb_status.SelectedIndex == 2)
            {
                searchstring += " and ProductLastSuply <= 0";
            }
            if (rdb_active.IsChecked==true)
            {
                searchstring += " and ProductActive = 1 ";
            }
            else if (rdb_deactive.IsChecked==true)
            {
                searchstring += " and ProductActive = 2 ";
            }
            
            return searchstring;
        }
        
        private void imge_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void image_search_MouseDown(object sender, MouseButtonEventArgs e)
        {

            ShowProductInfo(SearchStatement);
        }

        private void btn_ShowPrice_click(object sender, RoutedEventArgs e)
        {
            object item = dataGrid_product.SelectedItem;
            win_productprice w_price = new win_productprice();

            w_price.productName = (dataGrid_product.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            w_price.productId = Convert.ToInt32((dataGrid_product.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

            w_price.ShowDialog();
            ShowProductInfo(SearchStatement);
        }
        private void btn_showInventory_click(object sender, RoutedEventArgs e)
        {
            object item = dataGrid_product.SelectedItem;
            win_inventory w_price = new win_inventory();

            w_price.productName = (dataGrid_product.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            w_price.productId = Convert.ToInt32((dataGrid_product.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

            w_price.ShowDialog();

            ShowProductInfo(SearchStatement);
        }

        private void btn_newproduct_Click(object sender, RoutedEventArgs e)
        {
            Win_add_edit_product w_p = new Win_add_edit_product();
            w_p.win_type = 1;//حالت افزودن 
            w_p.ShowDialog();
            ShowProductInfo(SearchStatement);
        }

        private void btn_editproduct_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGrid_product.SelectedItem;
            Win_add_edit_product w_p = new Win_add_edit_product();
            w_p.win_type = 2;//حالت ویرایش 
            w_p.ProductId=Convert.ToInt32 ((dataGrid_product.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            w_p.ProductName = (dataGrid_product.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            w_p.ProductDesc= (dataGrid_product.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            w_p.ShowDialog();
            ShowProductInfo(SearchStatement);

        }

        private void bt_delproduct_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGrid_product.SelectedItem;
            int ProductCount = Convert.ToInt32((dataGrid_product.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text);

            if (ProductCount>0)
            {
                MessageBox.Show("بدلیل موجود بودن کالا ، این عملیات ممکن نیست");
                return;
            }






            if (MessageBox.Show("آیا از غیرفعال کردن کالا اطمینان دارید؟", "غیرفعال کردن کالا", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                   
                    int ProductID;
                    ProductID = Convert.ToInt32((dataGrid_product.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    Product P = (from Pr in database.Products where Pr.ProductId == ProductID select Pr).SingleOrDefault();
                    P.ProductActive = 2;
                    database.SaveChanges();
                    MessageBox.Show("کالا با موفقیت غیرفعال شد");
                    ShowProductInfo(SearchStatement);
                }
                catch
                {
                    MessageBox.Show("در ثبت اطلاعات مشکلی بوجود آمد");
                    return;
                }
            }
        }
        //
    }
}
