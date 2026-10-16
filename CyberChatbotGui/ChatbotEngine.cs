using System;
using System.Collections.Generic;

namespace CyberChatbotGui
{
    
    public class ChatbotEngine
    {
        // ==================== DEPENDENCIES ====================
        private readonly Memory _memory = new Memory();
        private readonly SentimentDetector _sentiment = new SentimentDetector();
        private readonly ResponseHandler _responseHandler = new ResponseHandler();

        // ==================== PUBLIC PROPERTIES ====================
        public string UserName
        {
            get => _memory.UserName;
            set => _memory.UserName = value;
        }

        public bool HasName => _memory.HasName();

        // ==================== MAIN METHOD ====================
       
        public string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return $"I didn't quite catch that, {_memory.UserName}. Could you rephrase?";

            string question = userInput.ToLower().Trim();

            // ==================== MEMORY QUERIES ====================
            if (question.Contains("what is my name") ||
                question.Contains("who am i") ||
                question.Contains("my name"))
            {
                return _memory.HasName()
                    ? $"Your name is {_memory.UserName}, of course."
                    : "You haven't told me your name yet.";
            }

            if (question.Contains("what am i interested in") ||
                question.Contains("what do i like") ||
                question.Contains("my favourite") ||
                question.Contains("what do you remember"))
            {
                if (_memory.HasFavouriteTopic())
                    return $"You are interested in {_memory.FavouriteTopic}, {_memory.UserName}. I'll keep that in mind when I give you tips.";
                return $"You haven't told me your favourite topic yet, {_memory.UserName}. Try saying 'I'm interested in privacy'.";
            }

            // ==================== SET FAVOURITE TOPIC ====================
            if (question.Contains("interested in") || question.Contains("i like"))
            {
                if (_responseHandler.ContainsKeyword(question, out string favTopic))
                {
                    _memory.FavouriteTopic = favTopic;
                    _responseHandler.SetLastTopic(favTopic);
                    return $"Great! I'll remember that you're interested in {favTopic}. It's a crucial part of staying safe online.";
                }
            }

            // ==================== "TELL ME MORE" ====================
            if (question.Contains("tell me more") ||
                question.Contains("explain more") ||
                question.Contains("another tip") ||
                question.Contains("more info"))
            {
                if (!string.IsNullOrEmpty(_responseHandler.LastTopic))
                    return _responseHandler.GetRandomResponse(_responseHandler.LastTopic, _memory.UserName);

                return $"What topic would you like to know more about, {_memory.UserName}? (e.g., password, phishing, browsing)";
            }

            // ==================== SENTIMENT DETECTION ====================
            var sentiment = _sentiment.Detect(question);
            string sentimentPrefix = _sentiment.GetSentimentPrefix(sentiment, _memory.UserName);

            // ==================== KEYWORD RESPONSE ====================
            if (_responseHandler.ContainsKeyword(question, out string matchedTopic))
            {
                _responseHandler.SetLastTopic(matchedTopic);
                _memory.RecordTopic(matchedTopic);

                string response = sentimentPrefix + _responseHandler.GetRandomResponse(matchedTopic, _memory.UserName);

                // Occasionally reference favourite topic
                if (_memory.HasFavouriteTopic() &&
                    !question.Contains(_memory.FavouriteTopic) &&
                    new Random().Next(3) == 0)
                {
                    response += $" As someone interested in {_memory.FavouriteTopic}, you might also want to review that area.";
                }

                return response;
            }

            // ==================== SENTIMENT-ONLY RESPONSE ====================
            if (sentiment != SentimentDetector.Sentiment.Neutral)
            {
                var topics = new List<string>(_responseHandler.GetAllTopics());
                string randomTopic = topics[new Random().Next(topics.Count)];
                return sentimentPrefix + $"Here is a tip about {randomTopic}: " +
                       _responseHandler.GetRandomResponse(randomTopic, _memory.UserName);
            }

            // ==================== DEFAULT ====================
            return $"Sorry {_memory.UserName}, I didn't quite understand that. Try asking about passwords, phishing, safe browsing, scams, or privacy.";
        }
    }
}