namespace RefactoringActivity;
public class Location
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Dictionary<string, string> Exits { get; private set; }
    public List<string> Items { get; private set; }
    public List<Puzzle> Puzzles { get; private set; }

    public Location(string name, string description)
    {
        Name = name;
        Description = description;
        Exits = new Dictionary<string, string>();
        Items = new List<string>();
        Puzzles = new List<Puzzle>();
    }
}