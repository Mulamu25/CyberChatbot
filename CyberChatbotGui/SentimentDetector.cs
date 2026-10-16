using System;

namespace CyberChatbotGui
{
    
    public class SentimentDetector
    {
        public enum Sentiment
        {
            Neutral,
            Worried,
            Curious,
            Frustrated
        }

        public Sentiment Detect(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Sentiment.Neutral;

            string lowerInput = input.ToLower().Trim();

            // ==================== WORRIED ====================
            string[] worriedKeywords =
            {
                "worried", "scared", "afraid", "anxious",
                "nervous", "concerned", "fear", "unsafe",
                "panic", "stress"
            };

            foreach (var keyword in worriedKeywords)
            {
                if (lowerInput.Contains(keyword))
                    return Sentiment.Worried;
            }

            // ==================== CURIOUS ====================
            string[] curiousKeywords =
            {
                "curious", "interested", "wondering",
                "tell me", "how does", "how do",
                "what is", "want to learn", "explain"
            };

            foreach (var keyword in curiousKeywords)
            {
                if (lowerInput.Contains(keyword))
                    return Sentiment.Curious;
            }

            // ==================== FRUSTRATED ====================
            string[] frustratedKeywords =
            {
                "frustrated", "annoyed", "confused",
                "don't understand", "dont understand",
                "too complicated", "too hard", "difficult",
                "hate", "tired of", "give up"
            };

            foreach (var keyword in frustratedKeywords)
            {
                if (lowerInput.Contains(keyword))
                    return Sentiment.Frustrated;
            }

            return Sentiment.Neutral;
        }

        public string GetSentimentPrefix(Sentiment sentiment, string userName)
        {
            switch (sentiment)
            {
                case Sentiment.Worried:
                    return $"It's completely understandable to feel that way, {userName}. Cybersecurity can feel overwhelming, but you're already taking the right step by learning. ";

                case Sentiment.Curious:
                    return $"I love your curiosity, {userName}! Here's something useful: ";

                case Sentiment.Frustrated:
                    return $"I hear you, {userName}. It can be frustrating, but don't worry — I'll keep it simple. ";

                default:
                    return "";
            }
        }
    }
}



