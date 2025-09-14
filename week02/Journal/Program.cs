using System;

class Program
{
    /*
     * CSE 210 – W02 Journal Program
     * Core requirements implemented: write/display/save/load entries; menu; 5+ prompts; classes per file.
     *
     * Extra credit (creativity): Added "Mood" field for each journal entry (simple bonus feature).
     * - Users can record how they felt along with their response.
     * - Backward-compatible loader (files saved without mood will default to "Neutral").
     */

    static void Main()
    {
        var journal = new Journal();
        var prompts = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    var prompt = prompts.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    var response = Console.ReadLine() ?? string.Empty;
                    Console.Write("Your mood today (e.g., Happy/OK/Tired): ");
                    var mood = Console.ReadLine() ?? "Neutral";
                    var dateText = DateTime.Now.ToShortDateString();
                    journal.AddEntry(new Entry(dateText, prompt, response, mood));
                    Console.WriteLine("Entry added.\n");
                    break;

                case "2":
                    journal.Display();
                    break;

                case "3":
                    Console.Write("Filename to save (e.g., journal.txt): ");
                    var saveName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(saveName))
                    {
                        try { journal.SaveToFile(saveName!); }
                        catch (Exception ex) { Console.WriteLine($"Save failed: {ex.Message}\n"); }
                    }
                    else Console.WriteLine("Invalid filename.\n");
                    break;

                case "4":
                    Console.Write("Filename to load (e.g., journal.txt): ");
                    var loadName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadName))
                    {
                        try { journal.LoadFromFile(loadName!); }
                        catch (Exception ex) { Console.WriteLine($"Load failed: {ex.Message}\n"); }
                    }
                    else Console.WriteLine("Invalid filename.\n");
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Please enter a number 1-5.\n");
                    break;
            }
        }
    }
}
