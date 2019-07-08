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
using System.Text.RegularExpressions;

namespace foroosh.window
{
    /// <summary>
    /// Interaction logic for win_add_edit_customer.xaml
    /// </summary>
    public partial class win_add_edit_customer : Window
    {
        public win_add_edit_customer()
        {
            InitializeComponent();
        }
        public byte win_Type;
        public string CName;
        public string CAddress;
        public string CTel;
        public int CID;

        forooshEntities database = new forooshEntities();

        private void image_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Ok_Click(object sender, RoutedEventArgs e)
        {

            if (!CheckNullable())
            {
                return;
            }
            ////////////////ثبت اطلاعات در دیتابیس
            try
            {
                switch (win_Type)
                {

                    case 1:
                        {/////////insert block
                            Customer C = new Customer();
                            C.CustomerName = txt_customerName.Text.Trim();
                            C.CustomerTell = txt_telcustomer.Text.Trim();
                            C.CustomerAddress = txt_customerAddress.Text.Trim();
                            C.StartDate = lbl_date.Content.ToString();
                            C.UserID = PublicVariable.gUserId;
                            database.Customers.Add(C);
                            database.SaveChanges();
                            MessageBox.Show("مشتری جدید با موفقیت اضافه شد");
                            break;
                        }
                    case 2:
                        {///////update block
                            Customer Cu = (from C in database.Customers where C.CustomerID == this.CID select C).SingleOrDefault();
                            Cu.CustomerName = txt_customerName.Text.Trim();
                            Cu.CustomerTell = txt_telcustomer.Text.Trim();
                            Cu.CustomerAddress = txt_customerAddress.Text.Trim();
                          //   Cu.UpdateDate = lbl_date.Content.ToString();
                           // Cu.UserID = PublicVariable.gUserId;
                            database.SaveChanges();
                            MessageBox.Show("اطلاعات مشتری با موفقیت بروزرسانی شد");
                            break;
                        }
            }
            
               
            }
            catch
            {
                MessageBox.Show("در ارتباط با دیتابیس مشکلشی بوجود آمد");
            }
            finally
            {
                this.Close();
            }
        }
        private bool CheckNullable()
        {
            if (txt_customerName.Text == "")
            {
                MessageBox.Show("نام مشتری را وارد کنید");
                txt_customerName.Focus();
                return false;
            }
            if (txt_telcustomer.Text == "")
            {
                MessageBox.Show("تلفن مشتری را وارد کنید");
                txt_telcustomer.Focus();
                return false;
            }
            if (txt_customerAddress.Text == "")
            {
                MessageBox.Show("آدرس مشتری را وارد کنید");
                txt_customerAddress.Focus();
                return false;
            }
            return true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_customerName.Focus();
            lbl_username.Content = PublicVariable.gUserName + " " + PublicVariable.gUserFamily;
            lbl_date.Content = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar.Text));

            switch(win_Type)
            {
                case 2:
                txt_customerName.Text = this.CName;
                txt_customerAddress.Text = this.CAddress;
                txt_telcustomer.Text = this.CTel;

                    break;
            }
        }

        private void txt_telcustomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //استفاده از عبارات با قاعده برای ورود متن فقط به صورت عدد
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
