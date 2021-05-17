using Main.Other;
using Main.StartWindows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Main
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
        public static void OpenLoad()
        {
            Loading load = new Loading();
            load.Show();
            Application.Current.MainWindow.Close();
        }
        public static void FailedLoad()
        {
            FailedWindow win = new FailedWindow();
            win.Show();
        }
        public static void SuccesLoad()
        {
            SuccesfullyWindow win = new SuccesfullyWindow();
            win.Show();
        }
        public static void DuplicateLoad()
        {
            DoubleWindow win = new DoubleWindow();
            win.Show();
        }
    }
}
