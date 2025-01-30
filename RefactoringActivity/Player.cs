namespace RefactoringActivity
{
    public class Player
    {
        // Properties with private setters to encapsulate the data.
        public int Health { get; private set; }
        public string CurrentLocation { get; private set; }
        public IReadOnlyList<string> Inventory { get; private set; } // Readonly to external access

        public Player(int health)
        {
            Health = health;
            CurrentLocation = "Start";
            Inventory = new List<string>();
        }

        public void ShowInventory()
        {
            if (!Inventory.Any()) // Using LINQ for checking if inventory is empty
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                Console.WriteLine("You are carrying:");
                foreach (string item in Inventory)
                {
                    Console.WriteLine($"- {item}");
                }
            }
        }

        // Method to add items to the inventory
        public void AddItemToInventory(string item)
        {
            ((List<string>)Inventory).Add(item);
        }

        // Method to update player's location
        public void MoveToLocation(string newLocation)
        {
            CurrentLocation = newLocation;
        }

        // Method to update health
        public void UpdateHealth(int change)
        {
            Health += change;
        }
    }
}
