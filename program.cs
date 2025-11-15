using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, text);

        const int hideCountPerEnter = 3; 

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program finished.");
                break;
            }

            Console.WriteLine("\nPress ENTER to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input.Trim().ToLower() == "quit")
                break;
            scripture.HideRandomWords(hideCountPerEnter);
        }
    }
}
