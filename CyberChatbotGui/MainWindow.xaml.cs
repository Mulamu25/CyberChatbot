using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CyberChatbotGui
{
    public partial class MainWindow : Window
    {
        // ==================== FIELDS ====================
        private AudioPlayer _audioPlayer = new AudioPlayer();
        private ChatbotEngine _engine = new ChatbotEngine();
        private TaskRepository _taskRepo = new TaskRepository();
        private QuizEngine _quizEngine;


        private const string DIVIDER = "================================================";

        public MainWindow()
        {
            InitializeComponent();
            LoadTasks();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Play voice greeting
            _audioPlayer.PlayGreeting();

            // Set ASCII art in the header
            AsciiArtTextBlock.Text = @"
 ██████╗██╗   ██╗██████╗ ███████╗██████╗ ███████╗███████╗ ██████╗██╗   ██╗██████╗ ██╗████████╗██╗   ██╗
██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝██╔════╝██║   ██║██╔══██╗██║╚══██╔══╝╚██╗ ██╔╝
██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝███████╗█████╗  ██║     ██║   ██║██████╔╝██║   ██║    ╚████╔╝ 
██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗╚════██║██╔══╝  ██║     ██║   ██║██╔══██╗██║   ██║     ╚██╔╝  
╚██████╗   ██║   ██████╔╝███████╗██║  ██║███████║███████╗╚██████╗╚██████╔╝██║  ██║██║   ██║      ██║   
 ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝   


 █████╗ ██╗    ██╗ █████╗ ██████╗ ███████╗███╗   ██╗███████╗███████╗███████╗
██╔══██╗██║    ██║██╔══██╗██╔══██╗██╔════╝████╗  ██║██╔════╝██╔════╝██╔════╝
███████║██║ █╗ ██║███████║██████╔╝█████╗  ██╔██╗ ██║█████╗  ███████╗███████╗
██╔══██║██║███╗██║██╔══██║██╔══██╗██╔══╝  ██║╚██╗██║██╔══╝  ╚════██║╚════██║
██║  ██║╚███╔███╔╝██║  ██║██║  ██║███████╗██║ ╚████║███████╗███████║███████║
╚═╝  ╚═╝ ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═══╝╚══════╝╚══════╝╚══════╝

 ██████╗  ██████╗ ████████╗
██╔══██╗██╔═══██╗╚══██╔══╝
██████╔╝██║   ██║   ██║   
██╔══██╗██║   ██║   ██║   
██████╔╝╚██████╔╝   ██║   
╚═════╝  ╚═════╝    ╚═╝   
";

            // Welcome message in chat
           
            AddChatMessage("Assistant", "   WELCOME TO THE CYBERCHATBOT SYSTEM\n\nPlease enter your name:");
            
            
        }
        private void SendButton_Click(object sender, RoutedEventArgs e) => ProcessUserInput();

        private void UserInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) ProcessUserInput();
        }

        private void VoiceButton_Click(object sender, RoutedEventArgs e)
        {
            _audioPlayer.PlayGreeting();
        }

        
        private void ProcessUserInput()
        {
            string input = UserInputTextBox.Text?.Trim();
            if (string.IsNullOrEmpty(input)) return;

            AddChatMessage("You", input);
            UserInputTextBox.Clear();
            UserInputTextBox.Focus();

            // First input = name
            if (!_engine.HasName)
            {
                _engine.UserName = input;
                
                AddChatMessage("Bot", $"Welcome, {_engine.UserName}! You are now connected to the CyberChatbot System.");
                
                AddChatMessage("Bot", $"I can help you with passwords, phishing, safe browsing, scams, and privacy. What would you like to know, {_engine.UserName}?");
                return;
            }

            string response = _engine.GetResponse(input);
            AddChatMessage("Bot", response);
        }

        
        private void AddChatMessage(string sender, string message)
        {
            //  COLOURS 
            Color cyanAccent = Color.FromRgb(0, 217, 255);       
            Color botBubbleBg = Color.FromRgb(42, 42, 62);        
            Color deepBackground = Color.FromRgb(30, 30, 46);    

            bool isUser = sender == "You";

            //  OUTER CONTAINER 
            var container = new StackPanel
            {
                Margin = new Thickness(5, 6, 5, 6),
                MaxWidth = 700,
                HorizontalAlignment = isUser
                    ? HorizontalAlignment.Right
                    : HorizontalAlignment.Left
            };

            // "You" LABEL
            if (isUser)
            {
                var label = new TextBlock
                {
                    Text = "You",
                    Foreground = new SolidColorBrush(cyanAccent),
                    FontSize = 11,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(8, 0, 8, 3),
                    HorizontalAlignment = HorizontalAlignment.Right
                };
                container.Children.Add(label);
            }

            //  BUBBLE GRID (Text + Accent Line) 
            var bubbleGrid = new Grid();
            bubbleGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            bubbleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3) });   

            //  Message Text 
            var textBlock = new TextBlock
            {
                Text = message,
                Foreground = isUser
                    ? new SolidColorBrush(deepBackground)  
                    : new SolidColorBrush(cyanAccent),      
                FontSize = 14,
                TextWrapping = TextWrapping.Wrap,
                LineHeight = 20,
                Padding = new Thickness(14, 10, 14, 10)
            };
            Grid.SetRow(textBlock, 0);

            //  Accent Line 
            var accentLine = new Border
            {
                Background = new SolidColorBrush(cyanAccent),
                CornerRadius = new CornerRadius(0, 0, 15, 15),   
                Height = 3
            };
            Grid.SetRow(accentLine, 1);

            // BUBBLE BACKGROUND 
            var bubble = new Border
            {
                CornerRadius = new CornerRadius(15),
                Background = isUser
                    ? new SolidColorBrush(cyanAccent)      
                    : new SolidColorBrush(botBubbleBg),    
                ClipToBounds = true
            };

            
            bubbleGrid.Children.Add(textBlock);
            bubbleGrid.Children.Add(accentLine);
            bubble.Child = bubbleGrid;

            container.Children.Add(bubble);
            ChatStackPanel.Children.Add(container);

            ChatScrollViewer.ScrollToEnd();
        }
        private void LoadTasks()
        {
            TasksDataGrid.ItemsSource = _taskRepo.GetAllTasks();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskTitleInput.Text)) return;

            var newTask = new SecurityTask
            {
                Title = TaskTitleInput.Text,
                Description = TaskDescInput.Text,
                ReminderDate = TaskDateInput.SelectedDate,
                IsCompleted = false
            };

            _taskRepo.AddTask(newTask);

            // Clear inputs
            TaskTitleInput.Clear();
            TaskDescInput.Clear();
            TaskDateInput.SelectedDate = null;

            // Refresh list
            LoadTasks();
        }

        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is SecurityTask task)
            {
                _taskRepo.CompleteTask(task.Id);
                LoadTasks();
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is SecurityTask task)
            {
                _taskRepo.DeleteTask(task.Id);
                LoadTasks();
            }
        }
        private void StartQuizBtn_Click(object sender, RoutedEventArgs e)
        {
            _quizEngine = new QuizEngine();
            StartQuizBtn.Visibility = Visibility.Collapsed; // Hide start button
            QuizOptionsPanel.Visibility = Visibility.Visible;
            QuizFeedbackText.Text = "";
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            if (_quizEngine == null || _quizEngine.IsFinished())
            {
                ShowQuizResults();
                return;
            }

            var q = _quizEngine.GetCurrentQuestion();
            QuizQuestionText.Text = $"Q{_quizEngine.CurrentQuestionIndex + 1}: {q.QuestionText}";
            OptionA.Content = q.OptionA;
            OptionB.Content = q.OptionB;
            OptionC.Content = q.OptionC;
            OptionD.Content = q.OptionD;

            // Hide buttons if it's a True/False question (where C and D are N/A)
            OptionC.Visibility = q.OptionC == "N/A" ? Visibility.Collapsed : Visibility.Visible;
            OptionD.Visibility = q.OptionD == "N/A" ? Visibility.Collapsed : Visibility.Visible;

            QuizOptionsPanel.IsEnabled = true;
            QuizFeedbackText.Text = "";
        }

        private void QuizOption_Click(object sender, RoutedEventArgs e)
        {
            if (_quizEngine == null) return;

            Button btn = sender as Button;
            string answer = btn.Tag.ToString();

            bool isCorrect = _quizEngine.SubmitAnswer(answer);
            var q = _quizEngine.GetCurrentQuestion();

            if (isCorrect)
                QuizFeedbackText.Text = "✅ Correct! " + q.Explanation;
            else
                QuizFeedbackText.Text = $"❌ Incorrect. The answer was {q.CorrectAnswer}. " + q.Explanation;

            QuizOptionsPanel.IsEnabled = false; // Disable buttons so they can't click twice
            _quizEngine.NextQuestion();

            // Wait 3.5 seconds and load next question
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3.5);
            timer.Tick += (s, args) => { timer.Stop(); LoadQuestion(); };
            timer.Start();
        }

        private void ShowQuizResults()
        {
            QuizQuestionText.Text = $"Quiz Complete! Your Score: {_quizEngine.Score} / {_quizEngine.GetTotalQuestions()}";

            if (_quizEngine.Score >= 10)
                QuizFeedbackText.Text = "Great job! You're a cybersecurity pro!";
            else
                QuizFeedbackText.Text = "Keep learning to stay safe online!";

            QuizOptionsPanel.Visibility = Visibility.Collapsed;
            StartQuizBtn.Visibility = Visibility.Visible;
            StartQuizBtn.Content = "Restart Quiz";
        }
    }
}