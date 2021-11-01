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

namespace Mine
{
    /// <summary>
    /// Логика взаимодействия для regin.xaml
    /// </summary>
    public partial class regin : Page
    {
        public MainWindow mainWindow;
        string d = "";
        public regin(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }
        private void regin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (login1.Text.Length > 0)
                {
                    if (password1.Password.Length > 0)
                    {
                        d = password1.Password;
                                mainWindow.OpenPage(MainWindow.pages.login); 
                                mainWindow.Select($"INSERT INTO [dbo].[clientinfo] VALUES ('{login1.Text}',1000,'{d}',NULL,NULL,NULL)");
                    }
                    else MessageBox.Show("Укажите пароль");
                }
                else MessageBox.Show("Укажите логин");
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
}
    }
}
