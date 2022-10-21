using BibliRestaurant;
using System;
using System.Collections.ObjectModel;

namespace InterfaceConsole
{
    class Program
    {
        private static void Main(string[] args)
        {
            byte Choix = 0;


          
            BDDSingleton _bdd = BDDSingleton.Instance;
            _bdd.ChargerDonnees();
            ReadOnlyObservableCollection<Reservation> ListeReservations = _bdd.Reservations;

            do
            {
                Console.WriteLine("1.Ajouter une réservation à la liste.");
                Console.WriteLine("2.Enlever une réservation de la liste.");
                Console.WriteLine("3.Afficher la liste triée... ");
                Console.WriteLine("4.Afficher uniquement...");
                Console.WriteLine("5.Quitter\n");
                Choix = Lire.UnByte("Veuillez faire un choix :", 1, 5, true);

                switch (Choix)
                {
                    #region 1.Ajouter une personne à la liste
                    case 1:
                        Reservation NouvelleReservation = _bdd.AjouterReservation("Doe John");
                        NouvelleReservation.NomPrenom = Lire.UnString("Veuillez entrer un nom et un prénom :");
                        NouvelleReservation.DateReservation = Lire.UnDateTime("Veuillez entrer la date et l'heure  :");
                        NouvelleReservation.ZoneRestaurant = Lire.UnEnumere<Zones>();
                        NouvelleReservation.TypeDeMenu = Lire.UnEnumere<TypePlat>();
                        NouvelleReservation.ChoixDuDécor = Lire.UnEnumere<Décor>();
                        Lire.WhileTryCatch(() => { NouvelleReservation.NumeroTelephone = Lire.UnString("Veuillez entrer un numéro de téléphone :"); });
                        Lire.WhileTryCatch(() => { NouvelleReservation.Adresse = Lire.UnString("Veuillez entrer une adresse :"); });
                        Lire.WhileTryCatch(() => { NouvelleReservation.Email = Lire.UnString("Veuillez entrer un mail :"); });
                        Lire.WhileTryCatch(() => { NouvelleReservation.NuméroTable = Lire.UnByte("Veuillez entrer votre numéro de table :", Reservation.NuméroTableMIN, Reservation.NuméroTableMAX); });
                        Lire.WhileTryCatch(() => { NouvelleReservation.PlaceParking = Lire.UnByte("Veuillez entrer votre place de parking :", Reservation.PlaceParkingMIN, Reservation.PlaceParkingMAX); });
                        Lire.WhileTryCatch(() => { NouvelleReservation.NombrePersonnes = Lire.UnByte("Veuillez entrer le nombre personnes :", Reservation.NombrePersonnesMIN, Reservation.NombrePersonnesMAX); });
                        _bdd.SauvegarderModifications();







                        break;
                    #endregion
                    #region 2.Enlever une personne de la liste
                    case 2:
                        if (ListeReservations.Count > 0)
                        {
                            byte _aEnlever = 0;

                           
                            foreach (Reservation p in ListeReservations) { Console.WriteLine($"{ListeReservations.IndexOf(p)} : {p.Details}."); }
                           
                            Console.WriteLine("Veuillez faire un choix :");
                            while (!byte.TryParse(Console.ReadLine(), out _aEnlever) || _aEnlever < 0 || _aEnlever > ListeReservations.Count - 1)
                            {
                                Console.WriteLine($"Erreur, le nombre doit compris entre 0 et {ListeReservations.Count - 1}, veuillez recommencer :");
                            }
                            _bdd.SupprimerReservation(ListeReservations[_aEnlever]);
                            _bdd.SauvegarderModifications();
                        }
                        else { Console.WriteLine("Liste vide, rien à supprimer."); }
                        break;
                    #endregion
                    #region 3.Afficher la liste triée...
                    case 3:
                        Console.WriteLine("Veuillez faire un choix parmi les tris suivants :");
                        Console.WriteLine("1.Par défaut.");
                        Console.WriteLine("2.Par Jours Restants croissant.");
                        Console.WriteLine("3.Par Jours Restants décroissant.");
                        Console.WriteLine("4.Par nom (A -> Z).");
                        Console.WriteLine("5.Par nom (Z -> A).");

                        IEnumerable<Reservation> ListeTriee = Lire.UnByte("Veuillez entrer une valeur entre 1 et 5", 1, 5) switch
                        {
                            1 => ListeReservations.OrderBy(x => x), 
                            2 => ListeReservations.OrderBy(x => x.TpsRestant),
                            3 => ListeReservations.OrderByDescending(x => x.TpsRestant),
                            4 => ListeReservations.OrderBy(x => x.NomPrenom),
                            5 => ListeReservations.OrderByDescending(x => x.NomPrenom),
                            _ => ListeReservations.OrderBy(x => x),  
                        };

                        Console.WriteLine(Reservation.DetailsEntetes);
                        foreach (Reservation r in ListeTriee) { Console.WriteLine($"{r}"); }
                        Console.WriteLine("");
                        break;
                    #endregion



                    #region 4.Afficher uniquement...
                    case 4:
                        Console.WriteLine("1.Par Nombre De Personnes.");
                        Console.WriteLine("2.Par Jours Restants.");
                        Console.WriteLine("3.Par Zone.");

                        IEnumerable<Reservation> ListeFiltree = ListeReservations;
                        switch (Lire.UnByte("Veuillez faire un choix :", 1, 3))
                        {
                            case 1:
                                byte NombreMIN = Lire.UnByte("Nombre minimum :");
                                byte NombreMAX = Lire.UnByte("Nombre maximum :", NombreMIN);
                                ListeFiltree = ListeReservations.Where(x => x.NombrePersonnes >= NombreMIN && x.NombrePersonnes <= NombreMAX).OrderBy(x => x);
                                break;
                            case 2:
                                byte JourMIN = Lire.UnByte("jours minimum restants :");
                                byte JourMAX = Lire.UnByte("jours maximum restants:", JourMIN);
                                ListeFiltree = ListeReservations.Where(x => x.TpsRestant >= JourMIN && x.TpsRestant <= JourMAX).OrderBy(x => x);
                                break;
                            case 3:
                                Zones Zone = Lire.UnEnumere<Zones>();
                                ListeFiltree = ListeReservations.Where(x => x.ZoneRestaurant == Zone).OrderBy(x => x);
                                break;
                        }

                        Console.WriteLine(Reservation.DetailsEntetes);
                        foreach (Reservation r in ListeFiltree) { Console.WriteLine($"{r}"); }
                        Console.WriteLine("");
                        break;
                        #endregion
                }
            } while (Choix != 5);
        }
    }
}
