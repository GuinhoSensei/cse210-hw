using System.ComponentModel;
using System.Reflection.Metadata;

public class BreathingActivity : Activity
{
   
    public BreathingActivity(string activityName, string description, int duration) : base(activityName, description, duration)
    
    {
        _activityName = "Breathing Activity";
        _description = "relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing";
        _duration = 0;
    }

    public void RunBreathingActivity()
    {
        Console.Clear();
        DisplayStartingMessage();
        GetReady();
        
        DateTime startTime = DateTime.Now; 
        DateTime endTime = startTime.AddSeconds(_duration); 

        while (DateTime.Now < endTime)
        {
            Breath();
        }

        DisplayEndingMessage();
        return;
    }

    public void Breath()
    {
        Console.Write("Breathe in...");
        TimerPause(4);
        Console.Write("\nNow breathe out...");
        TimerPause(7);
        Console.WriteLine("\n");
        return;
    }

}