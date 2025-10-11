public class NegativeGoal : Goal
{
    private int _times;

    public NegativeGoal(string name, string description, int penaltyPoints, int times=0)
        : base(name, description, -System.Math.Abs(penaltyPoints)) // 存为负分
    {
        _times = times;
    }

    public override bool IsComplete => false;

    public override int RecordEvent()
    {
        _times++;
        return Points; // 负数 => 扣分
    }

    public override string GetStatusText()
        => $"[−] {Name} — {Description} ({_times} times, {Points} each)";

    public override string Serialize()
        => $"Negative|{Name}|{Description}|{Points}|{_times}";

    public static NegativeGoal FromParts(string[] p)
        => new NegativeGoal(p[1], p[2], int.Parse(p[3]), int.Parse(p[4]));
}
