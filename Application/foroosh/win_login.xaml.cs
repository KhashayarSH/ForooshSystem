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
using foroosh.window;
using Microsoft.Win32;
using foroosh.Module;
using DataModelLayer;
using System.Security.Cryptography;
using System.Net;

namespace foroosh
{
    /// <summary>
    /// Interaction logic for win_login.xaml
    /// </summary>
    public partial class win_login : Window
    {
        public win_login()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            System.Environment.Exit(0);
        }
        forooshEntities database = new forooshEntities();

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
           
            ////////////////////تبدیل رمز عبور به رشته در درهم
            SHA256CryptoServiceProvider Sha2 = new SHA256CryptoServiceProvider();
            Byte[] B1;
            Byte[] B2;
            B1 = UTF8Encoding.UTF8.GetBytes(txt_password.Password.Trim());
            B2 = Sha2.ComputeHash(B1);
            string UserPasswordHashed = BitConverter.ToString(B2);
            /////////////////////////////////////////////////بررسی موجود بودن نام کاربری و رمز عبور در دیتابیس
            var query = from U in database.Users
                        where U.UserUserName == txt_username.Text.Trim()
                        where U.UserPassword == UserPasswordHashed
                        where U.UserActive == 1
                        select U;
            var user = query.ToList();
            /////////////////////////////////////////////////
            if (user.Count == 1)
            {
                /////////////////////////////////////////ثبت نام کاربری در رجیستری
                RegistryKey UserNameKey = Registry.CurrentUser.CreateSubKey("Software\\foroosh");
                try
                {
                    UserNameKey.SetValue("UserNameRegister",txt_username.Text.Trim());

                    ////بدست اوردن مشخصات کاربر واردشونده 
                    PublicVariable.gUserName = user[0].UserName; 
                    PublicVariable.gUserFamily = user[0].UserFamily;
                    PublicVariable.gUserId = user[0].UserID;
                    /////////////بدست آوردن اطلاعات کامپیوتر کاربر
                    string ComputerName = System.Environment.MachineName;
                    string IP = "";
                    IPHostEntry iPE = Dns.GetHostByName(ComputerName);
                    //IPHostEntry iPE = Dns.GetHostEntry(ComputerName);
                    IPAddress[] IpA = iPE.AddressList;
                    IP = IpA[0].ToString();
                    ///////////////////////////////
                    Userlog UL = new Userlog();
                    UL.ComputerName = ComputerName;
                    UL.IPAddress = IP;
                    UL.UserId = PublicVariable.gUserId;
                    UL.EnterDateTime = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_userlog.Text)) + " - " + String.Format("{0:HH:mm:ss}", DateTime.Now);
                    database.Userlogs.Add(UL);
                    database.SaveChanges();
                    ////////////////////////////////////
                }
                catch
                {
                    MessageBox.Show("در هنگام ورود کاربر مشکلی برای سیستم به وجود آمد");
                }
                finally
                {
                    UserNameKey.Close();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("username or password is wrong! ");
                return;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           ///////////////////////// //دستورات رجیستری
            RegistryKey masterKey = Registry.CurrentUser.CreateSubKey("Software\\foroosh");
            txt_username.Text =(string) masterKey.GetValue("UserNameRegister");
            ///////////////////////////دستورات تاریخ
            SetDate();
            ///////////////تنظیم کرسر روی تکست نام کاربری
            txt_password.Focus();
        }
        private void SetDate()
        {
            lbl_dayName.Content = calendar.SelectedDate.PersianDayOfWeek;
            lbl_daynum.Content = calendar.SelectedDate.Day;
            lbl_month.Content = calendar.SelectedDate.MonthAsPersianMonth;
            lbl_year.Content = calendar.SelectedDate.Year;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
