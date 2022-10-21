using BibliRestaurant;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace NoSQLMongoDBConsole
{
    class Program
    {
        static void Main(string[] args)
        {
          
            BDDSingleton _bdd = BDDSingleton.Instance;
            _bdd.ChargerDonnees();

          
            Console.WriteLine("Génération des données...");
            MongoDatabase.GenererDonnees(_bdd.Reservations);
            Console.WriteLine("Terminé !");

            Console.WriteLine("\nReservations par thème :");
            Console.WriteLine($"{"Nom",-10} Reservés");
            foreach (BsonDocument bson in MongoDatabase.CalculerNombreReservationsParThème())
            {
                Console.WriteLine($"{bson["_id"],-10} {bson["count"]}");
            }

           
            Console.WriteLine("\nReservations par zone :");
            Console.WriteLine($"{"Nom",-20} Reservés");
            foreach (BsonDocument bson in MongoDatabase.CalculerNombreReservationsParZone())
            {
                Console.WriteLine($"{bson["_id"],-20} {bson["count"]}");
            }

           
            Console.WriteLine("\nReservations par thème et type :");
            Console.WriteLine($"{"Nom",-20} Reservés");
            foreach (BsonDocument bson in MongoDatabase.CalculerNombreReservationsParThèmeEtType())
            {
                Console.WriteLine($"{bson["_id"],-20} {bson["count"]}");
            }

        
            Console.WriteLine("\nReservations par zone et type :");
            Console.WriteLine($"{"Nom",-30} Reservés");
            foreach (BsonDocument bson in MongoDatabase.CalculerNombreReservationsParZoneEtType())
            {
                Console.WriteLine($"{bson["_id"],-30} {bson["count"]}");
            }



          /*  Console.WriteLine("\nMoyenne De Reservations par zone , type et thème :");
            Console.WriteLine($"{"Nom",-50} Moyenne");
            foreach (BsonDocument bson in MongoDatabase.CalculerMoyenneReservationsParTypeZoneEtThème())
            {
                Console.WriteLine($"{bson["_id"],-50} {bson["count"]}");
            }

            */






        }
    }
}
