using System;

public abstract class Goal
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Points { get; protected set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public abstract int RecordEvent();             // 返回本次得分（或扣分）
    public abstract bool IsComplete { get; }
    public abstract string GetStatusText();        // [ ] or [X], 进度等
    public abstract string Serialize();            // 保存到文件
    public static Goal Deserialize(string line)    // 从文件恢复
    {
        // 格式：Type|Name|Description|Points|<type-specific...>
        var parts = line.Split('|');
        string type = parts[0];
        switch (type)
        {
            case "Simple":
                return SimpleGoal.FromParts(parts);
            case "Eternal":
                return EternalGoal.FromParts(parts);
            case "Checklist":
                return ChecklistGoal.FromParts(parts);
            case "Negative":
                return NegativeGoal.FromParts(parts);
            case "Progress":
                return ProgressGoal.FromParts(parts);
            default:
                throw new InvalidOperationException($"Unknown type: {type}");
        }
    }
}
