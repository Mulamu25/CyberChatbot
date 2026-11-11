using System;

namespace CyberChatbotGui
{
    public class SecurityTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }

        // Helper properties for the UI
        public string DisplayStatus => IsCompleted ? " Completed" : " Pending";

        public string DisplayDate => ReminderDate.HasValue
            ? ReminderDate.Value.ToString("yyyy-MM-dd HH:mm")
            : "No reminder";
    }
}