class Program
{
    static void Main()
    {
        Console.Clear();
        GoalManager goalManager = new GoalManager();

        int choice;
        do
        {
            int totalPoints = goalManager.CalculateTotalPoints();
            Console.WriteLine($"You have {totalPoints} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine();


            Console.Write("Select a choice from the menu: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddNewGoal(goalManager);
                        break;
                    case 2:
                        Console.WriteLine("\nCurrent Goals:");
                        Console.WriteLine();
                        goalManager.DisplayGoals();
                        break;
                    case 3:
                        Console.Write("What is the filename for the goal file? ");
                        string saveFileName = Console.ReadLine();
                        goalManager.SaveGoals(saveFileName);
                        Console.WriteLine("Goals saved successfully!");
                        break;
                    case 4:
                        Console.Write("What is the filename for the goal file? ");
                        string loadFileName = Console.ReadLine();
                        goalManager.LoadGoals(loadFileName);
                        Console.WriteLine("Goals loaded successfully!");
                        Console.WriteLine();
                        goalManager.DisplayGoals();
                        break;
                    case 5:
                        goalManager.RecordEvent();
                        Console.WriteLine();
                        break;
                    case 6:
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }

                Console.WriteLine(new string('-', 40));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (choice != 6);
    }

    static void AddNewGoal(GoalManager goalManager)
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Goal newGoal = null;

            switch (choice)
            {
                case 1:
                    Console.Write("What is the amount of points associated with this goal?  ");
                    if (int.TryParse(Console.ReadLine(), out int completionPoints))
                    {
                        newGoal = new SimpleGoal(name, description, completionPoints);
                    }
                    break;
                case 2:
                    Console.Write("What is the amount of points associate with this goal? ");
                    if (int.TryParse(Console.ReadLine(), out int eventPoints))
                    {
                        newGoal = new EternalGoal(name, description, eventPoints);
                    }
                    break;
                case 3:
                    Console.Write("What is the amount of points associated with this goal? ");
                    if (int.TryParse(Console.ReadLine(), out int checklistEventPoints))
                    {
                        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                        if (int.TryParse(Console.ReadLine(), out int requiredCount))
                        {
                            Console.Write("What is the bonus for accomplishing it that many times? ");
                            if (int.TryParse(Console.ReadLine(), out int bonusPoints))
                            {
                                newGoal = new ChecklistGoal(name, description, requiredCount, checklistEventPoints, bonusPoints, 0);
                            }
                        }
                    }
                    break;
            }

            if (newGoal != null)
            {
                goalManager.AddGoal(newGoal);
            }
        }
    }
}