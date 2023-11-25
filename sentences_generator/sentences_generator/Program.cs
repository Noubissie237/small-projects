using System;
using myPackages;

namespace sentences_generator
{
    class Program
    {

        static string getRandomElement(string[] table)
        {
            Random rand = new Random();
            int index = rand.Next(table.Length);

            return table[index];
        }
        static void Main(string[] args)
        {
            int nb_double_check = 0;
            int NB_SENTENCE = Outils.getNotNulPositiveNumber("How many sentences do you want ? : ");
            string[] subjects = new string[] 
            {
                "Un lapin", "Une grand-mère", "Un chat", "Un bonhomme de neige", "Une limace", "Une fee", "Un magicien", "Une tortue"
            };
            string[] verbs = new string[]
            {
                "mange", "écrase", "détruit", "observer", "attrape", "regarde", "avale", "néttoie", "se bat avec", "s'accroche à"
            };
            string[] complements = new string[]
            {
                "un arbre", "un livre", "la lune", "le soleil", "un serpent", "une carte", "une girafe", "le ciel", "une piscine", "un gateau",
                "une souris", "un crapaud"
            };
            List<string> Total_Sentences = new List<string>();

            while(Total_Sentences.Count < NB_SENTENCE) 
            {
                string subject = getRandomElement(subjects);
                string verb = getRandomElement(verbs);
                string complement = getRandomElement(complements);

                string sentence = subject + " " + verb + " " + complement;

                if (!(Total_Sentences.Contains(sentence)))
                {
                sentence = sentence.Replace("à le", "au");
                sentence = sentence.Replace("à la", "au");
                Total_Sentences.Add(sentence);
                }
                else
                    nb_double_check++;
            }

            Console.WriteLine("\n#####################################---START---###########################################\n");
            foreach (string elt in Total_Sentences)
                Console.WriteLine(elt);

            Console.WriteLine("\n#####################################---END---###########################################\n");
            Console.WriteLine("\n" + Total_Sentences.Count() + " uniques sentences");
            Console.WriteLine("\n" + nb_double_check + " double-check bypassed");
        }
    }
}