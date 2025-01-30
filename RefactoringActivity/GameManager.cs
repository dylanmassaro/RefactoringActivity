namespace RefactoringActivity;

public class GameManager
{
    private bool _isRunning;
    private Player _player;
    private World _world;

    public void RunGame()
    {
        _isRunning = true;
        _player = new Player(100);
        _world = new World();

        Console.WriteLine("Welcome to the Text Adventure Game!");
        Console.WriteLine("Type 'help' for a list of commands.");

        while (_isRunning)
        {
            Console.WriteLine();
            Console.WriteLine(_world.GetLocationDetails(_player.CurrentLocation));
            Console.Write("> ");
            string? input = Console.ReadLine()?.ToLower();

            if (string.IsNullOrEmpty(input)) return;

            if (input == "quit")
            {
                _isRunning = false;
                Console.WriteLine("Thanks for playing!");
                return;
            }

            ProcessCommand(input);
        }
    }

    private void ProcessCommand(string input)
    {
        string[] parts = input.Split(' ');
        string command = parts[0];
        string? argument = parts.Length > 1 ? parts[1] : null;

        switch (command)
        {
            case "help":
                ShowHelp();
                break;
            case "go":
                MovePlayer(argument);
                break;
            case "take":
                TakeItem(argument);
                break;
            case "use":
                UseItem(argument);
                break;
            case "inventory":
                _player.ShowInventory();
                break;
            case "solve":
                SolvePuzzle(argument);
                break;
            default:
                Console.WriteLine("Unknown command. Try 'help'.");
                break;
        }
    }

    private void ShowHelp()
    {
        Console.WriteLine("Available commands:");
        Console.WriteLine("- go [direction]: Move in a direction (north, south, east, west).\n- take [item]: Take an item from your current location.\n- use [item]: Use an item in your inventory.\n- solve [puzzle]: Solve a puzzle in your current location.\n- inventory: View the items in your inventory.\n- quit: Exit the game.");
    }

    private void MovePlayer(string direction)
    {
        if (string.IsNullOrEmpty(direction))
        {
            Console.WriteLine("Move where? (north, south, east, west)");
            return;
        }

        if (_world.MovePlayer(_player, direction))
        {
            Console.WriteLine($"You move {direction}.");
        }
        else
        {
            Console.WriteLine("You can't go that way.");
        }
    }

    private void TakeItem(string itemName)
    {
        if (string.IsNullOrEmpty(itemName))
        {
            Console.WriteLine("Take what?");
            return;
        }

        if (!_world.TakeItem(_player, itemName))
        {
            Console.WriteLine($"There is no {itemName} here.");
        }
    }

    private void UseItem(string itemName)
    {
        if (string.IsNullOrEmpty(itemName))
        {
            Console.WriteLine("Use what?");
            return;
        }

        if (!_world.UseItem(_player, itemName))
        {
            Console.WriteLine($"You can't use the {itemName} here.");
        }
    }

    private void SolvePuzzle(string puzzleName)
    {
        if (string.IsNullOrEmpty(puzzleName))
        {
            Console.WriteLine("Solve what?");
            return;
        }

        if (_world.SolvePuzzle(_player, puzzleName))
        {
            Console.WriteLine($"You solved the {puzzleName} puzzle!");
        }
        else
        {
            Console.WriteLine($"That's not the right solution for the {puzzleName} puzzle.");
        }
    }
}
