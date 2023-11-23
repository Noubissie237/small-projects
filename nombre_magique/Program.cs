using System;

namespace nombre_magique
{
    class Program
    {
        static int GetNumber(int MIN, int MAX)
        {
            int number = MIN - 1;

            while (number < MIN || number > MAX)
            {
                Console.Write($"Enter a number between {MIN} and {MAX} : ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (!((number >= MIN) && (number <= MAX)))
                    {
                        Console.WriteLine($"Error, the number must be between {MIN} and {MAX}");
                    }
                }
                catch
                {
                    Console.WriteLine("Error, the number must be an integer");
                }

            }
            return number;
        }

        static bool IsNumber(int number, int MAGIC_NUMBER)
        {
            if(number == MAGIC_NUMBER)
            {
                Console.WriteLine("CONGRATULATIONS, YOU FOUND THE MAGIC NUMBER !!!!!!!");
                return true;
            }
            else
            {
                if (number < MAGIC_NUMBER)
                {
                    Console.WriteLine("The magic number is bigger");
                }
                else
                {
                    Console.WriteLine("The magic number is smaller");
                }
                return false;
            }
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            int MIN_NUMBER = rand.Next(1,11);
            int MAX_NUMBER = rand.Next((MIN_NUMBER+5), 21);
            int MAGIC_NUMBER = rand.Next(MIN_NUMBER, (MAX_NUMBER+1));
            int life = ((MIN_NUMBER + MAX_NUMBER)/2) - MIN_NUMBER;
        
            Console.WriteLine($"--------------You have {life} lifes--------------");
            int number = GetNumber(MIN_NUMBER, MAX_NUMBER);
            life -= 1;
            while((!IsNumber(number, MAGIC_NUMBER)) && (life >= 1))
            {
                Console.WriteLine();
                Console.WriteLine($"--------------You have {life} lifes left--------------");
                number = GetNumber(MIN_NUMBER, MAX_NUMBER);
                life -= 1;
            }

            if (MAGIC_NUMBER != number)
                Console.WriteLine("\n\tGAME OVER\n");
        }
    }
}