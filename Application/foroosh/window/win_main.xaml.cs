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
using DataModelLayer;

namespace foroosh.window
{
    /// <summary>
    /// Interaction logic for win_main.xaml
    /// </summary>
    public partial class win_main : Window
    {
        public win_main()
        {
            InitializeComponent();
        }
        forooshEntities database = new forooshEntities();

        

        private void btn_ErtebatBama_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("email: pooy8n@gmail.com");
        }
        //btn_showreport_click
        //btn_ShowReporstList_click
        private void btn_ShowReporstList_click(object sender, RoutedEventArgs e)
        {
            win_ReportsList w_reportList = new win_ReportsList();
            w_reportList.ShowDialog();
        }
        private void btn_showreport_click(object sender, RoutedEventArgs e)
        {
            win_showReport w_report = new win_showReport();
            w_report.ShowDialog();
        }
        private void btn_exit_click(object sender, RoutedEventArgs e)
        {
            database.Sp_Update_ExitDate(PublicVariable.gUserId, string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calender.Text)) + " - " + String.Format("{0:HH:mm:ss}", DateTime.Now));
            database.SaveChanges();
            System.Environment.Exit(0);
        }
        //btn_ShowUser_click

     
        /// /////
        private void btn_chartwindows_click(object sender, RoutedEventArgs e)
        {
            win_forooshchart w_chart = new win_forooshchart();
            w_chart.ShowDialog();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            database.Sp_Update_ExitDate(PublicVariable.gUserId, string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calender.Text)) + " - " + String.Format("{0:HH:mm:ss}", DateTime.Now));
            database.SaveChanges();
            System.Environment.Exit(0);
        }
        private void btn_ShowUser_click(object sender, RoutedEventArgs e)
        {
            win_users w_user = new win_users();
            w_user.ShowDialog();
        }
        //
        private void btn_ShowAllInvoice_click(object sender, RoutedEventArgs e)
        {
            win_ShowInvoice  w_Invoice = new win_ShowInvoice();
            w_Invoice.ShowDialog();
        }

        private void btn_SetnewPass_click(object sender, RoutedEventArgs e)
        {
            win_SetNewPassword w_newpass = new win_SetNewPassword();
            w_newpass.ShowDialog();
        }

        private void btn_invoicewin_click(object sender, RoutedEventArgs e)
        {
            win_invoice w_invoice = new win_invoice();
            w_invoice.Win_type = 1;
            w_invoice.ShowDialog();
        }

        //
        private void btn_enterexit(object sender, RoutedEventArgs e)
        {
            Win_ShowUserLog w_showuserlog = new Win_ShowUserLog();
            w_showuserlog.ShowDialog();
        }
        private void btn_ShowCustomer_click(object sender, RoutedEventArgs e)
        {
            win_customer w_customer = new win_customer();
            w_customer.ShowDialog();
        }
        private void btn_showProduct_Click(object sender, RoutedEventArgs e)
        {
            win_product w_product = new win_product();
            w_product.ShowDialog();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetAbaad();

            lbl_name.Content = PublicVariable.gUserName;
            lbl_family.Content = PublicVariable.gUserFamily;

            ////////////////////////////////
            lbl_time.Content = DateTime.Now.Hour + ":" + DateTime.Now.Minute ;
        }
        private void SetAbaad()
        {
                this.MaxHeight = 650;
                this.MinHeight = 650;
                this.MaxWidth = 1200;
                this.MinWidth = 1200;
        }

        private void btn_addsystempart_click(object sender, RoutedEventArgs e)
        {
            win_systempart w_s = new win_systempart();
            w_s.ShowDialog();
        }
    }
}
