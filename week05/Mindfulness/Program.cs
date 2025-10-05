// Completed: 2025-10-04
// Author: Zhili Zhong (Yang Liao)
// Assignment: CSE 210 - W05 Mindfulness Program (Inheritance Development Project)

using System;

namespace Mindfulness
{
    public class Program
    {
        /*
          EXCEEDS REQUIREMENTS (optional ideas):
          - Log session results to a file (e.g., logs.txt).
          - Add a 4th activity (e.g., Gratitude).
          - Ensure questions in Reflection don't repeat until used once.
        */

        public static void Main()
        {
            Console.Title = "Mindfulness Program - CSE 210";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("0. Quit");
                Console.Write("\nChoose an option: ");

                string? choice = Console.ReadLine();
                Activity? activity = choice switch
                {
                    "1" => new BreathingActivity(),
                    "2" => new ReflectionActivity(),
                    "3" => new ListingActivity(),
                    "0" => null,
                    _   => null
                };

                if (choice == "0") break;
                if (activity == null)
                {
                    Console.WriteLine("Invalid choice. Press Enter to continue...");
                    Console.ReadLine();
                    continue;
                }

                activity.Run();
                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }
    }
}
