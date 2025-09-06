using System;

class Program
{
    static void Main()
    {
        // Create random number generator
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // 1 到 100 之间

        int guess = -1; // 初始化
        int guessCount = 0; // 用于扩展挑战（统计次数）

        Console.WriteLine("Welcome to Guess My Number!");

        // 循环直到猜对
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine()!);
            guessCount++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {guessCount} guesses.");
            }
        }
    }
}
