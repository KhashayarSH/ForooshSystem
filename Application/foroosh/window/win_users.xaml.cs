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
    /// Interaction logic for win_users.xaml
    /// </summary>
    public partial class win_users : Window
    {
        public win_users()
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

            ShowUserInfo(SearchStatement);
        }
        ////// متد ارتباط با پایگاه داده و نمایش اطلاعات در دیتا گرید
        private void ShowUserInfo(Func<string> SearchStringForUsers)
        {
            var query = database.Database.SqlQuery<Vw_Users>("Select * From Vw_Users where 1=1" + SearchStringForUsers());
            //MessageBox.Show(query.ToString());
            var u = query.ToList();
            dataGrid_user.ItemsSource = u;
        }
        ///// تابع ساخت شرط برای نمایش اضلاعات در دیتا گرید
        private string SearchStatement()
        {

            string searchstring = " and UserStartDate between ' " + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_az.Text)) + "' and '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_ta.Text)) + "'";
            if (txt_Name.Text != "")
            {
                searchstring += " and UserName Like '%" + txt_Name.Text.Trim() + "%'";
            }
            if (txt_Family.Text != "")
            {
                searchstring += " and UserFamily Like '%" + txt_Family.Text.Trim() + "%'";
            }
            if ((txt_tel.Text != ""))
            {
                searchstring += " and UserTel Like '%" + txt_tel.Text.Trim() + "%'";
            }
            
            if (rdb_deactive.IsChecked == true)
            {
                searchstring += " And UserActive = 2";
            }
            else
            {
                searchstring += " And UserActive = 1";
            }
            
            return searchstring;
        }
        
        private void imge_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void image_search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowUserInfo(SearchStatement);
        }

        private void btn_newuser_Click(object sender, RoutedEventArgs e)
        {
            win_add_edit_user w_u = new win_add_edit_user();
            w_u.win_type = 1;
            w_u.ShowDialog();
            ShowUserInfo(SearchStatement);
        }

        private void btn_edituser_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGrid_user.SelectedItem;
            win_add_edit_user w_u = new win_add_edit_user();
            if (item != null)
            {
                w_u.win_type = 2;

                w_u.UserID = Convert.ToInt32((dataGrid_user.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                w_u.UserName = (dataGrid_user.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                w_u.UserFamliy = (dataGrid_user.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                w_u.UserTel = (dataGrid_user.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                w_u.UserAge = Convert.ToByte((dataGrid_user.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
                w_u.UserGender = (dataGrid_user.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                w_u.UserUserName = (dataGrid_user.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;

                w_u.ShowDialog();
            }
            ShowUserInfo(SearchStatement);
        }

        private void bt_deluser_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("آیا از غیرفعال کردن کاربر اطمینان دارید؟", "غیرفعال کردن کاربر", MessageBoxButton.YesNo )== MessageBoxResult.Yes)
            {
                try
                {
                    object item = dataGrid_user.SelectedItem;
                    int UserID;
                    UserID = Convert.ToInt32((dataGrid_user.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    User U = (from User in database.Users where User.UserID == UserID select User).SingleOrDefault();
                    U.UserActive = 2;
                    database.SaveChanges();
                    MessageBox.Show("کاربر با موفقیت غیرفعال شد");
                    ShowUserInfo(SearchStatement);
                }
                catch
                {
                    MessageBox.Show("در ثبت اطلاعات مشکلی بوجود آمد");
                    return;
                }
            }
        }
    }
}
