public class ChecklistGoal : Goal
{
    private int _completionCount;
    private int _requiredCount;
    private int _eventPoints;
    private int _bonusPoints;

    public int CompletionCount => _completionCount; // Public property to get completion count
    public int RequiredCount => _requiredCount;     // Public property to get required count
    public int EventPoints => _eventPoints;         // Public property to get event points
    public int BonusPoints => _bonusPoints;         // Public property to get bonus points

    public ChecklistGoal(string name, string description, int requiredCount, int eventPoints, int bonusPoints, int completionCount)
        : base(name, description)
    {
        this._requiredCount = requiredCount;
        this._eventPoints = eventPoints;
        this._bonusPoints = bonusPoints;
        this._completionCount = completionCount;
    }

    public override void RecordEvent()
    {
        _completionCount++;
        AddPoints(_eventPoints);

        if (IsComplete())
        {
            AddPoints(_bonusPoints);
            SetCompleted();
        }
    }

    public override bool IsComplete()
    {
        return _completionCount >= _requiredCount;
    }

    public override string DisplayGoal()
    {
        return $"{base.DisplayGoal()} -- Currently completed: {_completionCount}/{_requiredCount}";
    }
}