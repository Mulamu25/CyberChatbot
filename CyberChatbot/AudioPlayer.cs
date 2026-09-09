using System;
using System.Media;


namespace CyberChatbot
{
    public class AudioPlayer
    {
        public void PlayWelcomeMessage()
        {
            try
            {
                SoundPlayer play= new SoundPlayer("CyberGreeting.wav");
                play.Play();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing audio: {ex.Message}" );
            }
        }
    }
}
