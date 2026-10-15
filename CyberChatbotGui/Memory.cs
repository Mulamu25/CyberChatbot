using System;
using System.Collections.Generic;
using System.Text;

namespace CyberChatbotGui
{
    public class Memory
    {

        public string UserName { get; set; } = "";

        public string FavouriteTopic { get; set; } = "";

        public List<string> TopicDiscussed { get; private set; } = new List<string>();

        public bool HasName()
        {
            return !string.IsNullOrWhiteSpace(UserName);

        }

        public bool HasFavouriteTopic()
        {
            return !string.IsNullOrWhiteSpace(FavouriteTopic);
        }

        public void RecordTopic(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                return;
            }

            if (!TopicDiscussed.Contains(topic, StringComparer.OrdinalIgnoreCase))
            {
                TopicDiscussed.Add(topic);
            }
        }

        public bool HasDiscussed(string topic)
        {
            return TopicDiscussed.Contains(topic, StringComparer.OrdinalIgnoreCase);
        }
    }
}
