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
using System.Media;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace Audio
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer Player = new MediaPlayer();

        bool StartORStop = true;

        string[] Musics;

        public MainWindow()
        {
            InitializeComponent();
            media.Stop();
            media.Volume = slValue.Value;
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btPlay_Click(object sender, RoutedEventArgs e)
        {
            media.Source = new Uri("C:\\Music\\Flo_Rida_-_Right_Round_48075149.mp3");

            if (StartORStop)
                media.Play();
            else
                media.Stop();
            StartORStop = !StartORStop;
        }

        private void btReplay_Click(object sender, RoutedEventArgs e)
        {
            media.Position = TimeSpan.FromSeconds(0);
        }

        private void btNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btRandom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            string path = dialog.ShowDialog().ToString();
            Musics = Directory.GetFiles(path, "*.mp3");

        }

        private void slValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            float Zoom = (float)e.NewValue;
            media.Volume = Zoom;
        }

        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            Duration.Maximum = media.NaturalDuration.TimeSpan.Ticks;
        }

        private void Duration_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Position = new TimeSpan(Convert.ToInt32(Duration.Value));
        }
    }
}
