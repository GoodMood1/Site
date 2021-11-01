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
using System.Diagnostics;

namespace Mine
{
    /// <summary>
    /// Логика взаимодействия для ShopCart.xaml
    /// </summary>
    public partial class ShopCart : Page
    {
        public MainWindow mainWindow;
        string[] words;
        int wo=0,wo2=0;string ex = "";
        public ShopCart(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            InitializeComponent();
            DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[clientinfo]");
            loginName1.Content = dt_user.Rows[dt_user.Rows.Count - 1][0];
            Money1.Content = dt_user.Rows[dt_user.Rows.Count - 1][1];
            var f = dt_user.Rows[dt_user.Rows.Count - 1][4];
            words = f.ToString().Split(new char[] { ';' });
                for (int i = 0; i < words.Length; i++)
                {
                if (MainWindow.text!=null) { 
                    lss3.Items.Add(words[i]);
                    wo = words[i].IndexOf(": ");
                    if (wo != -1)
                    {
                        ex = words[i].Substring(wo + 1);
                        ex = ex.Substring(0, ex.Length - 1);
                        wo2 += Int32.Parse(ex);
                    }
                }
            }
            if (lss3.Items.Count > 0)
            {
                mainWindow.Select($"UPDATE [dbo].[clientinfo] SET ShoppingCart='{MainWindow.text}', SumCart='{wo2}' Where clientinfo.Login='{loginName1.Content}'");          
            }
            else
            {
                mainWindow.Select($"UPDATE [dbo].[clientinfo] SET ShoppingCart=NULL, SumCart=NULL Where clientinfo.Login='{loginName1.Content}'");
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
        int y=0;int q =1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[clientinfo]");
            y = 0;
            y = Convert.ToInt32(Money1.Content);
            if (wo2 <= y && wo2 != -1)
            {
                //edit history
                y = Convert.ToInt32(Money1.Content) - wo2;
                mainWindow.Select($"UPDATE [dbo].[clientinfo] SET ShoppingCart=NULL,Money={y}, SumCart=NULL Where clientinfo.Login='{loginName1.Content}'");
                Money1.Content = dt_user.Rows[dt_user.Rows.Count - 1][1];
                if (q == 1) {
                    opl.Content = "Подтвердить"; q = 0;
                    if (MainWindow.text != null && MainWindow.text != "") {
                        MainWindow.text2 += MainWindow.text;
                        mainWindow.Select($"UPDATE [dbo].[clientinfo] SET History='{MainWindow.text2}' Where clientinfo.Login='{loginName1.Content}'"); }
                    MainWindow.text = "";
                    Process.Start("https://alpackoko.wixsite.com/mysite");
                }
                else  { opl.Content = "Оплатить";q = 1; this.lss3.Items.Clear(); }
            }
            else
            {
                MessageBox.Show("Not enough money");
            }
        }

        //string text = "";
        private void del_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.text = "";
            while (this.lss3.SelectedIndex != -1)
            {
                if (this.lss3.SelectedIndex != -1)
                {
                    this.lss3.Items.RemoveAt(this.lss3.SelectedIndex);
                }
            }
            if (lss3.Items.Count > 0)
            {
                foreach (var i in lss3.Items)
                {
                    MainWindow.text += i.ToString() + ";";
                    //m +=MainWindow.text;
                }
                mainWindow.Select($"UPDATE [dbo].[clientinfo] SET ShoppingCart='{MainWindow.text}', SumCart='{wo2}' Where clientinfo.Login='{loginName1.Content}'");
            }
            else
            {
                //foreach (var i in lss3.Items)
                //{
                //    MainWindow.text += i.ToString() + ";";
                //    MainWindow.text = MainWindow.text.Replace("System.Windows.Controls.ListViewItem: ", "");
                mainWindow.Select($"UPDATE [dbo].[clientinfo] SET ShoppingCart=NULL, SumCart=NULL Where clientinfo.Login='{loginName1.Content}'");
                //MainWindow.text = "";
                //}
            }
            mainWindow.OpenPage(MainWindow.pages.ShopCart);
        }
    }
}