using BibliRestaurant;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceConsole
{
    public static class Lire
    {
        public static bool UnBooleen(string message, string messageErreur, string vrai, string faux)
        {
            Console.WriteLine($"{message} ({vrai}/{faux}):");
            string Resultat = Console.ReadLine();

            while (Resultat != vrai && Resultat != faux)
            {
                Console.WriteLine($"{messageErreur} ({vrai}/{faux}):");
                Resultat = Console.ReadLine();
            }

            return Resultat == vrai;
        }
        public static byte UnByte(string message, byte min = byte.MinValue, byte max = byte.MaxValue, bool separation = false)
        {
            byte Resultat = byte.MinValue;

            Console.WriteLine(message);
            while (!byte.TryParse(Console.ReadLine(), out Resultat) || Resultat < min || Resultat > max)
            {
                Console.WriteLine($"Erreur, le nombre doit compris entre {min} et {max}, veuillez recommencer :");
            }
            if (separation) { Console.WriteLine(""); }

            return Resultat;
        }
        public static DateTime UnDateTime(string message)
        {
            DateTime Resultat = DateTime.Now;

            Console.WriteLine(message);
            while (!DateTime.TryParse(Console.ReadLine(), out Resultat))
            {
                Console.WriteLine("Date incorrecte, veuillez entrer une date valide :");
            }

            return Resultat;
        }
        public static T UnEnumere<T>() where T : struct, Enum
        {
            T Resultat = (T)Enum.GetValues(typeof(T)).GetValue(0);

            Console.WriteLine("Veuillez faire un choix parmi la liste suivante :");
            foreach (T enumValue in Enum.GetValues(typeof(T))) { Console.WriteLine($"{enumValue:D}.{enumValue.GetDescription()}"); }

            while (!Enum.TryParse(Console.ReadLine(), out Resultat) || !Enum.IsDefined(typeof(T), Resultat))
            {
                Console.WriteLine("Valeur erronnée, veuillez recommencer :");
            }

            return Resultat;
        }
        public static string UnString(string message)
        {
            Console.WriteLine(message);
            string Resultat = Console.ReadLine();

            while (Resultat == string.Empty)
            {
                Console.WriteLine($"Erreur, il faut une valeur, veuillez recommencer :");
                Resultat = Console.ReadLine();
            }

            return Resultat;
        }

        /// <summary>
        /// Méthode qui encapsule les méthodes marquées 'PRIVATE' dans d'autres qui sont public afin de les protéger des exceptions générées.
        /// si exception, le texte de celle-ci est affiché dans la console.
        /// </summary>
        /// <param name="action"></param>
        public static void WhileTryCatch(Action action)
        {
            bool lErreur = true;
            while (lErreur)
            {
                lErreur = false;
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lErreur = true;
                }
            }
        }
    }
}
