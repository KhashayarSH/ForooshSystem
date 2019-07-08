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
    public partial class win_inventory : Window
    {
        public win_inventory()
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
            cmb_type.Items.Add("همه ی تراکنش ها");
            cmb_type.Items.Add("اضافه به انبار");
            cmb_type.Items.Add("کسر از انبار");
            cmb_type.SelectedIndex = 0;

            lbl_productname.Content = productName;
            ShowPriceInfo(SearchStatement);
        }
        ////// متد ارتباط با پایگاه داده و نمایش اطلاعات در دیتا گرید
        private void ShowPriceInfo(Func<string> SearchStringForPrice)
        {
            var query = database.Database.SqlQuery<vw_Inventory>("Select * From vw_Inventory where 1=1 and productId= " + productId + " "  + SearchStringForPrice());
            //MessageBox.Show(query.ToString());
            //  var u = query.ToList();
            var u = query.ToList();
            dataGrid_inventory.ItemsSource = u;
        }
        ///// تابع ساخت شرط برای نمایش اضلاعات در دیتا گرید
        private string SearchStatement()
        {

            string searchstring = " and InventoryDate between '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_az.Text)) + "' and '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_ta.Text)) + "'";
            if ((txt_username.Text!= ""))
            {
                searchstring += " and FullName Like '%" + txt_username.Text.Trim() + "%'";
            }
            if(cmb_type.SelectedIndex == 1)
            {
                searchstring += " and InventoryCount >=1";
            }
            else if(cmb_type.SelectedIndex == 2)
            {
                searchstring += " and InventoryCount < 0";
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

        private void btn_newTrans_Click(object sender, RoutedEventArgs e)
        {
            win_AddnewTransaction w_addtrans = new win_AddnewTransaction();
            w_addtrans.productid = this.productId;
            w_addtrans.productName = this.productName;
            w_addtrans.ShowDialog();
            ShowPriceInfo(SearchStatement);
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
