using System;
using System.Collections.Generic;
using System.Text;

namespace CyberChatbot
{
    internal class ResponseHandler
    {
        public string Name
        {
            get; set;
        }

        public void GetResponse(string input)
        {
            string question;
            do
            {
                Console.WriteLine("Ask a question or type éxit': What can i ask you about");
                question = Console.ReadLine().ToLower().Trim();
                Console.WriteLine("\nAssistant: ");

                if (question == "exit")
                {
                    Console.WriteLine("Goodbye! Stay safe online");
                }
                else if (question.Contains("how are you"))
                {
                    Console.WriteLine("I am doing well and ready to help you.");
                }
                else if (question.Contains("purpose"))
                {
                    Console.WriteLine("The purpose is to assist you with cyber safety information and guidance.");
                }
                else if (question.Contains("What can i ask") || question.Contains("topic"))
                {
                    Console.WriteLine("You can ask about passwords, phishing and safe browsing.");
                }
                else if (question.Contains("passwords"))
                {
                    Console.WriteLine("Use strong, unique passwords for each account and consider using a password manager.");
                }
                else if (question.Contains("phishing"))
                {
                    Console.WriteLine("Be cautious of suspicious emails or messages asking for personal information. Verify the source before clicking any links.");
                }
                else if (question.Contains("safe browsing"))
                {
                    Console.WriteLine("Use secure websites (https), avoid clicking on unknown links, and keep your browser updated.");
                }
                else
                {
                    Console.WriteLine("I didnt quite understand that. Could you rephrase");
                }

            } while (question != "exit");
        }
    }
}

