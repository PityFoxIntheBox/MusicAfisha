using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicSmth
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        Users user = new Users();
        Music Muse = new Music();
        public UserPage(int UsId)
        {
            InitializeComponent();
            user = Muse.Users.Where(x=>x.Id == UsId).FirstOrDefault();
            Nam.Text = user.Name;
            Srname.Text = user.Surname;
            Patr.Text = user.Patronymic;
            if(user.Gender == 1)
            {
                Gen.Text = "Мужской";
            }
            else
            {
                Gen.Text = "Женский";
            }
            string bd = user.BirthDate.ToString();
            Birthd.Text = DateTime.Parse(bd).ToShortDateString();
            Log.Text = user.Login;
            Pass.Text = "Невозможно сложный";
            Photos ph = Muse.Photos.Where(x=>x.ID_Photo== user.ID_Photo).FirstOrDefault();
            if(ph != null)
            {
                byte[] bt = ph.Photo;
                ShowImage(bt, Photo);
            }
        }


        void ShowImage(byte[] arr, System.Windows.Controls.Image img)
        {
            BitmapImage BI = new BitmapImage();
            BI.BeginInit();
            BI.StreamSource = new MemoryStream(arr);
            BI.EndInit();
            img.Source = BI;
        }

        private void RedUserInfo(object sender, RoutedEventArgs e)
        {
            RedUserInfoWin wns = new RedUserInfoWin(user.Id);
            wns.ShowDialog();
            MainFrame.mframe.Navigate(new UserPage(user.Id));
        }
        private void RedAuthInfo(object sender, RoutedEventArgs e)
        {
            RedAutnInfoWin wns = new RedAutnInfoWin(user.Id);
            wns.ShowDialog();
            MainFrame.mframe.Navigate(new UserPage(user.Id));
        }

        private void SelectPh(object sender, RoutedEventArgs e)
        {
            SelectPhoto wns = new SelectPhoto(user.Id);
            wns.ShowDialog();
            MainFrame.mframe.Navigate(new UserPage(user.Id));
        }

        private void UploadPhoto(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog FileDialog = new OpenFileDialog();
                FileDialog.ShowDialog();
                Photos UpPh = new Photos();
                UpPh.ID_User = user.Id;
                UpPh.Photo = File.ReadAllBytes(FileDialog.FileName);
                Muse.Photos.Add(UpPh);
                Muse.SaveChanges();
                user.ID_Photo = UpPh.ID_Photo;
                Muse.SaveChanges();
                MessageBox.Show("Изображение в системе");
                MainFrame.mframe.Navigate(new UserPage(user.Id));

            }
            catch
            {
                MessageBox.Show("Не удалось загрузить фото");
            }
        }

        private void UploadPhotos(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.Multiselect = true;
            if (FileDialog.ShowDialog() == true)
            {
                foreach (string file in FileDialog.FileNames)
                {
                    Photos UsPh = new Photos();
                    UsPh.ID_User = user.Id;
                    UsPh.Photo = File.ReadAllBytes(file);
                    Muse.Photos.Add(UsPh);
                }
            }
            Muse.SaveChanges();
            MessageBox.Show("Фотографии в системе");
        }
    }
}
