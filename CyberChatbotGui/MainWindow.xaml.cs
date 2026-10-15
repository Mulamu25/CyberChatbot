using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CyberChatbotGui
{
    public partial class MainWindow : Window
    {
        private AudioPlayer _audioPlayer = new AudioPlayer();
        private ResponseHandler _responseHandler = new ResponseHandler();
        private Memory _memory = new Memory();
        private string _userName = "";

        private const string DIVIDER = "================================================";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Play voice greeting
            _audioPlayer.PlayGreeting();

            // Set ASCII art in the header
            AsciiArtTextBlock.Text = @"
 ██████╗██╗   ██╗██████╗ ███████╗██████╗ ███████╗███████╗ ██████╗██╗   ██╗██████╗ ██╗████████╗██╗   ██╗
██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝██╔════╝╚██╗ ██╔╝██╔══██╗██║╚══██╔══╝╚██╗ ██╔╝
██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝███████╗█████╗  ██║      ╚████╔╝ ██████╔╝██║   ██║    ╚████╔╝ 
██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗╚════██║██╔══╝  ██║       ╚██╔╝  ██╔══██╗██║   ██║     ╚██╔╝  
╚██████╗   ██║   ██████╔╝███████╗██║  ██║███████║███████╗╚██████╗   ██║   ██║  ██║██║   ██║      ██║   
 ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝╚══════╝ ╚═════╝   ╚═╝   ╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝   

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
            AddChatMessage("Assistant", DIVIDER);
            AddChatMessage("Assistant", "   WELCOME TO THE CYBERCHATBOT SYSTEM");
            AddChatMessage("Assistant", DIVIDER);
            AddChatMessage("Assistant", "Please enter your name:");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessUserInput();
        }

        private void UserInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessUserInput();
            }
        }

        private void VoiceButton_Click(object sender, RoutedEventArgs e)
        {
            _audioPlayer.PlayGreeting();
        }

        private void ProcessUserInput()
        {
            string input = UserInputTextBox.Text.Trim();

            //Doesn't process empty messages
            if (string.IsNullOrEmpty(input)) return;

            //it shows user's message
            AddChatMessage("You", input);

            if (string.IsNullOrEmpty(_userName))

                HandleNameInput(input);

            else
                HandleChatMessage(input);

            //Reset input box
            UserInputTextBox.Clear();
            UserInputTextBox.Focus();
        }

        private void HandleNameInput(string name)
        {
            _memory.UserName = name;
            _userName = name;
            AddChatMessage("Assistant", DIVIDER);
            AddChatMessage("Assistant", $"Welcome, {_userName}! You are now connected to the CyberChatbot System.");
            AddChatMessage("Assistant", DIVIDER);
            AddChatMessage("Assistant", $"I can help you with passwords, phishing, safe browsing, and privacy. What would you like to know, {_userName}?");
        }
        private void HandleChatMessage(string input)
        {
            string lowerInput = input.ToLower();

            if (lowerInput.Contains("what do you remember") || lowerInput.Contains("what do you know about me"))
            {
                if (!_memory.HasName())
                {
                    AddChatMessage("Bot", "I don't know anything about you yet. What's your name?");
                }
                else
                {
                    string info = $"I remember your name is {_memory.UserName}";
                    if (_memory.HasFavouriteTopic())
                        info += $", and you're interested in {_memory.FavouriteTopic}";
                    info += ".";
                    AddChatMessage("Bot", info);
                }
                return;
            }
            if (lowerInput.Contains("interested in") || lowerInput.Contains("i like") || lowerInput.Contains("favourite"))
            {
                // Try to detect the topic
                foreach (var topic in new[] { "password", "scam", "privacy", "phishing", "browsing", "malware" })
                {
                    if (lowerInput.Contains(topic))
                    {
                        _memory.FavouriteTopic = topic;
                        _memory.RecordTopic(topic);
                        AddChatMessage("Bot", $"Great, {_memory.UserName}! I'll remember that you're interested in {topic}. It's a crucial part of staying safe online.");
                        return;
                    }
                }
            }

            // Get response from ResponseHandler
            string response = _responseHandler.GetResponse(input, _userName);

            // Track the topic being discussed
            foreach (var topic in new[] { "password", "scam", "privacy", "phishing", "browsing", "malware" })
            {
                if (lowerInput.Contains(topic))
                {
                    _memory.RecordTopic(topic);
                    break;
                }
            }

            // If we have a favourite topic, occasionally reference it
            if (_memory.HasFavouriteTopic() && _memory.FavouriteTopic != "" && response.Length > 0)
            {
                // If user's favourite topic is different from current topic, append a callback
                if (!lowerInput.Contains(_memory.FavouriteTopic) && new Random().Next(3) == 0)
                {
                    response += $" As someone interested in {_memory.FavouriteTopic}, you might also want to review that area.";
                }
            }
            AddChatMessage("Assistant", response);


        }

        private void AddChatMessage(string sender, string message)
        {
            var textBlock = new TextBlock
            {
                Text = $"{sender}: {message}",
                Foreground = sender == "You" ? Brushes.LightGreen : Brushes.LightBlue,
                FontSize = 14,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5, 3, 5, 3)
            };

            ChatStackPanel.Children.Add(textBlock);
            ChatScrollViewer.ScrollToEnd();
        }

    }
}