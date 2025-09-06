using System;

class Program
{
    static void Main()
    {
        // Ask the user for grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine()!;
        int gradePercentage = int.Parse(input);

        string letter = "";

        // Determine the letter grade
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Print the letter grade
        Console.WriteLine($"Your grade is: {letter}");

        // Check pass/fail (passing is >= 70)
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Keep working hard, you’ll do better next time!");
        }
    }
}
