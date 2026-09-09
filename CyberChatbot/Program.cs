using System;

namespace CyberChatbot
{
    internal class Program
    {

        static void Main()
        {
            AudioPlayer audio = new AudioPlayer();
            audio.PlayWelcomeMessage();


            Console.ForegroundColor = ConsoleColor.DarkMagenta;
           
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


            //Name validation process
            while (string.IsNullOrWhiteSpace(handler.Name))
            {
                Console.ForegroundColor =  ConsoleColor.DarkMagenta;
                Console.WriteLine("Name cannot be empty!");
                Console.ResetColor();

                Console.Write("Please enter your name: ");
                handler.Name = Console.ReadLine();

            }
            //Personalized welcome message
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"\nWelcome, {handler.Name}! You are now connected to the CyberChatbot System.");
            Console.ResetColor();
            Console.WriteLine("==================================================================================");
            


            string question;
            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nAsk a question or type 'exit': What can I ask you about?");
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

                //Typing Effect
                var writer = new System.IO.StringWriter();
                var original = Console.Out;
                Console.SetOut(writer);
                handler.GetResponse(question);
                Console.SetOut(original);
                string text = writer.ToString();

                foreach (char c in text)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(20); // Adjust the delay as needed
                }
                Console.ResetColor();


                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("==================================================================================");
                Console.ResetColor();

            } while (question != "exit");


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
