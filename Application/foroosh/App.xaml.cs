using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using foroosh.window;
namespace foroosh
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_StartUp(object sender, StartupEventArgs e)
        {
            win_login w_n = new win_login();
            w_n.ShowDialog();

            win_main w_main = new win_main();
            w_main.ShowDialog();
        }
    }
}
