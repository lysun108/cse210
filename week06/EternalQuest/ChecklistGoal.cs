public class ChecklistGoal : Goal
{
    private int _current;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int current=0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _current = current;
    }

    public override bool IsComplete => _current >= _target;

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            _current++;
            if (_current == _target)
                return Points + _bonus;
            return Points;
        }
        return 0;
    }

    public override string GetStatusText()
        => $"{(IsComplete ? "[X]" : "[ ]")} {Name} — {Description} ({_current}/{_target}, +{Points}, bonus { _bonus })";

    public override string Serialize()
        => $"Checklist|{Name}|{Description}|{Points}|{_target}|{_bonus}|{_current}";

    public static ChecklistGoal FromParts(string[] p)
        => new ChecklistGoal(p[1], p[2], int.Parse(p[3]), int.Parse(p[4]), int.Parse(p[5]), int.Parse(p[6]));
}
