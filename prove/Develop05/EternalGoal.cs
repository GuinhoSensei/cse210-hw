public class EternalGoal : Goal
{
    private int _eventPoints;
    public int EventPoints => _eventPoints; 

    public EternalGoal(string name, string description, int eventPoints) : base(name, description)
    {
        this._eventPoints = eventPoints;
    }

    public override void RecordEvent()
    {
        AddPoints(_eventPoints);
    }

    public override bool IsComplete()
    {
        return false;
    }
    public override string DisplayGoal()
    {
        return $"{base.DisplayGoal()}";
    }
}