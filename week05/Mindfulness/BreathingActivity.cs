using System;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        protected override void Execute()
        {
            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);
            while (DateTime.Now < end)
            {
                Console.Write("Breathe in... ");
                Countdown(4);
                Console.WriteLine();

                if (DateTime.Now >= end) break;

                Console.Write("Breathe out... ");
                Countdown(6);
                Console.WriteLine();
            }
        }
    }
}
