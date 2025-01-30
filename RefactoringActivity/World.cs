namespace RefactoringActivity;

public class World
{
    // Encapsulate the Locations dictionary, providing read-only access externally
    public IReadOnlyDictionary<string, Location> Locations { get; private set; }

    public World()
    {
        var locations = new Dictionary<string, Location>();
        InitializeWorld(locations);
        Locations = locations;
    }

    private void InitializeWorld(Dictionary<string, Location> locations)
    {
        var start = new Location("Start", "You are at the starting point of your adventure.");
        var forest = new Location("Forest", "You are in a dense, dark forest.");
        var cave = new Location("Cave", "You see a dark, ominous cave.");

        start.AddExit("north", "Forest");
        forest.AddExit("south", "Start");
        forest.AddExit("east", "Cave");
        cave.AddExit("west", "Forest");

        start.AddItem("map");
        forest.AddItem("key");
        forest.AddItem("potion");
        cave.AddItem("sword");

        start.AddPuzzle(new Puzzle("riddle",
            "What's tall as a house, round as a cup, and all the king's horses can't draw it up?", "well"));

        locations.Add("Start", start);
        locations.Add("Forest", forest);
        locations.Add("Cave", cave);
    }

    public bool MovePlayer(Player player, string direction)
    {
        if (Locations.TryGetValue(player.CurrentLocation, out var currentLocation) && 
            currentLocation.Exits.TryGetValue(direction, out var newLocationKey))
        {
            player.MoveToLocation(newLocationKey);
            return true;
        }
        return false;
    }

    public string GetLocationDescription(string locationName)
    {
        if (Locations.TryGetValue(locationName, out var location))
            return location.Description;

        return "Unknown location.";
    }

    public string GetLocationDetails(string locationName)
    {
        if (!Locations.TryGetValue(locationName, out var location))
            return "Unknown location.";

        var details = new StringBuilder(location.Description);
        AppendExits(details, location);
        AppendItems(details, location);
        AppendPuzzles(details, location);

        return details.ToString();
    }

    private void AppendExits(StringBuilder details, Location location)
    {
        if (location.Exits.Any())
        {
            details.Append(" Exits lead: ");
            details.Append(string.Join(", ", location.Exits.Keys));
        }
    }

    private void AppendItems(StringBuilder details, Location location)
    {
        if (location.Items.Any())
        {
            details.AppendLine("\nYou see the following items:");
            foreach (var item in location.Items)
            {
                details.AppendLine($"- {item}");
            }
        }
    }

    private void AppendPuzzles(StringBuilder details, Location location)
    {
        if (location.Puzzles.Any())
        {
            details.AppendLine("\nYou see the following puzzles:");
            foreach (var puzzle in location.Puzzles)
            {
                details.AppendLine($"- {puzzle.Name}");
            }
        }
    }

    public bool TakeItem(Player player, string itemName)
    {
        if (Locations.TryGetValue(player.CurrentLocation, out var location) && 
            location.Items.Remove(itemName))
        {
            player.AddItemToInventory(itemName);
            Console.WriteLine($"You take the {itemName}.");
            return true;
        }

        return false;
    }

    public bool UseItem(Player player, string itemName)
    {
        if (player.Inventory.Contains(itemName))
        {
            Console.WriteLine(itemName == "potion" ? "Ouch! That tasted like poison!" : $"The {itemName} disappears in a puff of smoke!");
            if (itemName == "potion")
            {
                player.UpdateHealth(-10);
                Console.WriteLine($"Your health is now {player.Health}.");
            }
            player.Inventory.Remove(itemName);
            return true;
        }

        return false;
    }

    public bool SolvePuzzle(Player player, string puzzleName)
    {
        if (Locations.TryGetValue(player.CurrentLocation, out var location))
        {
            var puzzle = location.Puzzles.FirstOrDefault(p => p.Name == puzzleName);
            if (puzzle != null && puzzle.Solve())
            {
                location.Puzzles.Remove(puzzle);
                return true;
            }
        }
        return false;
    }
}
