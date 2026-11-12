# PROG6221 — Cybersecurity Awareness Chatbot (Final POE)

A WPF (Windows Presentation Foundation) desktop application built in C#. This final part extends the chatbot into a full Task Assistant with MySQL database integration, a Quiz Mini-Game, NLP simulation, and an Activity Log.

## Requirements
- Windows 10/11
- Visual Studio 2022 (with .NET desktop development workload)
- .NET 10.0 SDK (or .NET 8.0)
- MySQL Server 8+ running locally (or MySQL Workbench)

## MySQL Setup
1. Open **MySQL Workbench** and create a database named `cyberchatbot`:
   ```sql
   CREATE DATABASE cyberchatbot;
2. private readonly string _connectionString = "Server=localhost;Database=cyberchatbot;User ID=root;Password=Godblessme@25;";
   
## Feature Demonstration
> Chat: My name is Thabo; I am interested in privacy; What is my favourite topic?; I am worried about phishing; another tip.
> NLP Tasks (Chat): add a task to enable 2FA; remind me to update my password tomorrow; add a reminder to check privacy settings in 7 days; show tasks.
> Task Tab: Add a title, description, and optional date. Complete or delete tasks. Overdue tasks are highlighted in red. Tasks persist in MySQL.
> Quiz: Click the Quiz tab to answer 12 multiple-choice and true/false questions. Immediate colour-coded feedback (Green for correct, Red for incorrect) and a final score.
> Activity Log (Chat): show activity log or what have you done to see the latest 5 actions.
> Voice: CyberGreeting.wav plays at launch or by clicking the Greeting button.

## Architecture
>MainWindow.xaml.cs: WPF GUI and event handlers.
>ChatbotEngine.cs: The brain connecting keywords, sentiment, and NLP memory.
>ResponseHandler.cs: Random cybersecurity tips.
>Memory.cs: Remembers user's name and favourite topic.
>SentimentDetector.cs: Detects worried, curious, and frustrated emotions.
>TaskRepository.cs: Parameterized MySQL CRUD operations.
>Models.cs: Data structures for tasks (with overdue logic).
>QuizEngine.cs: 12-question scored quiz.
>IntentParser.cs: Regex-based NLP simulation for natural language.
>ActivityLog.cs: Recent timestamped actions.
>.github/workflows/ci.yml: Automated Windows build with .NET 10.

## GitHub and Releases
The repository contains 6+ meaningful commits, version tags, and release notes:

v1.0: Part 1 Console App
v2.0: Part 2 WPF GUI
v3.0: Final POE (Tasks, DB, Quiz, NLP, Log)

## YOUTUBE LINK

## AUTHOR
MULAMULELI MUNGADI

## REFERENCES
Pieterse, H. 2021. The Cyber Threat Landscape in South Africa: A 10-Year Review. The African Journal of Information and Communication, 28(28).



