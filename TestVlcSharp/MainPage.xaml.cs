using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibVLCSharp.Shared;
using Xamarin.Forms;

namespace TestVlcSharp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private LibVLC vlc;
        private MediaPlayer player;

        public MainPage()
        {
            InitializeComponent();

            vlc = new LibVLC();
            player = new MediaPlayer(vlc);
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (player.IsPlaying)
                    player.Stop();
                else
                {
                    player.Media = new Media(vlc, PathEntry.Text, FromType.FromPath);

                    player.Play();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Playback Error", ex.StackTrace, "OK");
            }
        }
    }
}
