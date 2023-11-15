using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization;
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
    /// Логика взаимодействия для AddConcert.xaml
    /// </summary>
    public partial class AddConcert : Page
    {
        Music DB = new Music();
        Concerts concert = new Concerts();
        bool flag = false;
        int id;
        public AddConcert(int UsId)
        {
            InitializeComponent();
            //Шаблоны отказались меняться :'(
            Band.ItemsSource=DB.Bands.ToList();
            Band.DisplayMemberPath = "Band";
            Place.ItemsSource=DB.Places.ToList();
            Place.DisplayMemberPath = "Place";
            id = UsId;
        }
        public AddConcert(int index, int UsId)
        {
            flag = true;
            InitializeComponent();
            AddConc.Content = "Изменить";
            concert = DB.Concerts.FirstOrDefault(c => c.ID_Concert == index);
            Band.ItemsSource = DB.Bands.ToList();
            Band.DisplayMemberPath = "Band";
            Place.ItemsSource = DB.Places.ToList();
            Place.DisplayMemberPath = "Place";
            Bands band = DB.Bands.FirstOrDefault(c => c.ID_Band == concert.ID_Band);
            Places place = DB.Places.FirstOrDefault(c => c.ID_Place == concert.ID_Place);
            Name.Text = concert.Name;
            Band.SelectedItem = band;
            Disc.Text = concert.Discription;
            DateConc.SelectedDate = concert.Date;
            Place.SelectedItem = place;
            LowPrice.Text = concert.Lowest_Price.ToString();
            HighPrice.Text = concert.Highest_Price.ToString();
            id = UsId;
        }
        public void Add(object sender, RoutedEventArgs e)
        {
            concert.Name = Name.Text;
            concert.ID_Band = ((Bands)Band.SelectedItem).ID_Band;
            concert.Discription = Disc.Text;
            concert.Date = DateConc.SelectedDate;
            concert.ID_Place = ((Places)Place.SelectedItem).ID_Place;
            concert.Lowest_Price = Convert.ToDecimal(LowPrice.Text);
            concert.Highest_Price = Convert.ToDecimal(HighPrice.Text);
            if(!flag)
            {
                DB.Concerts.Add(concert);
                DB.SaveChanges();
            }
            else
            {
                DB.SaveChanges();
            }
            MessageBox.Show("!!!Вы успешно добавили (обновили) концерт!!!");
        }
        public void Back(object sender, RoutedEventArgs e)
        {
            MainFrame.mframe.Navigate(new TableData(id));
        }
    }
}
