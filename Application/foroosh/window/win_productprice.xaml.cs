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
    public partial class win_productprice : Window
    {
        public win_productprice()
        {
            InitializeComponent();
        }

     
        forooshEntities database = new forooshEntities();
        public string productName;
        public int productId;


        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var query = from u in database.Vw_Users select u;
            //var user = query.ToList();
            //dataGrid_user.ItemsSource = user;

            lbl_productname.Content = productName;
            ShowPriceInfo(SearchStatement);
        }
        ////// متد ارتباط با پایگاه داده و نمایش اطلاعات در دیتا گرید
        private void ShowPriceInfo(Func<string> SearchStringForPrice)
        {
            var query = database.Database.SqlQuery<Vw_ProductPrice>("Select * From Vw_ProductPrice where 1=1 and productId= " + productId + " "  + SearchStringForPrice());
            //MessageBox.Show(query.ToString());
            //  var u = query.ToList();
            var u = query.ToList();
            dataGrid_productprice.ItemsSource = u;
        }
        ///// تابع ساخت شرط برای نمایش اضلاعات در دیتا گرید
        private string SearchStatement()
        {

            string searchstring = " and ProductPriceDate between '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_az.Text)) + "' and '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_ta.Text)) + "'";
            if ((txt_username.Text!= ""))
            {
                searchstring += " and FullName Like '%" + txt_username.Text.Trim() + "%'";
            }
           
           
            
            return searchstring;
        }
        
        private void imge_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void image_search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPriceInfo(SearchStatement);
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_newprice_Click(object sender, RoutedEventArgs e)
        {
             Win_AddNewPrice w_a = new Win_AddNewPrice();
            w_a.productName = this.productName;
            w_a.productid = this.productId;
            w_a.ShowDialog();
            ShowPriceInfo(SearchStatement);  

        }
    }
}
