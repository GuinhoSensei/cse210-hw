using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your grade percentage");
        string GradePercet = Console.ReadLine();
        int grade = int.Parse(GradePercet);
        string letter = "";

        if (grade >= 90){
            letter = "A";
        }
        else if (grade >= 80){
            letter = "B";
        }
        else if (grade >= 70){
            letter = "C";
        }
        else if (grade >= 60){
            letter = "D";
        }
        else if (grade < 60){
            letter = "F";
        }

        Console.WriteLine($"Your letter grade is {letter}");
        
    }
}