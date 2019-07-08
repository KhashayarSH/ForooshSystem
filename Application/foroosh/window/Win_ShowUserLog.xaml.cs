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
    /// Interaction logic for Win_ShowUserLog.xaml
    /// </summary>
    public partial class Win_ShowUserLog : Window
    {
        public Win_ShowUserLog()
        {
            InitializeComponent();
        }
        forooshEntities DB = new forooshEntities();
        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void image_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindCombo();
            ShowUserLogInfo(CreateSearchString);
        }
        private void BindCombo()
        {
            ///////دستورات لینکیو
            //var query = from U in DB.Vw_Users select U;
            //var Uquery = query.ToList();
            //for (int i = 0; i < Uquery.Count; i++)
            //{
            //    cmb_username.Items.Add(Uquery[i].FullName);
            //}
            cmb_username.ItemsSource = DB.Vw_Users.ToList();
            cmb_username.DisplayMemberPath = "FullName";
            cmb_username.SelectedValuePath = "UserID";
        }

        private void ShowUserLogInfo(Func<string> SearchStringParameter)
        {
            var query = DB.Database.SqlQuery<vw_userlog>("select *from vw_userlog where " + SearchStringParameter());
            var Result = query.ToList();
            dataGrid_UserLog.ItemsSource = Result;
        }

        private string CreateSearchString()
        {
            string Time_az = txt_s_az.Text.Trim() + ":" + txt_m_az.Text.Trim() + ":" + txt_s_az.Text.Trim();
            string Time_ta = txt_s_ta.Text.Trim() + ":" + txt_m_ta.Text.Trim() + ":" + txt_s_ta.Text.Trim();
            string SearchString = "EnterDateTime Between '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_az.Text)) + "-" + Time_az+ "' and '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar_ta.Text)) + "-" + Time_ta +"'";
            if (cmb_username.Text !="")
            {
                SearchString += " and UserId=" + cmb_username.SelectedValue;
            }
            if (txt_ip.Text !="")
            {
                SearchString += " and IpAddress Like '%" + txt_ip.Text.Trim() + "%'"; 
            }
            if (txt_computername.Text!="")
            {
                SearchString += " and ComputerName Like '%" + txt_computername.Text.Trim() + "%'"; 
            }
            return SearchString ;
        }

        private void image_search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowUserLogInfo(CreateSearchString);
        }
    }
}
