using System.Reflection.Metadata;

public class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;


    public Activity(string name, string description, int duration) // 
    {
        _activityName = name;
        _description = description;
        _duration = duration;
    }

    
    public void DisplayStartingMessage()
    {
        string durationStr;
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}");   
        Console.WriteLine($"\nThis activity will help you {_description}.\n");
        Console.Write($"How long, in seconds, would you like for your session? "); 
        durationStr = Console.ReadLine();
        _duration = int.Parse(durationStr);   
        return;
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!!"); 
        SpinnerPause(4);  
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_activityName}."); 
        SpinnerPause(4);  
        return;
    }

    public void SpinnerPause(int seconds)
    {
        DateTime startTime = DateTime.Now; 
        DateTime endTime = startTime.AddSeconds(seconds); 

        while (DateTime.Now < endTime)
        {
            string spinner = "|/-\\";
            char[] spinnerChars = spinner.ToCharArray();
            foreach (char c in spinnerChars)
            {
                Console.Write(c);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }
        return;
    }

    public void TimerPause(int seconds)
    {
        
        int duration = seconds;
        DateTime startTime = DateTime.Now; 
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(duration);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            duration--;
        }
        return;
    }

    public void GetReady()
    {
        Console.Clear();
        Console.WriteLine("Get Ready...");
        SpinnerPause(5);
        Console.WriteLine();
        return;
    }
}