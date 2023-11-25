using System;
using System.ComponentModel.DataAnnotations;
using AsciiArt;

namespace Hangaman_game
{
    class Program
    {
        static void printWorld(string world, List<char> letter)
        {
            for (int i = 0; i < world.Length; i++)
            {
                if (letter.Contains(world[i]))
                    Console.Write(world[i]+" ");
                else
                    Console.Write("__ ");
            }
            Console.WriteLine();
        }

        static char getLetter(string message = "Enter a letter : ")
        {
            Console.Write(message);
            if(char.TryParse(Console.ReadLine(), out char letter))
            {
                string tmp = letter.ToString().ToUpper();
                return tmp[0];
            }
            Console.WriteLine("\nERROR : you should be enter just a letter ");
            return getLetter();
        }

        static bool allLettersGuess(string world, List<char>  letters)
        {
            foreach (var letter in letters)
            {
                world = world.Replace(letter.ToString(), "");
            }
            if (world.Length == 0)
                return true;
            return false;
        }
        static void guessWorld(string world)
        {
            List<char> lotOfLetter = new List<char>();
            List<char> lotOfFalseLetter = new List<char>();
            const int NB_LIFE = 6;
            int life = NB_LIFE;

            while(life > 0 && (!allLettersGuess(world, lotOfLetter)))
            {
                Console.WriteLine(Ascii.PENDU[NB_LIFE - life]);
                Console.WriteLine();
                printWorld(world, lotOfLetter);
                char letter = getLetter();
                Console.Clear();
                if (world.Contains(letter))
                {
                    Console.WriteLine("This letter is inside the final world\n");
                    lotOfLetter.Add(letter);
                }
                else
                {
                    if(!lotOfFalseLetter.Contains(letter))
                    {
                        lotOfFalseLetter.Add(letter);

                        life -= 1;
                    }
                        Console.WriteLine("You have " + life + " lifes");
                }
                if(lotOfFalseLetter.Count > 0)
                {
                    Console.Write("This world do not containt the letters : " + string.Join(", ", lotOfFalseLetter));
                    Console.WriteLine();
                }
            }

            Console.WriteLine(Ascii.PENDU[NB_LIFE - life]);
            Console.WriteLine();

            if (life == 0)
            {
                printWorld(world, lotOfLetter);
                Console.WriteLine("\n\nGAME OVER : The correct answer was "+world);
            }
            else
            {
                printWorld(world, lotOfLetter);
                Console.WriteLine("\n\nYOU WIN ");
            }


        }

        static string[] loadTheWorlds(string filename)
        {
            try
            {
                return File.ReadAllLines(filename);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error : " + filename + " not found");
            }
            return null;
        }

        static bool replay()
        {
            char answer = getLetter("Do you want to replay ? (o/n) : ");
            if (answer == 'n' || answer == 'N')
                return false;
            else if (answer == 'o' || answer == 'O')
                return true;
            else
            {
                Console.WriteLine("Error: please choice o or n");
                return replay();
            }
        }
        static void Main(string[] args)
        {
            var worlds = loadTheWorlds("worlds.txt");
            if (worlds == null || worlds.Length == 0)
                Console.WriteLine("Empty file");
            else
            {
                bool play = true;
                while(play)
                {
                    Random rand = new Random();
                    int index = rand.Next(worlds.Length);
                    string world = worlds[index].Trim().ToUpper();
                    guessWorld(world);
                    if (!replay())
                        play = false;
                    Console.Clear();
                }
                Console.WriteLine("Thank you. See you later !");
            }

        }
    }
}