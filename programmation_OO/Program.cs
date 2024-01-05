using System;
using System.Collections.Generic;

namespace programme_poo
{
    class Program
    {

        class Personne
        {
            private static int nbreDePersonne = 0;

            protected int age, numeroDePersonne;
            protected string emploi;
            protected string nom;

            public Personne(string nom, int age, string emploi = null)
            {
                this.nom = nom;
                this.age = age;
                this.emploi = emploi;
                nbreDePersonne++;
                this.numeroDePersonne = nbreDePersonne;
            }

            protected void AfficherNomAge()
            {
                Console.WriteLine("PERSONNE : " + this.numeroDePersonne);
                Console.WriteLine("NOM : " + this.nom);
                Console.WriteLine("AGE : " + this.age + "ans");
            }

            public virtual void afficher()
            {
                AfficherNomAge();
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

        class Etudiant : Personne
        {
            protected string infoEtudiant;

            public Personne professeurPrincipal { get; init; }

            public Etudiant(string nom, int age, string info) : base(nom, age)
            {
                this.infoEtudiant = info;
            }

            protected virtual void afficherProfesseurPrincipal()
            {
                if (this.professeurPrincipal != null)
                {
                    Console.WriteLine("Le professeur principal est : ");
                    professeurPrincipal.afficher();
                }
            }


            public override void afficher()
            {
                base.AfficherNomAge();
                Console.WriteLine("Etudiant en " + this.infoEtudiant);
                afficherProfesseurPrincipal();
            }
        }

        class Enfant : Etudiant
        {
            Dictionary<string, float> notes;
            string classEcole;
            public Enfant(string nom, int age, string classEcole, Dictionary<string, float> notes) : base(nom, age, null)
            {
                this.classEcole = classEcole;
                this.notes = notes;
            }

            public override void afficher()
            {
                base.AfficherNomAge();
                Console.WriteLine("Enfant en classe de : " + this.classEcole);
                Console.WriteLine("Notes moyenne : ");
                foreach(var note in notes)
                {
                    Console.WriteLine("    "+note.Key +": "+note.Value + " / 10");
                }
                base.afficherProfesseurPrincipal();

            }

        }
        static void Main(string[] args)
        {
            /*List<Personne> list = new List<Personne> {
                new Personne("Noubissie", 23, "Développeur"),
                new Personne("Kamga", 22 ),
                new Personne("Wilfried", 21, "Formateur"),
            };

            foreach (var person in list)
            {
                person.afficher();
                Console.WriteLine("------------------------");
            }*/

            Personne p = new Personne("Dr Jiomekong", 39, "Professeur");

            Etudiant e = new Etudiant("Noubissie", 20, "Ecole d'ingenieur informatique")
            { professeurPrincipal = p
            };
            e.afficher();

            Enfant enf = new Enfant("Sophi", 7, "cp", new Dictionary<string, float> { { "Math", 5f }, { "Geo" , 8.5f} }) { professeurPrincipal = p};
            enf.afficher();

        }
    }
}