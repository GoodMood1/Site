using System;
using System.Collections.Generic;
using System.Data;
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

namespace Mine
{
    /// <summary>
    /// Логика взаимодействия для Actors.xaml
    /// </summary>
    public partial class Actors : Page
    {
        public MainWindow mainWindow;
        public Actors(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[clientinfo]");
            loginName1.Content = dt_user.Rows[dt_user.Rows.Count - 1][0];
            Money1.Content = dt_user.Rows[dt_user.Rows.Count - 1][1];
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
        //string text = "";
        private void cart_Click(object sender, RoutedEventArgs e)
        {
            foreach (var i in lss3.SelectedItems)
            {
                MainWindow.text += i.ToString()+";";
                MainWindow.text = MainWindow.text.Replace("System.Windows.Controls.ListViewItem: ", "");
                mainWindow.Select($"UPDATE [dbo].[clientinfo] SET ShoppingCart='{MainWindow.text}' Where clientinfo.Login='{loginName1.Content}'");
            }
        }
    }
}
