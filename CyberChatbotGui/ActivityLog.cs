using System;
using System.Collections.Generic;
using System.Text;

namespace CyberChatbotGui
{
    public  class ActivityLog
    {

        private List<string> _logs = new List<string>();

        //Add a new action to the log with a timestamp
        public void AddLog(string action)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            _logs.Add($"[{timestamp}] {action}");
        }

        //Returns the last 5 actions as a formatted string 
        public string GetLogSummary()
        {
            if(_logs.Count == 0)  return "I haven't done anything yet.";

            int start = Math.Max(0, _logs.Count - 5); // Get last 5 actions
            string summary = "Here's a summary of my recent actions:\n\n";

            for (int i = start; i < _logs.Count; i++)
            {
                summary += $"- {_logs[i]}\n";

            }
            return summary;

        }
    }
}
