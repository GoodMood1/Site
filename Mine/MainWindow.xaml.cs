using System.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Data.SqlClient;
namespace Mine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string text;
        public static string text2;
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(pages.login);
       
        }
        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");              
                                                                  
            SqlConnection sqlConnection = new SqlConnection(@"server=BBEST\SQLEXPRESS;Trusted_Connection=Yes;DataBase=Store;");
            sqlConnection.Open();                                         
            SqlCommand sqlCommand = sqlConnection.CreateCommand();      
            sqlCommand.CommandText = selectSQL;                        
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);                               
            return dataTable;
        }
        public enum pages
        {
            login,
            regin,
            Home,
            GeneralCharacters,
            ShopCart,
            History,
            Skills,
            Actors,
            Heroes
        }
      public void OpenPage(pages pages)
        {
            if (pages == pages.login)
            {
                frame.Navigate(new login(this));
            }
            else if (pages == pages.regin) frame.Navigate(new regin(this));
            else if (pages == pages.Home) frame.Navigate(new Home(this));
            else if (pages == pages.GeneralCharacters) frame.Navigate(new GeneralCharacters(this));
            else if (pages == pages.ShopCart) frame.Navigate(new ShopCart(this));
            else if (pages == pages.History) frame.Navigate(new History(this));
            else if (pages == pages.Skills) frame.Navigate(new Skills(this));
            else if (pages == pages.Actors) frame.Navigate(new Actors(this));
            else if (pages == pages.Heroes) frame.Navigate(new Heroes(this));
        }
    }
    }


