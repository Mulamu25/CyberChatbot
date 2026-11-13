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
        // Helper properties for the UI
        public string DisplayStatus
        {
            get
            {
                if (IsCompleted) return " Completed";

                // If it has a reminder date and that date is in the past, it's overdue!
                if (ReminderDate.HasValue && ReminderDate.Value < DateTime.Now)
                    return " Overdue";

                return " Pending";
            }
        }

        public string DisplayDate => ReminderDate.HasValue
            ? ReminderDate.Value.ToString("yyyy-MM-dd HH:mm")
            : "No reminder";
        
    }
}