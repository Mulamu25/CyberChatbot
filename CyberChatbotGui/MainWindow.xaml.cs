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
            _userName = name;
            AddChatMessage("Assistant", DIVIDER);
            AddChatMessage("Assistant", $"Welcome, {_userName}! You are now connected to the CyberChatbot System.");
            AddChatMessage("Assistant", DIVIDER);
            AddChatMessage("Assistant", $"I can help you with passwords, phishing, safe browsing, and privacy. What would you like to know, {_userName}?");
        }
        private void HandleChatMessage(string input)
        {
            // TODO: Call ResponseHandler here (next step)
            AddChatMessage("Assistant", $"I'm still learning, {_userName}! Response logic coming soon.");
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