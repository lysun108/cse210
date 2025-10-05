using System;
using System.Threading;

namespace Mindfulness
{
    public abstract class Activity
    {
        private readonly string _name;
        private readonly string _description;
        private int _durationSeconds;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void Run()
        {
            ShowStart();
            Execute();           // implemented by subclasses
            ShowEnd();
        }

        protected abstract void Execute();

        private void ShowStart()
        {
            Console.Clear();
            Console.WriteLine($"--- {_name} ---");
            Console.WriteLine(_description);
            Console.Write("\nEnter duration in seconds: ");
            while (!int.TryParse(Console.ReadLine(), out _durationSeconds) || _durationSeconds <= 0)
            {
                Console.Write("Please enter a positive integer: ");
            }

            Console.WriteLine("\nGet ready...");
            Spinner(3);
        }

        private void ShowEnd()
        {
            Console.WriteLine("\nWell done!");
            Spinner(2);
            Console.WriteLine($"You have completed the {_name} activity for {_durationSeconds} seconds.");
            Spinner(2);
        }

        // helpers available to subclasses
        protected int DurationSeconds => _durationSeconds;

        protected void Spinner(int seconds)
        {
            char[] frames = new[] { '|', '/', '-', '\\' };
            DateTime end = DateTime.Now.AddSeconds(seconds);
            int idx = 0;
            while (DateTime.Now < end)
            {
                Console.Write(frames[idx % frames.Length]);
                Thread.Sleep(150);
                Console.Write("\b \b");
                idx++;
            }
        }

        protected void Countdown(int seconds, string prefix = "")
        {
            for (int i = seconds; i > 0; i--)
            {
                string s = prefix + i.ToString();
                Console.Write(s);
                Thread.Sleep(1000);
                Console.Write(new string('\b', s.Length));
                Console.Write(new string(' ', s.Length));
                Console.Write(new string('\b', s.Length));
            }
        }
    }
}
