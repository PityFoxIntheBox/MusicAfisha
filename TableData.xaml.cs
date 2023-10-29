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

namespace MusicSmth
{
    /// <summary>
    /// Логика взаимодействия для TableData.xaml
    /// </summary>
    public partial class TableData : Page
    {
        public TableData()
        {
            InitializeComponent();
            Music DB = new Music();
            ConcertData.ItemsSource = DB.Concerts.ToList();
            
        }

        public void FindCity(object sender,  RoutedEventArgs e)
        {
            TextBlock city = (TextBlock)sender;
            int index = Convert.ToInt32(city.Uid);
            Music DB = new Music();
            string c = DB.Cities.Where(x=>x.ID_City == index).Select(x=>x.City).First();
            city.Text = c;
        }
        

        private void CountTracked(object sender, RoutedEventArgs e)
        {
            TextBlock count = (TextBlock)sender;
            int index = Convert.ToInt32(count.Uid);
            Music DB = new Music();
            int tracked = DB.Tracked_Concerts.Where(x=>x.ID_Concert == index).Count();
            count.Text = "Количество отметок " + tracked.ToString();
        }

        private void DateTill(object sender, RoutedEventArgs e)
        {
            TextBlock id = (TextBlock)sender;
            int index = Convert.ToInt32(id.Uid);
            Music DB = new Music();
            DateTime date = (DateTime)DB.Concerts.Where(x=>x.ID_Concert==index).Select(x=>x.Date).First();
            DateTime today = DateTime.Now;
            TimeSpan diff = date.Subtract(today);
            id.Text = "Дней до концерта "+diff.Days.ToString();
        }

        public void Back(object sender, EventArgs e)
        {
            MainFrame.mframe.Navigate(new AdminPage());
        }
        public void Add(object sender, EventArgs e)
        {
            MainFrame.mframe.Navigate(new AddConcert());
        }
        public void Edit(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            int index = Convert.ToInt32(but.Uid);
            MainFrame.mframe.Navigate(new AddConcert(index));
        }
        public void Delete(object sender, EventArgs e)
        {
            Music DB = new Music();
            Button butt = (Button)sender;
            int index = Convert.ToInt32(butt.Uid);
            Concerts concert = DB.Concerts.Where(x=>x.ID_Concert == index).FirstOrDefault();
            switch (MessageBox.Show("Отменить концерт?", "concert", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                case MessageBoxResult.Yes:
                    DB.Concerts.Remove(concert);
                    MessageBox.Show("Концерта больше нет");
                    DB.SaveChanges();
                    MainFrame.mframe.Navigate(new TableData());
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Ну нет так нет");
                    break;
            }
        }
    }
}
