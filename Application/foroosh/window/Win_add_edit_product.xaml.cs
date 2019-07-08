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
using Microsoft.Win32;
using System.IO;
using DataModelLayer;
using System.Drawing;

namespace foroosh.window
{
    /// <summary>
    /// Interaction logic for Win_add_edit_product.xaml
    /// </summary>
    public partial class Win_add_edit_product : Window
    {
        public Win_add_edit_product()
        {
            InitializeComponent();
        }
        string strName,imageName;
        forooshEntities database = new forooshEntities();

        public byte win_type { get; set; }
        public int ProductId { get; set;}
        public string ProductName { get; set; }
        public string ProductDesc { get; set;}


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_username.Content = PublicVariable.gUserName + " " + PublicVariable.gUserFamily;
            lbl_date.Content = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar.Text));
            switch (win_type)
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        txt_productname.Text = ProductName;
                        txt_desc.Text = ProductDesc;
                        ////////////////////
                        ShowImage();
                        ////////////////////
                        break;
                    }
            }

        }
        private void ShowImage()
        {
            //////این بلاک از دستورات برای ایجاد یک تصویر از دیتابیس استفاده میشود
            var query = from P in database.Products where P.ProductId == ProductId select P;
            var result = query.ToList();
            if (result[0].ProductImage !=null)
            {
                byte[] ImageArray = (byte[])result[0].ProductImage;
                MemoryStream stream = new MemoryStream();
                stream.Write(ImageArray, 0, ImageArray.Length);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);///با این خط کد یه تصویر رو تولید میکنیم
                ms.Seek(0, SeekOrigin.Begin);
                bi.StreamSource = ms;
                bi.EndInit();
                image_product.Source = bi;
            }
        }
        private bool CheckNullable()
        {
            if (txt_productname.Text=="")
            {
                MessageBox.Show("نام کالا وارد نشده است");
                txt_productname.Focus();
                return false;
            }
            if (txt_desc.Text == "")
            {
                MessageBox.Show("توضیحات کالا وارد نشده است");
                txt_desc.Focus();
                return false;
            }
            
            return true;
        }
        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckNullable())
            {
                return;
            }
            try
            {
                switch (win_type)
                {
                    case 1:
                        {
                            if (imageName != null)
                            {
                                ////دستورات تبدیل تصویر به رشته برای ذخیره در دیتابیس
                                FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
                                byte[] imgByteArr = new byte[fs.Length];
                                fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                                fs.Close();
                                //////////ذخیره اطلاعات در دیتابیس
                                database.Sp_ins_product1(txt_productname.Text.Trim(), txt_desc.Text.Trim(), imgByteArr, lbl_date.Content.ToString(), PublicVariable.gUserId);
                                database.SaveChanges();
                                MessageBox.Show("اطلاعات ذخیره شد");
                            }
                            else
                            {
                                MessageBox.Show("لطفا برای کالای جدید یک تصویر انتخاب کنید");
                                return;

                            }
                            break;
                        }
                    case 2:
                        {
                            if (imageName != null)
                            {
                                ////دستورات تبدیل تصویر به رشته برای ذخیره در دیتابیس
                                FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
                                byte[] imgByteArr = new byte[fs.Length];
                                fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                                fs.Close();



                                database.Sp_Update_product(ProductId, txt_productname.Text.Trim(), txt_desc.Text.Trim(), imgByteArr);
                                database.SaveChanges();
                                MessageBox.Show("اطلاعات کالا با موفقیت ویرایش شد");
                            }

                            else if (imageName==null)
                            {
                                database.Sp_Update_product2(ProductId, txt_productname.Text.Trim(), txt_desc.Text.Trim());
                                database.SaveChanges();
                                MessageBox.Show("اطلاعات کالا با موفقیت ویرایش شد");
                            }
                                break;
                        }
            }
            }        
            catch(Exception ex)
            {
                MessageBox.Show("در ثبت اطلاعات مشکلی بوجود آمد. شرح مشکل : " + ex.ToString());
            }
            finally
            {
                this.Close();  
            }

        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void image_product_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                FileDialog filedlg = new OpenFileDialog();
                filedlg.Filter = "Image File (*.jpg;*.bmp;*.gif)| *.jpg; *.bmp; *.gif";
                filedlg.ShowDialog();
                {
                    strName = filedlg.SafeFileName;
                    imageName = filedlg.FileName;
                    if (imageName != "")
                    {
                        ImageSourceConverter isc = new ImageSourceConverter();
                        image_product.SetValue(System.Windows.Controls.Image.SourceProperty, isc.ConvertFromString(imageName));
                    }
                }
                filedlg = null;
            }
            catch
            {
                MessageBox.Show("خطایی رخ داده است");
            }
        }
    }
}
