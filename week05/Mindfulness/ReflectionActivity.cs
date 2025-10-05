using System;

namespace Mindfulness
{
    public class ReflectionActivity : Activity
    {
        private static readonly string[] Prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private static readonly string[] Questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private readonly Random _rng = new Random();

        public ReflectionActivity() : base(
            "Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience.")
        { }

        protected override void Execute()
        {
            string prompt = Prompts[_rng.Next(Prompts.Length)];
            Console.WriteLine($"\nConsider the following prompt:\n> {prompt}");
            Console.WriteLine("\nWhen you are ready, press Enter to reflect on the questions...");
            Console.ReadLine();

            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);
            while (DateTime.Now < end)
            {
                string q = Questions[_rng.Next(Questions.Length)];
                Console.Write($"\n{q} ");
                Spinner(6);
            }
            Console.WriteLine();
        }
    }
}
