using System;
using UIKit;
using AVFoundation;
using AudioToolbox;  
using Foundation; 

namespace SoundTests
{
    public partial class ViewController : UIViewController
    {
        public AVAudioPlayer player;
        public float MusicVolume { get; set; } = 0.5f;
        public bool MusicOn { get; set; } = true;
        bool IsMusicPlaying = false;
       
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BtnPlay.TouchUpInside += async (sender, e) =>
            {
                PlayMusic();

            };
            BtnStop.TouchUpInside += async (sender, e) =>
            {
                player.Stop();
            };
            PlayMusic();

        }

        partial void BtnPlayPause_TouchUpInside(UIButton sender)
        {
            ControlMusic(IsMusicPlaying);
            player.PlayAtTime(1000);
           
        }
        public void ControlMusic(bool MusicIsPlaying) 
        {
            PlayMusic();
            if (!MusicIsPlaying) 
            {
                player.Play();
                IsMusicPlaying = true;
           
            }
            if (MusicIsPlaying && player != null)  
            {
                
                 player.Pause();
                IsMusicPlaying = false;
            }
        }
      
        public void PlayMusic() {  
            NSUrl songURL;  
            //if (!MusicOn) return;  
            //Song url from your local Resource  
            songURL = new NSUrl("Sounds/Sound.aiff");  
            NSError err;  
            player = new AVAudioPlayer(songURL, "Song", out err);  

            player.Volume = MusicVolume;  
            player.FinishedPlaying += delegate {  
                // backgroundMusic.Dispose();  
                player = null;  
            }; 
          
       
               
           
            //Background Music play  
             
        }  

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
