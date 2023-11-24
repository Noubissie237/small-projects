using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPackages
{
    internal class Outils
    {
        public static int getNotNulPositiveNumber(string question)
        {
            return getNumberBetween(question, 1, int.MaxValue, "ERROR : the number should be positive\n");
        }
        public static int getNumberBetween(string question, int MIN, int MAX, string personalizeErrorMessage=null)
        {
            int number = getNumber(question);

            if (number >= MIN && number <= MAX)
                return number;

            if (personalizeErrorMessage == null)
                Console.WriteLine($"WARNING : the number should be between {MIN} and {MAX}\n");
            else
                Console.WriteLine(personalizeErrorMessage);
            return getNumberBetween(question, MIN, MAX, "ERROR : the number should be positive\n");
        }
        public static int getNumber(string question)
        {
            Console.Write(question);
            
            if (!(int.TryParse(Console.ReadLine(), out int number)))
            {
                Console.WriteLine("ERROR : the number should be an integer\n");
                return getNumber(question);
            }
            return number;
        }

    }
}
