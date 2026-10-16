using System;
using System.IO;
using System.Media;

namespace CyberChatbotGui
{
    
    public class AudioPlayer
    {
        
        public void PlayGreeting()
        {
            try
            {
                
                string audioPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "CyberGreeting.wav"
                );

                if (File.Exists(audioPath))
                {
                    SoundPlayer player = new SoundPlayer(audioPath);
                    player.Play();
                }
                else
                {
                    Console.WriteLine($"Audio file not found at: {audioPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing audio: {ex.Message}");
            }
        }
    }
}