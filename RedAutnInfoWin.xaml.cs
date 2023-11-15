using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для RedAutnInfoWin.xaml
    /// </summary>
    public partial class RedAutnInfoWin : Window
    {
        Music Muse = new Music();
        Users user = new Users();
        public RedAutnInfoWin(int UsId)
        {
            InitializeComponent();
            user = Muse.Users.Where(x => x.Id == UsId).FirstOrDefault();
            Login.Text = user.Login.ToString();

        }

        private void FixChange(object sender, RoutedEventArgs e)
        {
            user.Login = Login.Text;
            string CurPass = Pass.Text;
            using (SHA256 hash = SHA256.Create())
            {
                CurPass = BitConverter.ToString(hash.ComputeHash(Encoding.UTF8.GetBytes(CurPass))).Replace("-", "");
            }
            user.Password = CurPass;
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
