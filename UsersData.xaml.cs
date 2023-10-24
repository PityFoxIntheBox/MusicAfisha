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
    /// Логика взаимодействия для UsersData.xaml
    /// </summary>
    public partial class UsersData : Page
    {
        public UsersData()
        {
            InitializeComponent();
            Music DB = new Music();
            Data.ItemsSource = DB.Users.ToList();
        }
        private void SortAZ(object sender, RoutedEventArgs e)
        {
            using (Music DB = new Music())
            {
                List<Users> u = DB.Users.OrderBy(x=>x.Surname).ToList();
                foreach (Users us in u)
                {
                    if (us.Gender == 1)
                    {
                        us.Genders.Gender = "Мужской";
                    }
                    else
                    {
                        us.Genders.Gender = "Женский";
                    }
                }
                Data.ItemsSource = u;
            }
        }
        private void SortZA(object sender, RoutedEventArgs e)
        {
            using (Music DB = new Music())
            {
                List<Users> u = DB.Users.OrderByDescending(x => x.Surname).ToList();
                foreach (Users us in u)
                {
                    if (us.Gender == 1)
                    {
                        us.Genders.Gender = "Мужской";
                    }
                    else
                    {
                        us.Genders.Gender = "Женский";
                    }
                }
                Data.ItemsSource = u;
            }
        }
        private void FindM(object sender, RoutedEventArgs e)
        {
            using (Music DB = new Music())
            {
                List<Users> u = DB.Users.Where(x=>x.Gender==1).ToList();
                foreach (Users us in u)
                {
                    if (us.Gender == 1)
                    {
                        us.Genders.Gender = "Мужской";
                    }
                    else
                    {
                        us.Genders.Gender = "Женский";
                    }
                }
                Data.ItemsSource = u;
            }
        }
        private void FindW(object sender, RoutedEventArgs e)
        {
            using (Music DB = new Music())
            {
                List<Users> u = DB.Users.Where(x => x.Gender == 2).ToList();
                foreach (Users us in u)
                {
                    if (us.Gender == 1)
                    {
                        us.Genders.Gender = "Мужской";
                    }
                    else
                    {
                        us.Genders.Gender = "Женский";
                    }
                }
                Data.ItemsSource = u;
            }
        }
        private void Search(object sender, RoutedEventArgs e)
        {
            using (Music DB = new Music())
            {
                string SeText = SearchString.Text;
                List <Users> u = DB.Users.Where(x=>x.Surname.StartsWith(SeText) || x.Name.StartsWith(SeText)).ToList();
                foreach (Users us in u)
                {
                    if (us.Gender == 1)
                    {
                        us.Genders.Gender = "Мужской";
                    }
                    else
                    {
                        us.Genders.Gender = "Женский";
                    }
                }
                Data.ItemsSource = u;
            }
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            MainFrame.mframe.Navigate(new AdminPage());
        }
    }
}
