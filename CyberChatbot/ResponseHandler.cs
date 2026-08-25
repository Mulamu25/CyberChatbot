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

        public string GetResponse(string input)
        {
            if (input.Contains("how are you") || input.Contains("how are u"))
            {
                return $"I'm doing great, {Name}! Thanks for asking!";

            }
            else if (input.Contains("purpose"))
            {
                return $"I'm your Cybersecurity Awareness Assistant, {Name}! I'm here to educate you about online safety, phishing scams, password security, and safe browsing habits";

            }
            else if (input.Contains("what can i ask") || input.Contains("what can i ask you"))
            {
                return $"Great question, {Name}! You can ask me about:\n Password safety\n Phishing scams\n Safe browsing\n Social engineering";


            }
            else if (input.Contains("help"))
            {
                return $"Here's what I can help with, {Name}:\n Password safety tips\n How to spot phishing emails\n Safe browsing practices\n Recognizing social engineering\n\n Type éxit to end our chat.";

            }
            else if (input.Contains("password"))
            {
                return $"Password safety is crucial, {Name}! Here are some tips:\n Use strong, unique passwords for each account\n Enable two-factor authentication\n Avoid using easily guessable information\n Consider using a password manager";

            }
            else
            {
                return $"i didn't quite understand that, {Name}. Could you rephrase?\n\nYou can ask me about:\n Passwords\n Phishing\n Safe Browsing\n Social Engineering\n\nType 'help'for more options!";
            }

        }
    }
}

