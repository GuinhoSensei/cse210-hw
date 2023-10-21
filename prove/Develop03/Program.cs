using System;

class Program
{
    static void Main(string[] args)
    {
        string answer = Console.ReadLine();
        Reference reference = new Reference("Mosiah", 17, 2);
        string scriptureText = "Now these sons of Mosiah were with Alma at the time the angel afirst appeared unto him; therefore Alma did rejoice exceedingly to see his brethren; and what added more to his joy, they were still his brethren in the Lord; yea, and they had waxed strong in the knowledge of the truth; for they were men of a sound understanding and they had bsearched the scriptures diligently, that they might know the word of God.";
        Scripture scripture = new(reference, scriptureText);
        Random random = new Random();

        Console.WriteLine(reference.GetReference());
        Console.WriteLine(scripture.Display());
        Console.WriteLine("Press 'enter' to continue or type 'quit' to end:");

        while (Console.ReadKey().Key == ConsoleKey.Enter) {
            int number = random.Next(scripture.GetWord());
            scripture.HideRandomWord(number);
            Console.Clear();
            
            Console.WriteLine(reference.GetReference());
            Console.WriteLine(scripture.Display());
            Console.WriteLine("Press 'enter' to continue or type 'quit' to end:");
            answer = Console.ReadLine();
            if (answer == "quit") {
                Console.WriteLine("We hope to see you again!");
            }
        }
    }
}