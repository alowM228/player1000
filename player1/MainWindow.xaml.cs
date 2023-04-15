using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace player1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        MediaPlayer mediaPlayer = new MediaPlayer();
        List<string> filenames = new List<string>();
        int currentIndex = 0;

        private void BT_Click_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog
            {
                Multiselect = true,
                DefaultExt = ".mp3"
            };
            bool? dialogOK = FileDialog.ShowDialog();
            if (dialogOK == true)
            {
                filenames = FileDialog.FileNames.ToList();
                currentIndex = 0;
                mediaPlayer.Open(new Uri(filenames[currentIndex]));
                TBFileName.Text = System.IO.Path.GetFileName(filenames[currentIndex]);
            }
        }

        private void BT_Click_Play(object sender, RoutedEventArgs e)
        {
            positionSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            L1.Content = positionSlider.Maximum;
            mediaPlayer.Play();
        }

        private void BT_Click_Pause(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }


        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Volume = volumeSlider.Value;
        }

        private void BT_Click_Next(object sender, RoutedEventArgs e)
        {
            if (currentIndex < filenames.Count - 1)
            {
                currentIndex++;
                mediaPlayer.Open(new Uri(filenames[currentIndex]));
                TBFileName.Text = System.IO.Path.GetFileName(filenames[currentIndex]);
                mediaPlayer.Play();
            }
        }

        private void BT_Click_Previous(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                mediaPlayer.Open(new Uri(filenames[currentIndex]));
                TBFileName.Text = System.IO.Path.GetFileName(filenames[currentIndex]);
                mediaPlayer.Play();
            }
        }
        private void positionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan newPosition = TimeSpan.FromSeconds(positionSlider.Value);
            mediaPlayer.Position = newPosition;
            L2.Content = positionSlider.Value;
        }
         




    }
}