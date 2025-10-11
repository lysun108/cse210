// Program.cs
// Entry point: builds a polymorphic list and prints summaries.
// Author: Zhili Zhong (Yang Liao)
// Date: 2025-10-11

using System;
using System.Collections.Generic;
using ExerciseTracking;

class Program
{
    static void Main()
    {
        // Create one instance of each activity type.
        // Dates are explicit to avoid locale parsing issues.
        var activities = new List<Activity>
        {
            new Running(new DateTime(2025, 10, 3), 30, 3.0),   // 3.0 miles in 30 minutes
            new Cycling(new DateTime(2025, 10, 4), 40, 15.0),  // 15 mph for 40 minutes
            new Swimming(new DateTime(2025, 10, 5), 25, 40),   // 40 laps (50m each) in 25 minutes
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        // Keep console open if running via double-click in some environments.
        // Comment the next two lines if you don't need a pause.
        Console.WriteLine("\nPress ENTER to exit...");
        Console.ReadLine();
    }
}
