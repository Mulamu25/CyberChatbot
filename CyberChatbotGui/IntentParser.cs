using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CyberChatbotGui
{
    public class IntentParser
    {
        public string ParseIntent(string input, out string extractedTask, out string extractedDate)
        {
            extractedTask = "";
            extractedDate = "";

            string lowerInput = input.ToLower().Trim();

            
            var taskMatch = Regex.Match(input, @"(?:remind me to|add a task to|add task to|set a reminder to|add a task|i need to|remember to)\s+(.+)", RegexOptions.IgnoreCase);
            if (taskMatch.Success)
            {
                string fullTask = taskMatch.Groups[1].Value.Trim();


                
                if(fullTask.ToLower().Contains("tomorrow"))
                {

                    extractedDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                    fullTask = fullTask.Replace("tomorrow", "").Trim();
                }
                else
                {
                    var dateMatch = Regex.Match(fullTask, @"in (\d+) days?", RegexOptions.IgnoreCase);
                    if (dateMatch.Success)
                    {
                        int days = int.Parse(dateMatch.Groups[1].Value);
                        extractedDate = DateTime.Now.AddDays(days).ToString("yyyy-MM-dd");
                        fullTask = Regex.Replace(fullTask, @"in \d+ days?", "", RegexOptions.IgnoreCase).Trim();
                    }
                }

                extractedTask = fullTask;
                return "ADD_TASK";
            }

            //NLP for Showing Tasks
            if(lowerInput.Contains("show tasks") || lowerInput.Contains("my tasks") || lowerInput.Contains("what do i need to do"))
                return "SHOW_TASKS";

            //NLP for Starting Quiz
            if(lowerInput.Contains("start quiz") || lowerInput.Contains("play quiz") || lowerInput.Contains("test my knowledge"))
                return "START_QUIZ";

            //NLP for Showing Activity log
            if(lowerInput.Contains("show activity log") || lowerInput.Contains("what have you done"))
                return "SHOW_LOG";
            
            return "UNKNOWN";

        }
    }
}
