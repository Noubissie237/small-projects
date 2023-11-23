using System;

namespace jeu_de_maths
{
    class Program
    {
        enum e_operator
        {
            SUM = 1,
            SUBTRACTION = 2,
            MULTIPLICATION = 3,
        }
        static bool askQuestion(int MIN, int MAX)
        {
            Random rand = new Random();
            int a = rand.Next(MIN, MAX+1);
            int b = rand.Next(MIN, MAX+1);
            int value;
            e_operator dice = (e_operator)rand.Next(1, 4);
            int waitingResponse;

            switch(dice)
            {
                case e_operator.SUM:
                    Console.Write($"{a} + {b} = ");
                    waitingResponse = a + b;
                    break;

                case e_operator.MULTIPLICATION:
                    Console.Write($"{a} x {b} = ");
                    waitingResponse = a * b;
                    break;

                case e_operator.SUBTRACTION:
                    Console.Write($"{a} - {b} = ");
                    waitingResponse = a - b;
                    break;

                default:
                    Console.WriteLine("Error : Unknow operator");
                    return false;
            }

            while (true)
            {
                try
                {
                    value = int.Parse(Console.ReadLine());
                    if (value == waitingResponse)
                        return true;
                    return false;
                }
                catch
                {
                    Console.WriteLine("The number should be an integer");
                }
            }

        }
        static void Main(string[] args)
        {
            int MIN = 1;
            int MAX = 10;
            int marks = 0;
            const int NB_QUESTION = 5;
            const int avg = NB_QUESTION / 2;


            for(int i = 0; i < NB_QUESTION; i++)
            {
                Console.WriteLine($"Question n°{i + 1}/{NB_QUESTION}");
                bool answers= askQuestion(MIN, MAX);

                if (answers)
                {
                    Console.WriteLine("Correct anwer");
                    marks += 1;
                }
                else
                    Console.WriteLine("Wrong answer");
                Console.WriteLine();
            }

            Console.WriteLine($"Total scores : {marks} / {NB_QUESTION}");

            if (marks == NB_QUESTION) Console.WriteLine("Perfect");
            else if (marks == 0) Console.WriteLine("Please review your mathematic lessons");
            else if (marks <= avg) Console.WriteLine("Can do better");
            else Console.WriteLine("Not bad");

        }
    }
}