namespace RefactoringActivity
{
    public class Puzzle
    {
        // Encapsulated properties with private setters for immutable properties.
        public string Name { get; private set; }
        public string Question { get; private set; }
        public string Answer { get; private set; }

        public Puzzle(string name, string question, string answer)
        {
            Name = name;
            Question = question;
            Answer = answer.ToLower(); // Normalize the answer once upon initialization.
        }

        // Method to present the puzzle to the player.
        public void DisplayPuzzle()
        {
            Console.WriteLine($"Puzzle: {Question}");
            Console.Write("Your answer: ");
        }

        // Method to check if the provided answer is correct.
        public bool Solve(string playerAnswer)
        {
            return string.Equals(playerAnswer.Trim().ToLower(), Answer, StringComparison.OrdinalIgnoreCase);
        }
    }
}
