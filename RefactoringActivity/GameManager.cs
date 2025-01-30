namespace RefactoringActivity
{
    public class GameManager
    {
        public bool IsRunning { get; private set; }
        public Player Player { get; private set; }
        public World World { get; private set; }

        public GameManager()
        {
            Player = new Player(100);
            World = new World();
        }

        public void RunGame()
        {
            InitializeGame();
            GameLoop();
        }

        private void InitializeGame()
        {
            IsRunning = true;
            Console.WriteLine("Welcome to the Text Adventure Game!");
            Console.WriteLine("Type 'help' for a list of commands.");
        }

        private void GameLoop()
        {
            while (IsRunning)
            {
                DisplayLocation();
                string command = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
                ProcessCommand(command);
            }
        }

        private void DisplayLocation()
        {
            Console.WriteLine();
            Console.WriteLine(World.GetLocationDetails(Player.CurrentLocation));
            Console.Write("> ");
        }

        private void ProcessCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                IsRunning = false;
                return;
            }

            switch (command)
            {
                case "help":
                    ShowHelp();
                    break;
                case "inventory":
                    Player.ShowInventory();
                    break;
                case "quit":
                    QuitGame();
                    break;
                default:
                    ExecuteAction(command);
                    break;
            }
        }

        private void ShowHelp()
        {
            Console.WriteLine("A
