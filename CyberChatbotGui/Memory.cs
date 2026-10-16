using System;
using System.Collections.Generic;

namespace CyberChatbotGui
{
    
    public class Memory
    {
        
        public string UserName { get; set; } = "";

        public string FavouriteTopic { get; set; } = "";

       
        public List<string> TopicsDiscussed { get; private set; } = new List<string>();

       
        public bool HasName()
        {
            return !string.IsNullOrEmpty(UserName);
        }

        public bool HasFavouriteTopic()
        {
            return !string.IsNullOrEmpty(FavouriteTopic);
        }

        public void RecordTopic(string topic)
        {
            if (string.IsNullOrEmpty(topic)) return;

            if (!TopicsDiscussed.Contains(topic, StringComparer.OrdinalIgnoreCase))
                TopicsDiscussed.Add(topic);
        }

        public bool HasDiscussed(string topic)
        {
            return TopicsDiscussed.Contains(topic, StringComparer.OrdinalIgnoreCase);
        }
    }
}