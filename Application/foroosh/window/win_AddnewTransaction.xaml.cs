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
    public partial class win_AddnewTransaction : Window
    {
        public win_AddnewTransaction()
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
            txt_count.Focus();
            cmb_TransType.Items.Add("افزودن به موجودی");
            cmb_TransType.Items.Add("کسر از موجودی");
            cmb_TransType.SelectedIndex = 0;

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
            if (!CheckNullable())
            {
                return;
            }
            using (TransactionScope TS = new TransactionScope())
            {
                try
                {
                    ////////////////////////////////////
                    Inventory I = new Inventory();
                    I.InventoryDate = lbl_date.Content.ToString();
                    I.InventoryDesc = txt_desc.Text.Trim();
                    I.UserID = PublicVariable.gUserId;
                    I.ProductId = this.productid;

                    //////////چک کردن نوع تراکنش 
                    if (cmb_TransType.SelectedIndex == 0)
                    {
                        I.InventoryCount = Convert.ToInt32(txt_count.Text.Trim());
                    }
                    else if (cmb_TransType.SelectedIndex == 1)
                    {
                        I.InventoryCount = -Convert.ToInt32(txt_count.Text.Trim());
                    }
                    database.Inventories.Add(I);
                    database.SaveChanges();
                    //////////////////////////////////////
                    database.Sp_Update_ProductLastStock(I.InventoryCount, this.productid);
                    database.SaveChanges();
                    TS.Complete();
                    MessageBox.Show("اطلاعات با موفقیت ذخیره شد");
                }
                catch
                {
                    MessageBox.Show("در ثبت اطلاعات مشکلی به وجود آمد");
                }
                finally
                {
                    this.Close();
                }
            }
            
        }
        private bool CheckNullable()
        {
            if (txt_count.Text.Trim() == "")
            {
                MessageBox.Show("تعداد وارد نشده است");
                txt_count.Focus();
                return false;
            }
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("توضیحات  وارد نشده است");
                txt_desc.Focus();
                return false;
            }
            
            return true ; 
        }
    }
}
