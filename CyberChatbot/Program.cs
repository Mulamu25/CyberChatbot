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
            
            Console.Write($"Please enter your name: ");
            handler.Name = Console.ReadLine();


            //Console.WriteLine($"\nWelcome, {handler.Name}! You are now connected to the CyberChatbot System.");
            //Console.WriteLine("Press any key to exit...");


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


            string question;
            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Ask a question or type 'exit': What can I ask you about?");
                Console.ResetColor();

                question = Console.ReadLine().ToLower().Trim();


                if (question == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Goodbye! Stay safe online");
                    Console.ResetColor();
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nAssistant: ");
                handler.GetResponse(question);
                Console.ResetColor();


                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==================================================================================");
                Console.ResetColor();

            } while (question != "exit");


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Thank you for chatting with me, {handler.Name}!");
            Console.WriteLine("Remember: Stay safe, stay secure, and always be cautious online!");
            Console.WriteLine("Goodbye!");
            Console.ResetColor();

            Console.WriteLine("==================================================================================");

            Console.Write("\nPress any key to exit...");


            Console.ReadKey();


        }

    }

    }
