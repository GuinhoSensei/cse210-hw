public class SimpleGoal : Goal
{
    private int _completionPoints;

    public int CompletionPoints => _completionPoints; 

    public SimpleGoal(string name, string description, int completionPoints) : base(name, description)
    {
        this._completionPoints = completionPoints;
    }
    public override string DisplayGoal()
    {
        return $"{base.DisplayGoal()}";
    }
    public override void RecordEvent()
    {
        AddPoints(_completionPoints);
        SetCompleted();
    }

    public override bool IsComplete()
    {
        return Completed;
    }
}