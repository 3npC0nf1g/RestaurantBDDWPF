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


            //BDD
            //Attention : l'ordre des 3 lignes suivantes est important
            BDDSingleton _bdd = BDDSingleton.Instance;
            _bdd.ChargerDonnees();
            ReadOnlyObservableCollection<Reservation> ListeReservations = _bdd.Reservations;

            do
            {
                Console.WriteLine("1.Ajouter une réservation à la liste.");
                Console.WriteLine("2.Enlever une réservation de la liste.");
                Console.WriteLine("3.Afficher la liste.");
                Console.WriteLine("4.Quitter\n");

                Console.WriteLine("Veuillez faire un choix :");
                while (!byte.TryParse(Console.ReadLine(), out Choix) || Choix < 1 || Choix > 4)
                {
                    Console.WriteLine($"Erreur, le nombre doit être compris entre 1 et 4, veuillez recommencer :");
                }

                switch (Choix)
                {
                    #region 1.Ajouter une personne à la liste
                    case 1:

                        Reservation NouvelleReservation = _bdd.AjouterReservation("Doe John");

                        NouvelleReservation.NomPrenom = Lire.UnString("Veuillez entrer un nom et un prénom :");
                        NouvelleReservation.NombrePersonnes = Lire.UnByte("Veuillez entrer le nombre de personne");

                        NouvelleReservation.DateReservation = Lire.UnDateTime("Veuillez entrer la date et l'heure format(jj/mm/aa hh:mm) :");
                        
                        NouvelleReservation.Zone = Lire.UnEnumere<Zones>();
                        Lire.WhileTryCatch(() => { NouvelleReservation.NumeroTelephone = Lire.UnString("Veuillez entrer un numéro de téléphone :"); });
                        Lire.WhileTryCatch(() => { NouvelleReservation.Email = Lire.UnString("Veuillez entrer un mail :"); });
                        Lire.WhileTryCatch(() => { NouvelleReservation.NombreFetiche = Lire.UnByte("Veuillez entrer votre nombre fétiche :", Reservation.NombreFeticheMIN, Reservation.NombreFeticheMAX); });

                        _bdd.SauvegarderModifications();








                      /*  Reservation NouvelleReservation = _bdd.AjouterReservation("Doe");

                        Console.WriteLine("Veuillez entrer un nom et un prénom :");
                        NouvelleReservation.NomPrenom = Console.ReadLine();
                        while (NouvelleReservation.NomPrenom == string.Empty)
                        {
                            Console.WriteLine($"Erreur, il faut un nom, veuillez recommencer :");
                            NouvelleReservation.NomPrenom = Console.ReadLine();
                        }

                        byte _resultatNbre_prsns = 0;
                        Console.WriteLine("Veuillez entrer le nombre de personne :");
                        byte.TryParse(Console.ReadLine(), out _resultatNbre_prsns);
                        while (_resultatNbre_prsns < 1 || _resultatNbre_prsns > 8)
                        {
                            Console.WriteLine($"Erreur, le nombre de personnes doit être compris entre 1 et 8, veuillez recommencer :");
                            byte.TryParse(Console.ReadLine(), out _resultatNbre_prsns);
                        }
                        NouvelleReservation.NombrePersonnes = _resultatNbre_prsns;



                        DateTime _resultdate = DateTime.Now;


                        Console.WriteLine("Veuillez entrer la date et l'heure format(jj/mm/aa hh:mm) :");

                        while (!DateTime.TryParse(Console.ReadLine(), out _resultdate))
                        {
                            Console.WriteLine($"Erreur, veuillez entrer une date correcte:");
                        }
                        NouvelleReservation.DateReservation = _resultdate;



                        Zones _resultatZone = (Zones)Enum.GetValues(typeof(Zones)).GetValue(0);
                        Console.WriteLine("Veuillez faire un choix parmi la liste suivante :");

                        foreach (Zones Zone in Enum.GetValues(typeof(Zones))) { Console.WriteLine($"{Zone:D}.{Zone.GetDescription()}"); }

                        while (!Enum.TryParse(Console.ReadLine(), out _resultatZone) || !Enum.IsDefined(typeof(Zones), _resultatZone))
                        {
                            Console.WriteLine("Valeur erronnée, veuillez recommencer :");
                        }

                        NouvelleReservation.Zone = _resultatZone;

                        bool lErreurMail = true;
                        while (lErreurMail)
                        {
                            lErreurMail = false;
                            try
                            {
                                Console.WriteLine("Veuillez entrer l’email :");
                                NouvelleReservation.Email = Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                lErreurMail = true;
                            }
                        }

                        bool lErreurNumeroTelephone = true;
                        while (lErreurNumeroTelephone)
                        {
                            lErreurNumeroTelephone = false;
                            try
                            {
                                Console.WriteLine("Veuillez entrer le numéro de téléphone :");
                                NouvelleReservation.NumeroTelephone = Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                lErreurNumeroTelephone = true;
                            }
                        }

                        _bdd.SauvegarderModifications();*/
                        break;
                    #endregion
                    #region 2.Enlever une personne de la liste
                    case 2:
                        if (ListeReservations.Count > 0)
                        {
                            byte _aEnlever = 0;

                            //Execute le code pour chaque personne dans la liste.
                            //Contrairement à un for il n'y a pas de compteur.
                            //IndexOf : renvoie l'indice de l'objet dans la liste.
                            foreach (Reservation p in ListeReservations) { Console.WriteLine($"{ListeReservations.IndexOf(p)} : {p.Details}."); }
                            //Un objet de la liste est enlevé sur base de sa position.
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
                    #region 3.Afficher la liste
                    case 3:
                        Console.WriteLine(Reservation.DetailsEntetes);
                        foreach (Reservation p in ListeReservations) { Console.WriteLine($"{p.Details}"); }
                        Console.WriteLine("");
                        break;
                        #endregion
                }
            } while (Choix != 4);
        }
    }
}
