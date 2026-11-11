using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace CyberChatbotGui
{
    public class TaskRepository
    {
        // Connects to your SSMS LocalDB
        private readonly string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CyberChatbotDB;Trusted_Connection=True;";

        public TaskRepository()
        {
            CreateTableIfNotExists();
        }

        private void CreateTableIfNotExists()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='SecurityTasks' AND xtype='U')
                        CREATE TABLE SecurityTasks (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            Title NVARCHAR(100) NOT NULL,
                            Description NVARCHAR(500),
                            ReminderDate DATETIME NULL,
                            IsCompleted BIT DEFAULT 0
                        )";
                    using (SqlCommand cmd = new SqlCommand(query, conn)) { cmd.ExecuteNonQuery(); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}\n\nTasks will not save.", "Connection Error");
            }
        }

        public void AddTask(SecurityTask task)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO SecurityTasks (Title, Description, ReminderDate, IsCompleted) VALUES (@Title, @Desc, @Date, @Complete)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
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
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, Title, Description, ReminderDate, IsCompleted FROM SecurityTasks";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
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
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM SecurityTasks WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
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
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "UPDATE SecurityTasks SET IsCompleted = 1 WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
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