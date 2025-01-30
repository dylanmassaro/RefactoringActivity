namespace RefactoringActivity;

public class Player
{
    public int Health;
    public string CurrentLocation;
    public List<string> Inventory;

    public Player(int health)
    {
        Health = health;
        CurrentLocation = "Start";
        Inventory = new List<string>();
    }

    public void ShowInventory()
    {
        if (Inventory.Count == 0)
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
}