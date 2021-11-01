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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
namespace Mine
{
    /// <summary>
    /// Логика взаимодействия для ShopCart.xaml
    /// </summary>
    public partial class History : Page
    {
        public MainWindow mainWindow;
        string[] words;
        public History(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            InitializeComponent();
            DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[clientinfo]");
            loginName1.Content = dt_user.Rows[dt_user.Rows.Count - 1][0];
            Money1.Content = dt_user.Rows[dt_user.Rows.Count - 1][1];
            var f = dt_user.Rows[dt_user.Rows.Count - 1][3];
            words = f.ToString().Split(new char[] { ';' });
            for (int i = 0; i < words.Length; i++)
            {
             sls.Items.Add(words[i]);     
            }
        }

        private void hist_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.History);
        }

        private void shopc_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.ShopCart);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.Home);
        }
    }
}
