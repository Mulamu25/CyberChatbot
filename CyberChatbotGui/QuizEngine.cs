using System;
using System.Collections.Generic;
using System.Text;

namespace CyberChatbotGui
{

    public class  QuizQuestion
    {
        public string QuestionText { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; } 
        public string OptionD { get; set; }
        public string CorrectAnswer { get; set; }
        public string Explanation { get; set; }
    }
    public  class QuizEngine
    {
        private List<QuizQuestion> _questions;
        public int CurrentQuestionIndex { get; private set; }
        public int Score { get; private set; }

        public QuizEngine()
        {
            LoadQuestions();
            CurrentQuestionIndex = 0;
            Score = 0;

        }

        private void LoadQuestions()
        {
            _questions = new List<QuizQuestion>
            {
                new QuizQuestion { QuestionText = "What should you do if you receive an email asking for your password?", OptionA = "Reply with your password", OptionB = "Delete the email", OptionC = "Report the email as phishing", OptionD = "Ignore it", CorrectAnswer = "C", Explanation = "Reporting phishing emails helps prevent scams." },
                new QuizQuestion { QuestionText = "True or False: It is safe to use the same password for all your accounts.", OptionA = "True", OptionB = "False", OptionC = "N/A", OptionD = "N/A", CorrectAnswer = "B", Explanation = "If one account is breached, all your accounts become vulnerable." },
                new QuizQuestion { QuestionText = "What does 'HTTPS' stand for in a website URL?", OptionA = "HyperText Transfer Protocol Secure", OptionB = "High Tech Transfer Protocol System", OptionC = "HyperText Transmission Privacy", OptionD = "Home Tool Transfer Protocol", CorrectAnswer = "A", Explanation = "The 'S' stands for Secure, meaning your data is encrypted." },
                new QuizQuestion { QuestionText = "Which of the following is a sign of a phishing attack?", OptionA = "The email is from a known contact", OptionB = "Urgent language demanding action", OptionC = "The email has no attachments", OptionD = "Perfect grammar and spelling", CorrectAnswer = "B", Explanation = "Attackers use urgency to make you act without thinking." },
                new QuizQuestion { QuestionText = "True or False: Public Wi-Fi is always safe to use for banking.", OptionA = "True", OptionB = "False", OptionC = "N/A", OptionD = "N/A", CorrectAnswer = "B", Explanation = "Public Wi-Fi is often unsecured and can be intercepted." },
                new QuizQuestion { QuestionText = "What is Two-Factor Authentication (2FA)?", OptionA = "Using two passwords", OptionB = "A second layer of security beyond your password", OptionC = "Logging in from two devices", OptionD = "Having two email addresses", CorrectAnswer = "B", Explanation = "2FA requires a second piece of evidence (like a code) to log in." },
                new QuizQuestion { QuestionText = "What should you do before clicking a link in an email?", OptionA = "Click it immediately", OptionB = "Forward it to friends", OptionC = "Hover over it to check the real URL", OptionD = "Reply to the sender", CorrectAnswer = "C", Explanation = "Hovering reveals the actual destination of the link." },
                new QuizQuestion { QuestionText = "True or False: Antivirus software makes you 100% immune to malware.", OptionA = "True", OptionB = "False", OptionC = "N/A", OptionD = "N/A", CorrectAnswer = "B", Explanation = "No software is perfect. You still need safe browsing habits." },
                new QuizQuestion { QuestionText = "What is a 'Zero-Day' vulnerability?", OptionA = "A bug that happens at midnight", OptionB = "A flaw that is unknown to the software vendor", OptionC = "A virus that deletes all files", OptionD = "A password with zero characters", CorrectAnswer = "B", Explanation = "It's a vulnerability exploited before the vendor can fix it." },
                new QuizQuestion { QuestionText = "How often should you back up your important files?", OptionA = "Once a year", OptionB = "Never", OptionC = "Regularly (e.g., daily or weekly)", OptionD = "Only when your computer is slow", CorrectAnswer = "C", Explanation = "Regular backups protect you against ransomware and hardware failure." },
                new QuizQuestion { QuestionText = "Which of these is a strong password?", OptionA = "password123", OptionB = "MyBirthday1990", OptionC = "P@ssw0rd!2024", OptionD = "qwerty", CorrectAnswer = "C", Explanation = "It uses uppercase, lowercase, numbers, and symbols." },
                new QuizQuestion { QuestionText = "True or False: You should share your One-Time PIN (OTP) with customer support if they ask.", OptionA = "True", OptionB = "False", OptionC = "N/A", OptionD = "N/A", CorrectAnswer = "B", Explanation = "Legitimate companies will NEVER ask for your OTP." }
            };
        }
        public QuizQuestion GetCurrentQuestion()
        {
            if (CurrentQuestionIndex < _questions.Count)
                return _questions[CurrentQuestionIndex];
            return null;
        }

        public bool SubmitAnswer(string answer)
        {
            bool isCorrect = answer == _questions[CurrentQuestionIndex].CorrectAnswer;
            if (isCorrect) Score++;
            return isCorrect;

        }

        public void NextQuestion()
        {
            CurrentQuestionIndex++;
        }

        public bool IsFinished()
        {
            return CurrentQuestionIndex >= _questions.Count;

        }

        public int GetTotalQuestions() => _questions.Count;
    }
}
