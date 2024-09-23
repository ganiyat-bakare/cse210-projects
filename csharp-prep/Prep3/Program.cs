using System;

class Program
{
    static void Main(string[] args) 
    {     
        int guess = -1;
        int guesses = 0;

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,101);

        while (guess != magicNumber)
        {
            Console.Write("Guess the magic number? ");
            string answer = Console.ReadLine();
            guess = int.Parse(answer);

            guesses++;

            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
       }
       Console.WriteLine($"It took you {guesses} guesses."); 
    }
}
    