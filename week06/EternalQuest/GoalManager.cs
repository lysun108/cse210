using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    public List<Goal> Goals { get; } = new List<Goal>();
    public int TotalScore { get; private set; } = 0;

    // 创意：简单等级系统
    public int Level => 1 + TotalScore / 500; // 每 500 分升一级

    public void AddGoal(Goal g) => Goals.Add(g);

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (Goals.Count == 0) { Console.WriteLine("  (none)"); return; }
        for (int i = 0; i < Goals.Count; i++)
            Console.WriteLine($"{i+1}. {Goals[i].GetStatusText()}");
        Console.WriteLine($"\nTotal Score: {TotalScore}  | Level: {Level}");
    }

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= Goals.Count) { Console.WriteLine("Invalid index."); return; }
        int delta = Goals[index].RecordEvent();
        TotalScore += delta;
        Console.WriteLine(delta >= 0
            ? $"Nice! You gained {delta} points."
            : $"Ouch! You lost {-delta} points.");
        Console.WriteLine($"Score: {TotalScore}  | Level: {Level}");
    }

    public void Save(string filename)
    {
        using var sw = new StreamWriter(filename);
        sw.WriteLine(TotalScore);
        foreach (var g in Goals)
            sw.WriteLine(g.Serialize());
        Console.WriteLine($"Saved to {filename}");
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename)) { Console.WriteLine("File not found."); return; }
        Goals.Clear();
        var lines = File.ReadAllLines(filename);
        TotalScore = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
            Goals.Add(Goal.Deserialize(lines[i]));
        Console.WriteLine($"Loaded from {filename}");
    }
}
