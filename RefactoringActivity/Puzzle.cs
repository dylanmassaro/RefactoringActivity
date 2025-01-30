namespace RefactoringActivity;

public class Puzzle
{
    public string Name;
    public string Question;
    public string Answer;
    
    public Puzzle(string name, string question, string answer)
    {
        Name = name;
        Question = question;
        Answer = answer;
    }

    public bool Solve()
    {
        Console.WriteLine($"Puzzle: {Question}");
        Console.Write("Your answer: ");
        string playerAnswer = Console.ReadLine()?.ToLower();
        return playerAnswer == Answer.ToLower();
    }
}