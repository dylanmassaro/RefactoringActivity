namespace RefactoringActivity;
public class Player
{
    public int Health { get; set; }
    public string CurrentLocation { get; set; }
    public List<string> Inventory { get; private set; }

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