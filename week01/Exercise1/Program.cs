using System;

class Program
{
    static void Main()
    {
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine()!; // ! 保证不会是 null

        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine()!;

        Console.WriteLine();
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
