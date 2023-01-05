using BibliRestaurantBDD;
using System;

namespace BibliConsoleTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Création de la base de données...");
            BDDSingleton _bdd = BDDSingleton.Instance;
            Console.WriteLine("Base de données créée SUPER... !");
        }
    }
}
