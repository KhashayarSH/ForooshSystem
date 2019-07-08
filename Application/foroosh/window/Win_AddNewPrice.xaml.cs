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
using foroosh.Module;
using System.Text.RegularExpressions;
using DataModelLayer;
using System.Transactions;

namespace foroosh.window
{
    /// <summary>
    /// Interaction logic for Win_AddNewPrice.xaml
    /// </summary>
    public partial class Win_AddNewPrice : Window
    {
        public Win_AddNewPrice()
        {
            InitializeComponent();
        }
        forooshEntities database = new forooshEntities();
        public string productName;
        public int productid;



        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //////////نمایش اطلاعات در لیبل ها
            lbl_title.Content = this.productName;
            lbl_username.Content = PublicVariable.gUserName + " " + PublicVariable.gUserFamily;
            lbl_date.Content = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar.Text));
            //////////////
            txt_purch.Focus();

        }

        private void txt_purch_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //استفاده از عبارات با قاعده برای ورود متن فقط به صورت عدد
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_sale_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //استفاده از عبارات با قاعده برای ورود متن فقط به صورت عدد
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
             using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    /////////////////////////////////////////////ثبت قیمت جدید
                    ProductPrice PP = new ProductPrice();
                    PP.ProductPricePurch = Convert.ToInt64(txt_purch.Text.Trim());
                    PP.ProductPriceSell = Convert.ToInt64(txt_sale.Text.Trim());
                    PP.ProductPriceDate = lbl_date.Content.ToString();
                    PP.ProductPriceDesc = txt_desc.Text.Trim();
                    PP.ProductId = this.productid;
                    PP.UserId = PublicVariable.gUserId;
                    database.ProductPrices.Add(PP);
                    database.SaveChanges();
                    /////////////////////////////////////////////  بروز رسانی قیمت
                    database.Sp_UpdateFee_Product(this.productid, Convert.ToInt64(txt_sale.Text.Trim()),Convert.ToInt64(txt_purch.Text .Trim()));
                    database.SaveChanges();
                    //////////////////////////

                    ts.Complete();
                    MessageBox.Show("اطلاعات با موفقیت ذخیره شد");
                }
                catch
                {
                    MessageBox.Show("در ثبت اطلاعات مشکلی بوجود آمد");
                }
                finally
                {
                    this.Close();
                }
            }
        }
        private bool CheckNullable()
        {
            if (txt_purch.Text =="")
            {
                MessageBox.Show("قیمت خرید وارد نشده است");
                txt_purch.Focus();
                return false;
            }
            if (txt_sale.Text == "")
            {
                MessageBox.Show("قیمت فروش وارد نشده است");
                txt_sale.Focus();
                return false;
            }
            return true ; 
        }
    }
}
