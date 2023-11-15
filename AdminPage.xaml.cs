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

namespace MusicSmth
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        Users user = new Users();
        Music muse = new Music();
        public AdminPage(int UsId)
        {
            InitializeComponent();
            user = muse.Users.Where(x=>x.Id == UsId).FirstOrDefault();
        }

        private void DataView(object sender, RoutedEventArgs e)
        {
            MainFrame.mframe.Navigate(new UsersData(user.Id));
        }

        private void TableView(object sender, RoutedEventArgs e)
        {
            MainFrame.mframe.Navigate(new TableData(user.Id));
        }

        private void GoUserPage(object sender, RoutedEventArgs e)
        {
            MainFrame.mframe.Navigate(new UserPage(user.Id));
        }
    }
}
