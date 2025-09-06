using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int userNumber;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // 输入循环
        do
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine()!);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }

        } while (userNumber != 0);

        // 计算总和
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // 计算平均值
        double average = (double)sum / numbers.Count;

        // 找最大值
        int max = int.MinValue;
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}
