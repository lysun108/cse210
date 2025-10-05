using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private static readonly string[] Prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt inspired this month?",
            "Who are some of your personal heroes?"
        };

        private readonly Random _rng = new Random();

        public ListingActivity() : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        { }

        protected override void Execute()
        {
            string prompt = Prompts[_rng.Next(Prompts.Length)];

            Console.WriteLine();
            Console.WriteLine("List responses to the prompt:");
            Console.WriteLine("> " + prompt);
            Console.WriteLine();

            Console.Write("You will begin in: ");
            Countdown(3);
            Console.WriteLine();

            var items = new List<string>();
            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);

            Console.WriteLine("Start listing (press Enter after each item).");
            Console.WriteLine("When time is up, input will stop.");

            while (DateTime.Now < end)
            {
                if (Console.KeyAvailable)
                {
                    string? line = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        items.Add(line.Trim());
                    }
                }
                else
                {
                    // small wait to avoid busy loop and give user feedback
                    Spinner(1);
                }
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} item(s).");
        }
    }
}
