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


            //Name validation process
            while (string.IsNullOrWhiteSpace(handler.Name))
            {
                Console.ForegroundColor =  ConsoleColor.Cyan;
                Console.WriteLine("Name cannot be empty!");
                Console.ResetColor();

                Console.Write("Please enter your name: ");
                handler.Name = Console.ReadLine();

            }
            //Personalized welcome message
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nWelcome, {handler.Name}! You are now connected to the CyberChatbot System.");
            Console.ResetColor();
            Console.WriteLine("==================================================================================");
            Console.ReadLine();
            Console.ReadKey();


        }

    }

    }
