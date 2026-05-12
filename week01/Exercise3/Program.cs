using System;

class Program
{
    static void Main(string[] args)
    {
        string keepPlaying = "yes";

        // This outer loop handles the "Play Again" logic
        do
        {
            // Set up the random magic number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0; // Stretch: Variable to track attempts

            // This inner loop handles the guessing process
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++; // Increment the counter each time a guess is made

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    // Stretch: Inform them of the total guesses
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Stretch: Ask to play again
            Console.Write("Do you want to play again (yes/no)? ");
            keepPlaying = Console.ReadLine().ToLower();

        } while (keepPlaying == "yes");

        Console.WriteLine("Goodbye!");
    }
}