using System;

class Program
{
    static void Main(string[] args)
    {
        // SCRIPTURE (PUEDES CAMBIARLO AQUÍ)
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference,
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding.");

        // EXCEEDING REQUIREMENTS:
        // - Solo se esconden palabras que todavía no están ocultas.

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            if (scripture.AllWordsHidden())
                break;

            scripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine("Final Scripture (all words hidden):\n");
        Console.WriteLine(scripture.GetDisplayText());
    }
}

