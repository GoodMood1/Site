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
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public MainWindow mainWindow;
        public login(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }
     
        private void enter_Click(object sender, RoutedEventArgs e)
        {
                if (login1.Text.Length > 0)   
                {
                    if (password1.Password.Length > 0)        
                    {                  
                        DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[clientinfo] WHERE [login] = '" + login1.Text + "' AND [password] = '" + password1.Password + "'");
                        if (dt_user.Rows.Count > 0)       
                        {
                            MessageBox.Show("Пользователь авторизовался");
                            mainWindow.OpenPage(MainWindow.pages.Home);
                    }
                        else MessageBox.Show("Пользователя не найден"); 
                    }
                    else MessageBox.Show("Введите пароль"); 
                }
                else MessageBox.Show("Введите логин"); 
            }

        private void regin_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.regin);
        }
}
    }
