using System;

class Program
{
    static void Main()
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(userName, squaredNumber);
    }

    // Function 1: 显示欢迎信息
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function 2: 询问用户名
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine()!;
        return name;
    }

    // Function 3: 询问最喜欢的数字
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine()!);
        return number;
    }

    // Function 4: 返回平方数
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function 5: 显示结果
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
