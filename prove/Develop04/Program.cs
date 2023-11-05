using System;

class Program
{
    static void Main(string[] args)
    {
        string option;
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("Menu Options: \n");
            Console.WriteLine("1 - Start Breathing Activity");
            Console.WriteLine("2 - Start Reflecting Activity");
            Console.WriteLine("3 - Start Listing Activity");
            Console.WriteLine("4 - Quit");
            Console.Write("\nSelect a choice from the menu: ");
            option = Console.ReadLine();
            choice = int.Parse(option);
            

            switch(choice)
            {
                case 1:
                    Console.Clear();
                    BreathingActivity breathingActivity = new BreathingActivity("", "", 0);
                    breathingActivity.RunBreathingActivity();

                break;

                case 2:
                    Console.Clear();
                    ReflectingActivity reflectingActivity = new ReflectingActivity("", "", 0);
                    reflectingActivity.RunReflectingActivity();               

                break;

                case 3:
                    Console.Clear();
                    ListingActivity listingActivity = new ListingActivity("", "", 0);
                    listingActivity.RunListingActivity(); 

                break;

                case 4:
                    Console.WriteLine("\nThanks for using the Mindfulness Program!\n");

                break;
            }
        } while (choice != 4);
    }
}