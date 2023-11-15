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

namespace MusicSmth
{
    /// <summary>
    /// Логика взаимодействия для RedUserInfoWin.xaml
    /// </summary>
    public partial class RedUserInfoWin : Window
    {
        Music Muse = new Music();
        Users user = new Users();
        public RedUserInfoWin(int UsId)
        {
            InitializeComponent();
            user = Muse.Users.Where(x => x.Id == UsId).FirstOrDefault();
            Srname.Text = user.Surname;
            Nam.Text = user.Name;
            Patr.Text = user.Patronymic;
            Birthd.SelectedDate = user.BirthDate;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            user.Surname = Srname.Text;
            user.Name = Nam.Text;
            user.Patronymic = Patr.Text;
            user.BirthDate = Birthd.SelectedDate;
            Muse.SaveChanges();
            MainFrame.mframe.Navigate(new UserPage(user.Id));
            MessageBox.Show("Изменения успешно сохранены");
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
