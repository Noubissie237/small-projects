using System;
using System.Collections.Generic;

namespace programme_poo
{
    class Program
    {

        class Personne
        {
            private static int nbreDePersonne = 0;

            public string nom { get; init; }
            public int age, numeroDePersonne;
            public string emploi {  get;  set; }


            public Personne()
            {
                nbreDePersonne++;
                this.numeroDePersonne = nbreDePersonne;
            }

            public Personne(string nom, int age, string emploi=null) : this()
            {
                this.nom = nom;
                this.age = age;
                this.emploi = emploi;
            }

            

            public void afficher()
            {
                Console.WriteLine("PERSONNE : " + this.numeroDePersonne) ;
                Console.WriteLine("NOM : "+this.nom); 
                Console.WriteLine("AGE : "+this.age + "ans");
                if (this.emploi != null)
                    Console.WriteLine("EMPLOI : " + this.emploi);
                else
                    Console.WriteLine("Aucun emploi spécifié");
            }

            public static void afficherNombreDePersonne()
            {
                Console.WriteLine("Nombre Total de Personne : " + nbreDePersonne);
            }
        }

        static void Main(string[] args)
        {
            List<Personne> list = new List<Personne> {
                new Personne("Noubissie", 23, "Développeur"),
                new Personne("Kamga", 22 ),
                new Personne("Wilfried", 21, "Formateur"),
                new Personne{ nom = "Paul", emploi = "Developpeur mobile", age = 22 }};


            foreach (var person in list)
            {
                person.afficher();
                Console.WriteLine("------------------------");
            }
            Personne.afficherNombreDePersonne();

            Console.WriteLine(list[0].nom);

        }
    }
}