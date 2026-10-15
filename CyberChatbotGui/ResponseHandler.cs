using System;
using System.Collections.Generic;
using System.Text;

namespace CyberChatbotGui
{
    public class ResponseHandler
    {

        //Dictionary: keyword > list of possible responses
        private readonly Dictionary<string, List<string>> _responseMap;

        private string _lastResponse = "";
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
                    "Use strong, unique passwords for each account. A good password should be at least 12 characters long, mixing uppercase, lowercase, numbers, and symbols. Avoid using personal details like birthdays or pet names.",
                    "Never reuse the same password across multiple accounts. If one account is breached, all accounts using that password become vulnerable. Consider using a password manager to generate and store strong passwords securely.",
                    "Enable Two-Factor Authentication (2FA) wherever possible. This adds an extra layer of security even if someone steals your password, they can't access your account without the second factor.",
                    "Change your passwords immediately if you suspect a breach. Also, check if your email has been involved in known data breaches using sites like HaveIBeenPwned.",
                    "Use a password manager like Bitwarden, 1Password, or LastPass. They generate strong passwords, store them securely, and auto-fill them for you — so you only need to remember one master password."

                },

                //SCAMS
                ["scams"] = new List<string>
                {
                    "Be cautious of messages asking for personal information. Scammers often disguise themselves as trusted organisations like banks, SARS, or courier companies. Always verify the sender by contacting the organisation directly using their official number.",
                    "If something sounds too good to be true, it probably is that's a classic scam sign.",
                    "Never send money or share banking details with someone you haven't met or verified in person. Romance scams and investment scams often start online and end with financial loss.",
                    "Legitimate companies never ask for your password or PIN over the phone or email.",
                    "If you're unsure about a message, contact the organisation directly using their official number."
                },

                // PRIVACY
                ["privacy"] = new List<string>
                {
                    "Review your social media privacy settings regularly. Limit what strangers can see your location, relationship status, phone number, and daily routine should not be public.",
                    "Avoid sharing your location, ID number, or daily routine publicly online.",
                    "Use a VPN when connecting to public Wi-Fi. Public networks are often unsecured, and attackers on the same network can intercept your data including passwords and banking details.",
                    "Read privacy policies before signing up know what data companies collect.",
                    "Regularly check which apps have access to your personal data and revoke unnecessary permissions."
                },

                // PHISHING

                ["phishing"] = new List<string>
                {
                    "Be cautious of emails asking for personal information. Always verify the sender's email address carefully attackers often use addresses that look almost identical to real ones (e.g., 'support@paypa1.com' instead of 'support@paypal.com').",
                    "Hover over links before clicking to check if the URL matches the real website. If the domain doesn't match the organisation's official domain, don't click.",
                    "Watch for urgent or emotional language in emails — phrases like 'Your account will be closed in 24 hours' or 'Immediate action required' are designed to make you act without thinking.",
                    "Never enter your password on a page you reached through an email link. Instead, open a new browser tab and navigate to the site directly.",
                    "If an email feels off, report it as phishing and delete it without clicking anything. Most email providers (Gmail, Outlook) have a 'Report phishing' option."

                },

                // SAFE BROWSING
                ["browsing"] = new List<string>
                {
                   "Always check for 'https://' and the padlock icon in the address bar before entering any personal information. The 's' stands for secure it means your data is encrypted.",
                    "Avoid using public Wi-Fi for sensitive transactions like banking, shopping, or logging into accounts. If you must, use a VPN to encrypt your connection.",
                    "Keep your browser and extensions updated. Updates often include security patches that fix vulnerabilities attackers could exploit.",
                    "Clear your cookies and cache regularly. Cookies track your browsing and can be exploited if your device is compromised. Use your browser's privacy settings to auto-clear them.",
                    "Use an ad-blocker and privacy extensions to avoid malicious ads (malvertising) that can infect your device or redirect you to scam sites."
                },

                // MALWARE
                ["malware"] = new List<string>
                {
                    "Install reputable antivirus software and keep it updated. Free options like Windows Defender are decent, but paid antivirus (Bitdefender, Kaspersky, Malwarebytes) offers better real-time protection.",
                    "Don't download files or click links from unknown sources. Malware often spreads through fake downloads, cracked software, and unsolicited email attachments.",
                    "Keep your operating system and applications updated. Most malware exploits known vulnerabilities that have already been patched updates close these doors.",
                    "Back up important files regularly to an external drive or cloud storage. This protects you against ransomware attacks, where attackers encrypt your files and demand payment.",
                    "Avoid pirated software it often contains hidden malware. Free 'cracked' versions of paid software are a common way attackers distribute viruses and trojans."
                }
            };
        }

        public string GetResponse(string input, string userName)
        {
            // Null safe check
            if (string.IsNullOrWhiteSpace(input))
                return $"I didn't quite catch that, {userName}. Could you rephrase?";


            string lowerInput = input.ToLower().Trim();


            //   HANDLE "TELL ME MORE"
            if (lowerInput.Contains("tell me more") ||
                lowerInput.Contains("another tip") ||
                lowerInput.Contains("explain more") ||
                lowerInput.Contains("more info"))
            {
                if(!string.IsNullOrEmpty(LastTopic))
                {
                    return GetRandomResponse(LastTopic, userName);

                }
                return $"I'M NOT SURE WHICH TOPIC YOU WANT TO KNOW MORE ABOUT, {userName}. Try asking about passwords, scams, or privacy.";

            }

            //Key word matching
            foreach (var keyword in _responseMap.Keys)
            {
                if (lowerInput.Contains(keyword))
                {

                    if (LastTopic != keyword)
                        _lastResponse = ""; // Reset last response if topic changes
                    LastTopic = keyword;
                    return GetRandomResponse(keyword, userName);
                }
            }

            //default response if no keywords match
            return $"I'M NOT SURE HOW TO HELP WITH THAT, {userName}. Try asking about passwords, scams, privacy, phishing, safe browsing, or malware.";

        }

        /// <summary>
        /// Picks a random response from the list for a given topic.
        /// Avoids repeating the same response twice in a row.
        /// </summary>
        private string GetRandomResponse(string topic, string userName)
        {
            if (!_responseMap.ContainsKey(topic))
                return $"I don't have information about that, {userName}.";

            List<string> responses = _responseMap[topic];

            // If there's only 1 response, just return it
            if (responses.Count == 1)
                return $"{userName}, {responses[0]}";

            // Pick a random index that's different from the last one used
            string selected;
            int attempts = 0;
            do
            {
                int index = _random.Next(responses.Count);
                selected = responses[index];
                attempts++;
            } while (selected == _lastResponse && attempts < 10);

            // Remember this response so we don't repeat it next time
            _lastResponse = selected;

            return $"{userName}, {selected}";
        }
    }
}
