using System;
using System.Collections.Generic;
using System.Text;

namespace CyberChatbotGui
{
    public class ResponseHandler
    {

        //Dictionary: keyword > list of possible responses
        private readonly Dictionary<string, List<string>> _responseMap;


        //Random generator for picking random responses
        private readonly Random _random = new Random();

        //Tracks the last topic discussed(for "tell me more")
        public string LastTopic { get; private set; } = "";

        public ResponseHandler()
        {
            _responseMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {

                // PASSWORDS
                ["password"] = new List<string>
                {
                    "Use strong, unique passwords for each account. Avoid using personal details like birthdays or pet names.",
                    "A good password should be at least 12 characters long, mixing letters, numbers, and symbols.",
                    "Consider using a password manager to keep track of all your passwords securely.",
                    "Never reuse the same password across multiple accounts — if one is breached, all are at risk.",
                    "Enable Two-Factor Authentication (2FA) for an extra layer of security on your accounts."

                },

                //SCAMS
                ["scams"] = new List<string>
                {
                    "Be cautious of messages asking for personal information. Scammers often disguise themselves as trusted organisations.",
                    "If something sounds too good to be true, it probably is — that's a classic scam sign.",
                    "Never send money or share banking details with someone you haven't met or verified.",
                    "Legitimate companies never ask for your password or PIN over the phone or email.",
                    "If you're unsure about a message, contact the organisation directly using their official number."
                },

                // PRIVACY
                ["privacy"] = new List<string>
                {
                    "Review your social media privacy settings regularly — limit what strangers can see.",
                    "Avoid sharing your location, ID number, or daily routine publicly online.",
                    "Use a VPN when connecting to public Wi-Fi to protect your data from snoopers.",
                    "Read privacy policies before signing up — know what data companies collect.",
                    "Regularly check which apps have access to your personal data and revoke unnecessary permissions."
                },

                // PHISHING

                ["phishing"] = new List<string>
                {
                    "Be cautious of emails asking for personal information. Verify the sender's email address carefully.",
                    "Hover over links before clicking — check if the URL matches the real website.",
                    "Watch for urgent or emotional language in emails — that's a common phishing tactic.",
                    "Never enter your password on a page you reached through an email link.",
                    "If an email feels off, report it as phishing and delete it without clicking anything."
                },

                // SAFE BROWSING
                ["browsing"] = new List<string>
                {
                    "Always check for 'https://' and the padlock icon before entering any personal information.",
                    "Avoid using public Wi-Fi for sensitive transactions like banking.",
                    "Keep your browser and extensions updated to patch security holes.",
                    "Clear your cookies and cache regularly to reduce tracking.",
                    "Use an ad-blocker to avoid malicious ads that can infect your device."

                },

                // MALWARE
                ["malware"] = new List<string>
                {
                    "Install reputable antivirus software and keep it updated.",
                    "Don't download files or click links from unknown sources.",
                    "Keep your operating system updated — most malware exploits old vulnerabilities.",
                    "Back up important files regularly to protect against ransomware.",
                    "Avoid pirated software — it often contains hidden malware."
                }
            };
        }


    }
}
