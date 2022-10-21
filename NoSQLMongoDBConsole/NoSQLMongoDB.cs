using BibliRestaurant;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace NoSQLMongoDBConsole
{
    public class MongoDatabase
    {
        public static readonly string MDBConnectionString = "mongodb://127.0.0.1:27017/";
        public static readonly string MDBDatabase = "MarbinStev";
        public static readonly string MDBCollection = "inforeservation";
        public static readonly int PeriodeTest = 700;

        public static Random Generateur = new Random();

        private static IMongoCollection<BsonDocument> _collection;

        public static void GenererDonnees(ReadOnlyObservableCollection<Reservation> reservations)
        {
            
            MongoClient client = new MongoClient(MDBConnectionString);

           
            IMongoDatabase database = client.GetDatabase(MDBDatabase);
           
            database.DropCollection(MDBCollection);
            database.DropCollection("NombreReservationsParThème");
            database.DropCollection("NombreReservationsParThèmeEtType");
            database.DropCollection("NombreReservationsParZone");
            database.DropCollection("NombreReservationsParZoneEtType");
            database.DropCollection("MoyenneReservationsParZoneTypeEtThème");

            _collection = database.GetCollection<BsonDocument>(MDBCollection);

            #region Génération de données des réservations
          
            DateTime day = DateTime.Now.AddDays(-1 * PeriodeTest);

            for (int i = 0; i < PeriodeTest; i++)
            {
                foreach (Reservation r in reservations)
                {
                    string Theme = "";
                    int ThemeRND = Generateur.Next(1, 7);
                       const byte Afro = 2;
                       const byte Euro = 3;
                       const byte Asiat = 4;
                       const byte Ricain = 5;
                       const byte Var = 6; 
                       switch (ThemeRND)
                       {
                        case <= Afro:
                            { Theme = "Africain"; }
                            break;
                         case <= Euro:
                            { Theme = "Européen"; }
                            break;
                         case <= Asiat:
                            { Theme = "Asiatique"; }
                            break;
                        case <= Ricain:
                            { Theme = "Américain"; }
                            break;
                            case <=Var:
                            { Theme = "Variété"; }
                            break; 
                        default:
                            Theme = "";
                            break;
                       }
                    string Zone = "";
                    int ZoneRND = Generateur.Next(1, 8);
                    const byte Enter = 2;
                    const byte Exteréieur = 3;
                    const byte Toillettes = 4;
                    const byte Bar = 5;
                    const byte Sortie = 6;
                    const byte Mezanine = 7;
                    switch (ZoneRND)
                    {
                        case <= Enter:
                            { Zone = "Entrée"; }
                            break;
                        case <= Exteréieur:
                            { Zone = "Térasse"; }
                            break;
                        case <= Toillettes:
                            { Zone = "Près Des Toilettes"; }
                            break;
                        case <= Bar:
                            { Zone = "Près Du Bar"; }
                            break;
                        case <= Sortie:
                        { Zone = "Près De La Sortie"; }
                            break;
                        case <= Mezanine:
                            { Zone = "Mezzanine"; }
                            break;
                        default:
                            Zone = "";
                            break;
                    }            
                        string Type = "";
                        int TypeRND = Generateur.Next(1, 7);
                    const byte Afric = 2;
                    const byte Améric = 3;
                    const byte Europ = 4;
                    const byte Asie = 5;
                    const byte Autre = 6;
                    switch (TypeRND)
                    {
                        case <= Afric:
                            { Type = "Africain"; }
                            break;
                        case <= Améric:
                            { Type = "Américain"; }
                            break;
                        case <= Europ:
                            { Type = "Européen"; }
                            break;

                        case <= Asie:
                            { Type = "Asiatique"; }
                            break;

                        case <= Autre:
                            { Type = "Océanien"; }
                            break;
                        default:
                            Type = "";
                            break;
                    }
                        _collection.InsertOne(
                            new BsonDocument() {
                            { "date", day.ToString() },    
                            { "type", Type  },
                            { "zone", Zone },
                            { "theme",Theme }
                            }
                        );
                    
                }
                day = day.AddDays(1); 
            }
            #endregion
        }

        internal static IEnumerable<BsonDocument> CalculerNombreReservationsParThème()
        {
            return _collection.Aggregate()
                              .Group(new BsonDocument { { "_id", "$theme" }, { "count", new BsonDocument("$sum", 1) } }) 
                              .Out("NombreReservationsParThème")                                                          
                              .ToEnumerable();
        }

        internal static IEnumerable<BsonDocument> CalculerNombreReservationsParThèmeEtType()
        {
            return _collection.Aggregate()
                              .Group(new BsonDocument { { "_id", new BsonDocument { { "$concat", new BsonArray { "$theme", ".", "$type" } } } }, { "count", new BsonDocument("$sum", 1) } })
                              .Out("NombreReservationsParThèmeEtType")
                              .ToEnumerable();
        }

        internal static IEnumerable<BsonDocument> CalculerNombreReservationsParZone()
        {
            return _collection.Aggregate()
                              .Group(new BsonDocument { { "_id", "$zone" }, { "count", new BsonDocument("$sum", 1) } }) 
                              .Out("CalculerNombreReservationsParZone")                                                                 
                              .ToEnumerable();
        }

        internal static IEnumerable<BsonDocument> CalculerNombreReservationsParZoneEtType()
        {
            return _collection.Aggregate()
                              .Group(new BsonDocument { { "_id", new BsonDocument { { "$concat", new BsonArray { "$zone", ".", "$type" } } } }, { "cout", new BsonDocument("$sum", 1) } })
                              .Out("CalculerNombreReservationsParZoneEtType")
                              .ToEnumerable();
        }
      /* internal static IEnumerable<BsonDocument> CalculerReservationsParTypeZoneEtThème()
        {
            return _collection.Aggregate()
                              .Group(new BsonDocument { { "_id", new BsonDocument { { "$concat", new BsonArray { "$type", ".", "$zone" } } } }, { "count", new BsonDocument("$sum", 1) } })
                              .Out("CalculerNombreReservationsParZoneEtType")
                              .ToEnumerable();
        }
      */

    }
}
