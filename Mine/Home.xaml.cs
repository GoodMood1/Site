using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
namespace Mine
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public MainWindow mainWindow;
        public Home(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[clientinfo]"); 
            loginName1.Content = dt_user.Rows[dt_user.Rows.Count-1][0];
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

        private void Generalcharacters_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.GeneralCharacters);
        }

        private void CharactersHeroes_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.Heroes);
        }

        private void Skills_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.Skills);
        }

        private void CharactersActors_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.Actors);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.login);
        }
    }
}

