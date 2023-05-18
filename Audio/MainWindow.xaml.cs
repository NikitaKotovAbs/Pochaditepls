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
    public partial class MainWindow : Window
    {
        private string[] supportedExtensions = { ".mp3", ".m4a", ".wav" };
        private List<string> playlist;
        private int currentTrackIndex;
        private bool isPlaying = false;
        private bool isRepeatMode = false;
        private bool isShuffleMode = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private async void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string folderPath = dialog.FileName;
                await LoadMusicFromFolder(folderPath);
                PlayCurrentTrack();
            }
        }

        private async Task LoadMusicFromFolder(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);
            playlist = files.Where(file => supportedExtensions.Contains(System.IO.Path.GetExtension(file).ToLower())).ToList();
            TrackList.ItemsSource = playlist.Select(file => System.IO.Path.GetFileName(file));
        }

        private void PlayCurrentTrack()
        {
            if (playlist != null && playlist.Count > 0 && currentTrackIndex >= 0 && currentTrackIndex < playlist.Count)
            {
                string trackPath = playlist[currentTrackIndex];
                MediaElement.Source = new Uri(trackPath);
                MediaElement.Play();
                isPlaying = true;
                UpdatePlayPauseButtonIcon();
            }
        }

        private void UpdatePlayPauseButtonIcon()
        {
            if (isPlaying)
            {
                StopPause.Content = new Image() { Source = new BitmapImage(new Uri("Images/PauseImg.png", UriKind.Relative)) };
            }
            else
            {
                StopPause.Content = new Image() { Source = new BitmapImage(new Uri("Images/PlayImg.png", UriKind.Relative)) };
            }
        }

        private void BackSong_Click(object sender, RoutedEventArgs e)
        {
            currentTrackIndex--;
            if (currentTrackIndex < 0)
            {
                currentTrackIndex = playlist.Count - 1;
            }
            PlayCurrentTrack();
        }

        private void StopPause_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                MediaElement.Pause();
                isPlaying = false;
            }
            else
            {
                MediaElement.Play();
                isPlaying = true;
            }
            UpdatePlayPauseButtonIcon();
        }

        private void NextSong_Click(object sender, RoutedEventArgs e)
        {
            currentTrackIndex++;
            if (currentTrackIndex >= playlist.Count)
            {
                currentTrackIndex = 0;
            }
            PlayCurrentTrack();
        }

        private void RepeatSong_Click(object sender, RoutedEventArgs e)
        {
            isRepeatMode = !isRepeatMode;
            if (isRepeatMode)
            {
                RepeatSong.Background = Brushes.LightGreen;
            }
            else
            {
                RepeatSong.Background = Brushes.Transparent;
            }
        }

        private void RandomSong_Click(object sender, RoutedEventArgs e)
        {
            isShuffleMode = !isShuffleMode;
            if (isShuffleMode)
            {
                RandomSong.Background = Brushes.LightGreen;
                ShufflePlaylist();
            }
            else
            {
                RandomSong.Background = Brushes.Transparent;
                SortPlaylist();
            }
        }

        private void ShufflePlaylist()
        {
            Random random = new Random();
            int n = playlist.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = playlist[k];
                playlist[k] = playlist[n];
                playlist[n] = value;
            }
        }

        private void SortPlaylist()
        {
            playlist.Sort();
        }

        private void TrackList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTrackIndex = TrackList.SelectedIndex;
            PlayCurrentTrack();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MediaElement.NaturalDuration.HasTimeSpan)
            {
                TimeSpan newPosition = TimeSpan.FromSeconds(e.NewValue);
                MediaElement.Position = newPosition;
            }
        }

        private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (MediaElement.NaturalDuration.HasTimeSpan)
            {
                TimeSpan duration = MediaElement.NaturalDuration.TimeSpan;
                Slider.Maximum = duration.TotalSeconds;
                FinalTime.Text = FormatTime(duration);
            }
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (isRepeatMode)
            {
                PlayCurrentTrack();
            }
            else
            {
                NextSong_Click(sender, e);
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (MediaElement.NaturalDuration.HasTimeSpan)
            {
                TimeSpan currentTime = MediaElement.Position;
                TimeSpan totalTime = MediaElement.NaturalDuration.TimeSpan;

                TimeSpan remainingTime = totalTime - currentTime;

                CurrentTime.Text = FormatTime(currentTime);
                FinalTime.Text = "-" + FormatTime(remainingTime);
            }
        }

        private string FormatTime(TimeSpan time)
        {
            return $"{time.Minutes:D2}:{time.Seconds:D2}";
        }

        private void InitializeTimer()
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateTimer_Tick;
            timer.Start();
        }

        
    }
}