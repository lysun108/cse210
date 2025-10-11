// CSE 210 W06 Eternal Quest - Polymorphism Project
// Author: Yang Liao
// Creativity beyond requirements:
// 1) Level system (Level = 1 + totalScore/500) with live display
// 2) NegativeGoal (bad habits deduct points)
// 3) ProgressGoal (large goals award partial progress and a completion bonus)

using System;

class Program
{
    static void Main()
    {
        var mgr = new GoalManager();
        while (true)
        {
            Console.WriteLine("\n=== Eternal Quest ===");
            Console.WriteLine("1) Create New Goal");
            Console.WriteLine("2) List Goals");
            Console.WriteLine("3) Record Event");
            Console.WriteLine("4) Save");
            Console.WriteLine("5) Load");
            Console.WriteLine("6) Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine() ?? "";
            Console.WriteLine();

            switch (input)
            {
                case "1": CreateGoalMenu(mgr); break;
                case "2": mgr.ListGoals(); break;
                case "3": RecordEventMenu(mgr); break;
                case "4": Console.Write("Filename: "); mgr.Save(Console.ReadLine() ?? "goals.txt"); break;
                case "5": Console.Write("Filename: "); mgr.Load(Console.ReadLine() ?? "goals.txt"); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void CreateGoalMenu(GoalManager mgr)
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine(" 1) Simple (one-and-done)");
        Console.WriteLine(" 2) Eternal (never complete)");
        Console.WriteLine(" 3) Checklist (N times + bonus)");
        Console.WriteLine(" 4) Negative (bad habit deducts points)  *creative*");
        Console.WriteLine(" 5) Progress (large goal with partial steps)  *creative*");
        Console.Write("Type: ");
        string t = Console.ReadLine() ?? "";

        Console.Write("Name: "); string name = Console.ReadLine() ?? "";
        Console.Write("Description: "); string desc = Console.ReadLine() ?? "";

        switch (t)
        {
            case "1":
                int sp = AskInt("Points for completing: ");
                mgr.AddGoal(new SimpleGoal(name, desc, sp));
                break;
            case "2":
                int ep = AskInt("Points per record: ");
                mgr.AddGoal(new EternalGoal(name, desc, ep));
                break;
            case "3":
                int cp = AskInt("Points per record: ");
                int target = AskInt("Times needed: ");
                int bonus = AskInt("Bonus on completion: ");
                mgr.AddGoal(new ChecklistGoal(name, desc, cp, target, bonus));
                break;
            case "4":
                int penalty = AskInt("Penalty (positive number, will deduct): ");
                mgr.AddGoal(new NegativeGoal(name, desc, penalty));
                break;
            case "5":
                int stepPts = AskInt("Points per step: ");
                int units = AskInt("Target units (e.g., 100 km): ");
                int perEvent = AskInt("Units per event (e.g., +5 km per run): ");
                int doneBonus = AskInt("Bonus on completion: ");
                mgr.AddGoal(new ProgressGoal(name, desc, stepPts, units, perEvent, doneBonus));
                break;
            default:
                Console.WriteLine("Unknown type.");
                break;
        }
        Console.WriteLine("Goal created.");
    }

    static void RecordEventMenu(GoalManager mgr)
    {
        if (mgr.Goals.Count == 0) { Console.WriteLine("No goals yet."); return; }
        mgr.ListGoals();
        int idx = AskInt("Which goal # did you accomplish? ") - 1;
        mgr.RecordEvent(idx);
    }

    static int AskInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int v)) return v;
            Console.WriteLine("Please enter a valid integer.");
        }
    }
}

