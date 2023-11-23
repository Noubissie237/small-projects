using System;
using System.ComponentModel;
using myPackages;

namespace password_generator
{
    class Program
    {
        enum passContaint
        { 
            JustLowerLetter = 1,
            JustUpperLetter = 2,
            MixLetterAndNumber = 3,
            MixLetterAndNumberAndSpecial = 4,

        }
        static void Main(string[] args)
        {
            string smallLetters = "abcdefghijklmnopqrstuvwxyz";
            string bigLetters = smallLetters.ToUpper();
            string numbers = "0123456789";
            string specialCharacters = "#&+-!~@_";
            Random rand = new Random();
            string alphabet = "";
            const int NUMBER_OF_PASSWORD = 10;

            int passLengt = Outils.getNotNulPositiveNumber("Give the length of the password : ");

            passContaint containing = (passContaint) Outils.getNumberBetween("\nYour password should containt:\n" +
                                                     "\n\t1. Only small letters\n" +
                                                     "\t2. Only big letters\n" +
                                                     "\t3. Mix letters and numbers\n" +
                                                     "\t4. Mix letters, numbers, and specials characters\n" +
                                                     "\nYour choice : ",1, 4);
            switch(containing)
            {
                case passContaint.JustLowerLetter:
                    alphabet = smallLetters; break;
                case passContaint.JustUpperLetter:
                    alphabet = bigLetters; break;
                case passContaint.MixLetterAndNumber:
                    alphabet = smallLetters + bigLetters + numbers; break;
                case passContaint.MixLetterAndNumberAndSpecial:
                    alphabet = smallLetters + bigLetters + numbers + specialCharacters; break;
                default:
                    Console.WriteLine("ERROR : unknow value");break;
            }

            int alphabetLength = alphabet.Length;
            
            for(int j=0; j<NUMBER_OF_PASSWORD; j++)
            {
                string password = "";
                for (int i=0; i<passLengt; i++)
                {
                    int index = rand.Next(0, alphabetLength);
                    password += alphabet[index];
                }

                Console.WriteLine("Password : " + password);
            }

        }
    }
}