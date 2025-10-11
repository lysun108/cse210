public class ProgressGoal : Goal
{
    private int _currentUnits;
    private int _targetUnits;
    private int _unitsPerEvent;
    private int _bonusOnComplete;

    public ProgressGoal(string name, string description, int pointsPerStep,
                        int targetUnits, int unitsPerEvent, int bonusOnComplete,
                        int currentUnits=0)
        : base(name, description, pointsPerStep)
    {
        _targetUnits = targetUnits;
        _unitsPerEvent = unitsPerEvent;
        _bonusOnComplete = bonusOnComplete;
        _currentUnits = currentUnits;
    }

    public override bool IsComplete => _currentUnits >= _targetUnits;

    public override int RecordEvent()
    {
        if (IsComplete) return 0;
        _currentUnits += _unitsPerEvent;
        int score = Points;
        if (_currentUnits >= _targetUnits) score += _bonusOnComplete;
        return score;
    }

    public override string GetStatusText()
        => $"{(IsComplete ? "[X]" : "[ ]")} {Name} — {Description} ({_currentUnits}/{_targetUnits} units, +{Points}/step, bonus { _bonusOnComplete })";

    public override string Serialize()
        => $"Progress|{Name}|{Description}|{Points}|{_targetUnits}|{_unitsPerEvent}|{_bonusOnComplete}|{_currentUnits}";

    public static ProgressGoal FromParts(string[] p)
        => new ProgressGoal(p[1], p[2], int.Parse(p[3]), int.Parse(p[4]),
                            int.Parse(p[5]), int.Parse(p[6]), int.Parse(p[7]));
}
