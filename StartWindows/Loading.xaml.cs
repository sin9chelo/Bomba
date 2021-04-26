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
using System.Windows.Threading;

namespace Main.StartWindows
{
    /// <summary>
    /// Логика взаимодействия для Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        public Loading()
        {
            InitializeComponent();
            Media.Source = new Uri(@"D:\2 курс\2 сем\bb(big bomb)\Main\gif\loading.gif");
            LoadingWindow();
        }
        DispatcherTimer timer = new DispatcherTimer();
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            Media.Position = new TimeSpan(0, 0, 1);
            Media.Play();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Hide();
            MainWindow page = new MainWindow();
            page.ShowDialog();
            Close();
        }
        void LoadingWindow()
        {
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void MoveGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
