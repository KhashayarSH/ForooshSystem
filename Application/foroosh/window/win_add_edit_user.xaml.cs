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
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace foroosh.window
{
    /// <summary>
    /// Interaction logic for win_add_edit_user.xaml
    /// </summary>
    public partial class win_add_edit_user : Window
    {
        public win_add_edit_user()
        {
            InitializeComponent();
        }

        forooshEntities database = new forooshEntities();
        public byte win_type { get; set; }//الان وین تایپ یک پراپرتیه، یه پراپرتی ساختیم. به جای متغیر. بهینه تره
        public string UserName { get; set;}
        public string UserFamliy { get; set; }

        public string UserTel { get; set; }
        
        public byte UserAge { get; set; }

        public int UserID { get; set; }

        public string UserGender { get; set; }

        public string UserUserName { get; set; }

        /// //////////////////////////////


        private void image_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txt_usertel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //استفاده از عبارات با قاعده برای ورود متن فقط به صورت عدد
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_userage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //استفاده از عبارات با قاعده برای ورود متن فقط به صورت عدد
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_name.Focus();
           

            switch (win_type)
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                         ////////////نمایش اطلاعات کاربر جهت ویرایش 
                        txt_name.Text = UserName;
                        txt_userfamily.Text = UserFamliy;
                        txt_usertel.Text = UserTel;
                        txt_userage.Text = UserAge.ToString();
                        txt_username.Text = UserUserName;
                        txt_username.IsEnabled = false;
                        txt_pass.Password = "*******";
                        txt_pass.IsEnabled = false;

                        if (UserGender == "خانم")
                        {
                            rdb_woman.IsChecked = true;
                        }
                        else
                        {
                            rdb_man.IsChecked = true;
                        }
                        break;
                    }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!CheckNullable())
            {
                return; 
            } 
            ///چک کردن این که این نام کاربری رزرو شده است یا خیر
            
            try
            {
                switch (win_type)
                {
                    case 1:
                        {
                            var query = from UTable in database.Users
                                        where UTable.UserUserName == txt_username.Text.Trim()
                                        select UTable;
                            var result = query.ToList();
                            if (result.Count > 0)
                            {
                                MessageBox.Show(".این نام کاربری ریزرو شده است ");
                                txt_username.Focus();
                                return;

                            }

                            ////////////////////////////////////////////////////////////رمزنگاری پسورد
                            SHA256CryptoServiceProvider Sha2 = new SHA256CryptoServiceProvider();
                            Byte[] B1;
                            Byte[] B2;
                            B1 = UTF8Encoding.UTF8.GetBytes(txt_pass.Password.Trim());
                            B2 = Sha2.ComputeHash(B1);
                            string UserPasswordHashed = BitConverter.ToString(B2);
                            ///////////////////////////////////////////////////چک کردن تکراری نبودن نام کاربری

                            ///////////////////////////////////////////////////////////ثبت کاربر جدید

                            User U = new User();
                            U.UserName = txt_name.Text.Trim();
                            U.UserFamily = txt_userfamily.Text.Trim();
                            U.UserTel = txt_usertel.Text.Trim();
                            U.UserAge = Convert.ToByte(txt_userage.Text.Trim());
                            U.UserUserName = txt_username.Text.Trim();

                            U.UserPassword = UserPasswordHashed;

                            if (rdb_man.IsChecked == true)
                            {
                                U.UserGender = 1;
                            }
                            else
                            {
                                U.UserGender = 2;
                            }
                            U.UserActive = 1;
                            U.UserStartDate = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar.Text));

                            database.Users.Add(U);
                            database.SaveChanges();
                            MessageBox.Show("کاربر جدید با موفقیت افزوده شد");
                            break;
                        }
                    case 2:
                        {
                            User U = (from User in database.Users where User.UserID == UserID select User).SingleOrDefault();
                            U.UserName = txt_name.Text.Trim();
                            U.UserFamily = txt_userfamily.Text.Trim();
                            U.UserAge = Convert.ToByte(txt_userage.Text.Trim());
                            U.UserTel = txt_usertel.Text.Trim();
                            if (rdb_man.IsChecked == true)
                            {
                                U.UserGender = 1;
                            }
                            else if (rdb_woman.IsChecked == true)       
                            {
                                U.UserGender = 2;
                            }
                            database.SaveChanges();
                            MessageBox.Show("اطلاعات کاربر با موفقیت بروزرسانی شد");
                            break;
                        }
               
            }
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


        private bool CheckNullable()
        {
            if (txt_name.Text.Trim() =="")
            {
                MessageBox.Show("نام کاربر وارد نشده است");
                txt_name.Focus();
                return false;
            }
            /////////////
            if (txt_userfamily.Text.Trim() == "")
            {
                MessageBox.Show("نام خانوادگی کاربر وارد نشده است");
                txt_userfamily.Focus();
                return false;
            }
            //////////////
            if (txt_usertel.Text.Trim() == "")
            {
                MessageBox.Show("شماره تماس کاربر وارد نشده است");
                txt_usertel.Focus();
                return false;
            }
            /////////////////
            if (txt_userage.Text.Trim() == "")
            {
                MessageBox.Show("سن کاربر وارد نشده است");
                txt_userage.Focus();
                return false;
            }
            ///////////
            if (txt_username.Text.Trim() == "")
            {
                MessageBox.Show("نام کاربری کاربر وارد نشده است");
                txt_userfamily.Focus();
                return false;
            }
            //////////////
            if (txt_pass.Password.Trim() == "")
            {
                MessageBox.Show("کلمه عبور کاربر وارد نشده است");
                txt_pass.Focus();
                return false;
            }



            return true;
        }
    }
}
