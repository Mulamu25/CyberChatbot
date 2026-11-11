using System;
using System.Collections.Generic;
using MySqlConnector;
using System.Windows;

namespace CyberChatbotGui
{
    public class TaskRepository
    {
        // ⚠️ REPLACE 'YourPasswordHere' WITH YOUR ACTUAL MYSQL ROOT PASSWORD
        private readonly string _connectionString = "Server=localhost;Database=cyberchatbot;User ID=root;Password=Godblessme@25;";

        public TaskRepository()
        {
            CreateTableIfNotExists();
        }

        private void CreateTableIfNotExists()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        CREATE TABLE IF NOT EXISTS SecurityTasks (
                            Id INT AUTO_INCREMENT PRIMARY KEY,
                            Title VARCHAR(100) NOT NULL,
                            Description VARCHAR(500),
                            ReminderDate DATETIME NULL,
                            IsCompleted BOOLEAN DEFAULT FALSE
                        )";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn)) { cmd.ExecuteNonQuery(); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}\n\nTasks will not save. Check your MySQL password.", "Connection Error");
            }
        }

        public void AddTask(SecurityTask task)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO SecurityTasks (Title, Description, ReminderDate, IsCompleted) VALUES (@Title, @Desc, @Date, @Complete)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", task.Title);
                        cmd.Parameters.AddWithValue("@Desc", task.Description ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Date", task.ReminderDate ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Complete", task.IsCompleted);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error adding task: {ex.Message}"); }
        }

        public List<SecurityTask> GetAllTasks()
        {
            var tasks = new List<SecurityTask>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, Title, Description, ReminderDate, IsCompleted FROM SecurityTasks";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tasks.Add(new SecurityTask
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                ReminderDate = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                IsCompleted = reader.GetBoolean(4)
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error loading tasks: {ex.Message}"); }
            return tasks;
        }

        public void DeleteTask(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM SecurityTasks WHERE Id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error deleting task: {ex.Message}"); }
        }

        public void CompleteTask(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "UPDATE SecurityTasks SET IsCompleted = 1 WHERE Id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error completing task: {ex.Message}"); }
        }
    }
}