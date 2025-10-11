public class EternalGoal : Goal
{
    private int _times; // 记录次数（显示用）

    public EternalGoal(string name, string description, int points, int times=0)
        : base(name, description, points)
    {
        _times = times;
    }

    public override bool IsComplete => false;

    public override int RecordEvent()
    {
        _times++;
        return Points;
    }

    public override string GetStatusText()
        => $"[∞] {Name} — {Description} (+{Points}/time, { _times } times)";

    public override string Serialize()
        => $"Eternal|{Name}|{Description}|{Points}|{_times}";

    public static EternalGoal FromParts(string[] p)
        => new EternalGoal(p[1], p[2], int.Parse(p[3]), int.Parse(p[4]));
}
