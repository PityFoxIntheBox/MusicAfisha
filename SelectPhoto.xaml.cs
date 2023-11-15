using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для SelectPhoto.xaml
    /// </summary>
    public partial class SelectPhoto : Window
    {
        Music Muse = new Music();
        Users user = new Users();
        List<Photos> Phs = new List<Photos>();
        int n = 0;
        int id;
        public SelectPhoto(int UsId)
        {
            InitializeComponent();
            user = Muse.Users.Where(x=>x.Id == UsId).FirstOrDefault();
            Phs = Muse.Photos.Where(x=>x.ID_User == UsId).ToList();
            byte[] bt = Phs[n].Photo;
            ShowImage(bt, Photo);
            id = user.Id;
        }

        private void BackPhoto(object sender, RoutedEventArgs e)
        {
            try 
            {
                n--;
                byte[] bt = Phs[n].Photo;
                ShowImage(bt, Photo);
            }
            catch (ArgumentOutOfRangeException)
            {
                n = Phs.Count - 1;
                byte[] bt = Phs[n].Photo;
                ShowImage(bt, Photo);
            }

        }

        private void NextPhoto(object sender, RoutedEventArgs e)
        {
            try
            {
                n++;
                byte[] bt = Phs[n].Photo;
                ShowImage(bt, Photo);
            }
            catch (ArgumentOutOfRangeException)
            {
                n = 0;
                byte[] bt = Phs[n].Photo;
                ShowImage(bt, Photo);
            }

        }

        private void SelectThis(object sender, RoutedEventArgs e)
        {
            user.ID_Photo = Phs[n].ID_Photo;
            Muse.SaveChanges();
            MessageBox.Show("Фото обновлено");
            MainFrame.mframe.Navigate(new UserPage(user.Id));
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void ShowImage(byte[] arr, System.Windows.Controls.Image img)
        {
            BitmapImage BI = new BitmapImage();
            BI.BeginInit();
            BI.StreamSource = new MemoryStream(arr);
            BI.EndInit();
            img.Source = BI;
        }
    }
}
