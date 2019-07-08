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
using System.Security.Cryptography;
using DataModelLayer;

namespace foroosh.window
{
    /// <summary>
    /// Interaction logic for win_SetNewPassword.xaml
    /// </summary>
    public partial class win_SetNewPassword : Window
    {
        public win_SetNewPassword()
        {
            InitializeComponent();
        }

        forooshEntities database = new forooshEntities();

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_username.Content = PublicVariable.gUserName + " " + PublicVariable.gUserFamily;
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (txt_newpass.Password == "" || txt_oldpass.Password == "")
            {
                MessageBox.Show("رمز عبور نباید خالی باشد");
                return;
            }
            try
            {
                ////////////////////////////////////////////////////////////رمزنگاری پسورد
                SHA256CryptoServiceProvider Sha_oldPass = new SHA256CryptoServiceProvider();
                Byte[] B1_oldpass;
                Byte[] B2_oldpass;
                B1_oldpass = UTF8Encoding.UTF8.GetBytes(txt_oldpass.Password.Trim());
                B2_oldpass = Sha_oldPass.ComputeHash(B1_oldpass);
                string UserOldPass = BitConverter.ToString(B2_oldpass);
                var query = from User in database.Users
                            where User.UserID == PublicVariable.gUserId
                            where User.UserPassword == UserOldPass
                            select User;
                var result = query.ToList();
                if (result.Count==0)
                {
                    MessageBox.Show("رمز عبور قدیمی اشتباه وارد شده است");
                    return;
                }
                else if(result.Count==1)
                {
                    ////////////////////////////////////////////////////////////
                    SHA256CryptoServiceProvider Sha_newPass = new SHA256CryptoServiceProvider();
                    Byte[] B1_newpass;
                    Byte[] B2_newpass;
                    B1_newpass = UTF8Encoding.UTF8.GetBytes(txt_newpass.Password.Trim());
                    B2_newpass = Sha_newPass.ComputeHash(B1_newpass);
                    string Usernewpass = BitConverter.ToString(B2_newpass);
                    ///////////////////////////////////
                    var UpdatePasswordQuery = (from U in database.Users where U.UserID == PublicVariable.gUserId select U).SingleOrDefault();///پیدا کردن اون سطری که میخوایم پسوردشو عوض کنیم 
                    UpdatePasswordQuery.UserPassword = Usernewpass;
                    database.SaveChanges();
                    MessageBox.Show("رمز عبور با موفقیت ویرایش شد");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("در ثبت اطلاعات مشکلی بوجود آمد");
                this.Close();
            }
           
        }
    }
}
