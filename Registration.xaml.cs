using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void GoAuth_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.mframe.Navigate(new Authorization());
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            string CurPass = Pass.Password;
            using (SHA256 hash = SHA256.Create())
            {
                CurPass = BitConverter.ToString(hash.ComputeHash(Encoding.UTF8.GetBytes(CurPass))).Replace("-", "");
            }
            Random random = new Random();
            int gen;
            if(Male.IsChecked == true)
            {
                gen = 1;
            }
            else if(Female.IsChecked == true) 
            {
                gen = 2;
            }
            else
            {
                gen = random.Next(1, 2);
            }
            Users user = new Users()
            {
                Name = Name.Text,
                Surname = Surname.Text,
                Patronymic = Patronymic.Text,
                Login = Login.Text,
                Password = CurPass,
                BirthDate = BirthDate.SelectedDate,
                Gender = gen,
                Role = 2
            };
            using (Music DB = new Music())
            {
                DB.Users.Add(user);
                DB.SaveChanges();
            }
            MessageBox.Show("Норм");
        }
        public void PassCheck(string Pass)
        {
        }
    }
}
