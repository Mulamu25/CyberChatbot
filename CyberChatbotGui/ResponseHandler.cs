using System;
using System.Collections.Generic;

namespace CyberChatbotGui
{
    
    public class ResponseHandler
    {
        private readonly Dictionary<string, List<string>> _responseMap;
        private readonly Random _random = new Random();
        private string _lastResponse = "";

        public string LastTopic { get; set; } = "";

        public ResponseHandler()

        {
            _responseMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                // ==================== PASSWORDS ====================
                ["password"] = new List<string>
                {
                    "Use strong, unique passwords for every account. A strong password should be at least 12 characters long and combine uppercase letters, lowercase letters, numbers, and symbols. Avoid using personal details like your birthday, pet's name, or ID number — these are easy for attackers to guess from your social media.",

                    "Never reuse passwords across multiple accounts. If one site suffers a breach (and many do), attackers will try the same email-and-password combo on other popular sites — a technique called 'credential stuffing'. Using a unique password per account limits the damage to just one site.",

                    "Enable Two-Factor Authentication (2FA) on all accounts that support it — especially email, banking, and social media. 2FA adds a second layer of security beyond your password. Even if someone steals your password, they can't log in without the second factor (a code from your phone or an authenticator app).",

                    "Consider using a reputable password manager such as Bitwarden, 1Password, or LastPass. A password manager generates strong random passwords, stores them encrypted, and auto-fills them across your devices. You only need to remember one strong master password.",

                    "Check if your email has been involved in a data breach using sites like HaveIBeenPwned.com. If your credentials show up in a breach, change that password immediately on any account where you reused it, and enable 2FA going forward."
                },

                // ==================== SCAMS ====================
                ["scam"] = new List<string>
                {
                    "Be highly suspicious of unsolicited messages that pressure you to act quickly. Scammers create urgency — 'Your account will be closed in 24 hours', 'You've won a prize, claim now' — to make you act before thinking. Legitimate organisations never rush you into sharing personal information or making payments.",

                    "If an offer sounds too good to be true, it almost certainly is. Common scam formats include fake lottery wins, unexpected refunds, fake job offers, and 'romance' scams. Remember: no legitimate company gives away money without you entering a competition first.",

                    "Never send money or share banking details with anyone you haven't met or verified in person. This applies to online sellers, romantic partners, and even people claiming to be from your bank. If a transaction feels rushed or unusual, stop and verify independently.",

                    "Legitimate companies — including your bank, SARS, and courier services — will never ask for your password, PIN, or OTP (one-time PIN) over the phone, email, or SMS. If someone does, hang up and report it. Your OTP is the last line of defense for your account — never share it.",

                    "If you're unsure about a suspicious message, contact the organisation directly using the number on their official website or the back of your bank card — never the number provided in the suspicious message. Also report scams to the South African Fraud Prevention Service (SAFPS)."
                },

                // ==================== PRIVACY ====================
                ["privacy"] = new List<string>
                {
                    "Review your social media privacy settings regularly at least every few months. Limit what strangers can see: your location, phone number, relationship status, workplace, and daily routine. Attackers can piece together your life from public posts and use it for identity theft or physical crimes.",

                    "Avoid oversharing personal information online. Details like your ID number, home address, holiday plans, or children's school should never be public. Even seemingly harmless posts (e.g., 'Off to Bali for 2 weeks!') can alert burglars that your home is empty.",

                    "Always use a VPN (Virtual Private Network) when connecting to public Wi-Fi at airports, coffee shops, hotels, or malls. Public networks are often unsecured, and attackers on the same network can intercept your data, including passwords and banking details. A VPN encrypts your traffic so it can't be read.",

                    "Read privacy policies before signing up for apps or services. Look for what data the company collects, how they use it, and whether they share it with third parties. If the policy is vague or overly complex, consider whether the service is worth the privacy trade-off.",

                    "Regularly audit app permissions on your phone. Go to your device's settings and revoke unnecessary access to your camera, microphone, contacts, and location. Many apps request permissions they don't actually need — and some sell that data to advertisers or worse."
                },

                // ==================== PHISHING ====================
                ["phishing"] = new List<string>

                {
                    "Always verify the sender's email address carefully before responding to any email. Phishing attacks often use addresses that look almost identical to real ones — for example, 'support@paypa1.com' (with a number 1) instead of 'support@paypal.com'. Look for small misspellings, unusual domains, and slight variations.",

                    "Hover over any link in an email before clicking it. The real URL will appear at the bottom of your screen (or in a tooltip). If the domain doesn't match the organisation's official website, don't click. Attackers use misleading links to redirect you to fake login pages that steal your credentials.",

                    "Watch for urgent or emotionally-charged language — phrases like 'Your account has been compromised', 'Immediate action required', or 'Final warning'. Legitimate companies rarely use panic-inducing tactics. If an email pressures you to act fast, slow down and verify through official channels first.",

                    "Never enter your password or personal information on a page you reached through an email link. Instead, open a new browser tab and navigate directly to the organisation's website by typing the address yourself. This ensures you're on the legitimate site, not a look-alike phishing clone.",

                    "Report suspicious emails as phishing — most email providers (Gmail, Outlook, Yahoo) have a 'Report phishing' button. Reporting helps your provider block similar attacks for everyone. Then delete the email without clicking any links or attachments. Attachments can contain malware even if they look like innocent PDFs or invoices."
                },

                // ==================== SAFE BROWSING ====================
                ["browsing"] = new List<string>
                {
                    "Always check for 'https://' and the padlock icon in the address bar before entering any personal information. The 's' stands for 'secure' — it means your data is encrypted between your browser and the website. However, note that HTTPS alone doesn't guarantee a site is legitimate — scammers can also get HTTPS certificates.",

                    "Avoid using public Wi-Fi for sensitive tasks like banking, shopping, or logging into accounts. Public networks (at airports, hotels, coffee shops) are often unsecured, and attackers on the same network can intercept your data. If you must use public Wi-Fi, always connect through a VPN first.",

                    "Keep your browser and all its extensions updated. Updates don't just add new features — they patch security vulnerabilities that attackers actively exploit. Enable automatic updates in Chrome, Firefox, or Edge, and remove extensions you no longer use (each extension is a potential attack vector).",

                    "Clear your cookies and cache regularly — at least once a month. Cookies track your browsing across sites and can be exploited if your device is compromised. Use your browser's privacy settings to auto-clear cookies when you close the browser, or use incognito mode for sensitive searches.",

                    "Use a reputable ad-blocker (uBlock Origin, AdGuard) and a privacy extension. Malicious ads (called 'malvertising') can infect your device with malware or redirect you to scam sites — even on legitimate websites. Ad-blockers reduce your exposure to these threats significantly."
                },

                // ==================== MALWARE ====================
                ["malware"] = new List<string>
                {
                    "Install reputable antivirus software and keep it updated. Windows Defender (built-in) is decent for basic protection, but paid options like Bitdefender, Kaspersky, or Malwarebytes offer better real-time scanning, ransomware protection, and phishing detection. Run a full system scan at least once a week.",

                    "Never download files or click links from unknown sources. Malware often spreads through fake downloads, cracked software, unsolicited email attachments, and pop-up ads claiming your device is 'infected'. If you didn't go looking for the file, don't download it.",

                    "Keep your operating system and all applications updated. Most malware exploits known vulnerabilities that have already been patched by Microsoft, Apple, or app developers. Enable automatic updates and reboot when prompted — the longer you delay, the bigger your window of exposure.",

                    "Back up important files regularly to an external hard drive or cloud storage (Google Drive, OneDrive, Dropbox). This protects you against ransomware attacks, where attackers encrypt your files and demand payment to unlock them. The 3-2-1 rule: 3 copies, on 2 different media, with 1 stored off-site.",

                    "Avoid pirated software at all costs. Free 'cracked' versions of paid software (Adobe Photoshop, Microsoft Office, games) are one of the most common ways attackers distribute viruses, trojans, and cryptominers. The few rands you save are not worth the security risk."
                }
            };
        }

        // ==================== PUBLIC METHODS ====================

        public string GetRandomResponse(string topic, string userName)
        {
            if (!_responseMap.ContainsKey(topic))
                return $"I don't have information about that, {userName}.";

            List<string> responses = _responseMap[topic];

            if (responses.Count == 1)
                return $"{userName}, {responses[0]}";

            string selected;
            int attempts = 0;
            do
            {


                int index = _random.Next(responses.Count);
                selected = responses[index];
                attempts++;
            } while (selected == _lastResponse && attempts < 10);

            _lastResponse = selected;
            return $"{userName}, {selected}";
        }

        
        public bool ContainsKeyword(string input, out string matchedTopic)
        {
            matchedTopic = "";
            foreach (var topic in _responseMap.Keys)
            {
                if (input.Contains(topic, StringComparison.OrdinalIgnoreCase))
                {
                    matchedTopic = topic;
                    return true;
                }
            }
            return false;
        }

        
        public IEnumerable<string> GetAllTopics()
        {
            return _responseMap.Keys;
        }

       
        public void SetLastTopic(string topic)
        {
            LastTopic = topic;
        }
    }
}