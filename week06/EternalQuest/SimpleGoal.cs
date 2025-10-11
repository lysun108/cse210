public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points, bool completed=false)
        : base(name, description, points)
    {
        _completed = completed;
    }

    public override bool IsComplete => _completed;

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return Points;
        }
        return 0; // 已完成不再加分
    }

    public override string GetStatusText()
        => $"{(IsComplete ? "[X]" : "[ ]")} {Name} — {Description} (+{Points})";

    public override string Serialize()
        => $"Simple|{Name}|{Description}|{Points}|{_completed}";

    public static SimpleGoal FromParts(string[] p)
        => new SimpleGoal(p[1], p[2], int.Parse(p[3]), bool.Parse(p[4]));
}
