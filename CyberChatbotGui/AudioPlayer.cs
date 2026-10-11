using System;
using System.IO;
using System.Media;

namespace CyberChatbotGui
{
    /// <summary>
    /// Plays the voice greeting WAV file.
    /// </summary>
    public class AudioPlayer
    {
        /// <summary>
        /// Plays the CyberGreeting.wav file.
        /// </summary>
        public void PlayGreeting()
        {
            try
            {
                // Look for CyberGreeting.wav in the application's output folder
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