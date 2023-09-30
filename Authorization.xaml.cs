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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicSmth
{
    /// <summary>
    /// Логика взаимодействия для Auuhorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }
        public void GoReg_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.mframe.Navigate(new Registration());
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string CurPass = Pass.Password;
            using (SHA256 hash = SHA256.Create())
            {
                CurPass = BitConverter.ToString(hash.ComputeHash(Encoding.UTF8.GetBytes(CurPass))).Replace("-", "");
            }

        }
    }
}
