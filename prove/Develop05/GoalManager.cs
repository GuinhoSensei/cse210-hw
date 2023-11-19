using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;

    public GoalManager()
    {
        _goals = new List<Goal>();
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.DisplayGoal());
        }
    }

public void SaveGoals(string fileName)
{
    using (StreamWriter writer = new StreamWriter(fileName, true))
    {
        foreach (Goal goal in _goals)
        {
            writer.Write($"{goal.GetType().Name},{goal.Name},{goal.Description},{goal.Points},{goal.Completed}");

            // Save additional information for ChecklistGoal
            if (goal is ChecklistGoal checklistGoal)
            {
                writer.Write($",{checklistGoal.RequiredCount},{checklistGoal.EventPoints},{checklistGoal.BonusPoints},{checklistGoal.CompletionCount}");
            }
            else if (goal is SimpleGoal simpleGoal)
            {
                writer.Write($",{simpleGoal.CompletionPoints}");
            }
            else if (goal is EternalGoal eternalGoal)
            {
                writer.Write($",{eternalGoal.EventPoints}");
            }

            writer.WriteLine();
        }
    }
}
public void LoadGoals(string fileName)
{
    try
    {   
        _goals.Clear();
        
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 5) // Ensure the minimum number of parts for a valid goal
                {
                    string goalType = parts[0];
                    string goalName = parts[1];
                    string goalDescription = parts[2];
                    int goalPoints = int.Parse(parts[3]);
                    bool goalCompleted = bool.Parse(parts[4]);

                    switch (goalType)
                    {
                        case nameof(SimpleGoal):
                            if (parts.Length >= 6)
                            {
                                int completionPoints = int.Parse(parts[5]);
                                _goals.Add(new SimpleGoal(goalName, goalDescription, completionPoints));
                            }
                            break;
                        case nameof(EternalGoal):
                            if (parts.Length >= 6)
                            {
                                int eventPoints = int.Parse(parts[5]);
                                _goals.Add(new EternalGoal(goalName, goalDescription, eventPoints));
                            }
                            break;
                        case nameof(ChecklistGoal):
                            if (parts.Length >= 9)
                            {
                                int requiredCount = int.Parse(parts[5]);
                                int eventPoints = int.Parse(parts[6]);
                                int bonusPoints = int.Parse(parts[7]);
                                int completionCount = int.Parse(parts[8]);

                                _goals.Add(new ChecklistGoal(goalName, goalDescription, requiredCount, eventPoints, bonusPoints, completionCount));
                            }
                            break;
                    }

                    Goal loadedGoal = _goals[_goals.Count - 1];
                    loadedGoal.AddPoints(goalPoints);

                    if (goalCompleted)
                    {
                        loadedGoal.SetCompleted();
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading goals: {ex.Message}");
    }
}

public void RecordEvent()
{
    Console.WriteLine("Which goal did you accomplish? ");
    
    for (int i = 0; i < _goals.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {_goals[i].DisplayGoal()}");
    }

    Console.Write("Enter the number of the goal: ");

    if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex >= 1 && goalIndex <= _goals.Count)
    {
        Goal goal = _goals[goalIndex - 1];
        int pointsAdded = goal.RecordEventAndGetPoints();
        Console.WriteLine();
        Console.WriteLine($"Congratulations! You have earned {pointsAdded} points for {goal.Name}!");
    }
    else
    {
        Console.WriteLine("Invalid goal number. Please enter a valid number.");
    }

    // Display total points
    int totalPoints = CalculateTotalPoints();
    Console.WriteLine($"You now have {totalPoints} points.");
}

    public int CalculateTotalPoints()
    {
        return _goals.Sum(goal => goal.Points);
    }
}