using System;

namespace CyberChatbot
{
    internal class Program
    {

        static void Main()
        {
            AudioPlayer audio = new AudioPlayer();
            audio.PlayWelcomeMessage();


            Console.ForegroundColor = ConsoleColor.Cyan;
           
            Console.WriteLine(@"  
  ============================================================================================================================================================                                                                                                                                                                       
 ▄▄▄▄▄▄▄       ▄▄                                                                 ▄▄▄▄                                                       ▄▄▄▄▄▄▄               
███▀▀▀▀▀       ██                                              ▀▀  ██           ▄██▀▀██▄                                                     ███▀▀███▄        ██   
███      ██ ██ ████▄ ▄█▀█▄ ████▄ ▄█▀▀▀ ▄█▀█▄ ▄████ ██ ██ ████▄ ██ ▀██▀▀ ██ ██   ███  ███ ██   ██  ▀▀█▄ ████▄ ▄█▀█▄ ████▄ ▄█▀█▄ ▄█▀▀▀ ▄█▀▀▀   ███▄▄███▀ ▄███▄ ▀██▀▀ 
███      ██▄██ ██ ██ ██▄█▀ ██ ▀▀ ▀███▄ ██▄█▀ ██    ██ ██ ██ ▀▀ ██  ██   ██▄██   ███▀▀███ ██ █ ██ ▄█▀██ ██ ▀▀ ██▄█▀ ██ ██ ██▄█▀ ▀███▄ ▀███▄   ███  ███▄ ██ ██  ██   
▀███████  ▀██▀ ████▀ ▀█▄▄▄ ██    ▄▄▄█▀ ▀█▄▄▄ ▀████ ▀██▀█ ██    ██▄ ██    ▀██▀   ███  ███  ██▀██  ▀█▄██ ██    ▀█▄▄▄ ██ ██ ▀█▄▄▄ ▄▄▄█▀ ▄▄▄█▀   ████████▀ ▀███▀  ██   
           ██                                                             ██                                                                                       
         ▀▀▀                                                            ▀▀▀                                                                                        
=============================================================================================================================================================
");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("===================================================================");
            Console.WriteLine("      WELCOME TO THE CYBERCHATBOT SYSTEM");
            Console.WriteLine("===================================================================");


            ResponseHandler handler = new ResponseHandler();
            
            Console.Write($"Please enter your name: {handler.Name}");
            handler.Name = Console.ReadLine();


            Console.WriteLine($"\nWelcome, {handler.Name}! You are now connected to the CyberChatbot System.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }

    }
