using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliRestaurantBDD
{
    internal class BDDBibliotheque : DbContext
    {
        #region Tables de la BDD
        internal DbSet<Menu> Menus { get; set; }
        internal DbSet<Client> Clients { get; set; }
        internal DbSet<Reservation> Reservations { get; set; }
        internal DbSet<SouhaiteAvoir> SouhaiteAvoir { get; set; }
        internal DbSet<Table> Tables { get; set; }
        internal DbSet<Zone> Zones { get; set; }
        #endregion

        #region Méthodes d'initialisation de la base de données
        /// <summary>
        /// Méthode de configuration de la connexion à la base de données.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($@"Data Source={Path.Combine(Directory.GetCurrentDirectory(), "BDDBibliotheque.db")}");
        }

        /// <summary>
        /// Méthode contenant le code lié aux contraintes du modèle de données et aux données présentes par défaut
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Contraintes liées au modèle de la BDD
            //Pour une table provenant d'une association il vaut mieux préciser la clé primaire, qui est ici la combinaison des deux clés étrangères
            modelBuilder.Entity<SouhaiteAvoir>().HasKey(sc => new { sc.ClientID, sc.ReservationID, sc.MenuID });
          
            #endregion

            #region Données présentes par défaut dans la BDD
            modelBuilder.Entity<Menu>().HasData(

                new Menu() { ID = 1,  Entree = "Salade de fruit",            Repas = "Ndolè",              Dessert = "Mousse aux fruits rouges",   Boisson = "Fanta" },
                new Menu() { ID = 2,  Entree = "Velouté de petits pois",     Repas = "Poulet DG",          Dessert = "Carrot Cake",                Boisson = "Coca" },
                new Menu() { ID = 3,  Entree = "Soupe de patates douces",    Repas = "Le poisson braisé",  Dessert = "Gâteau au thé matcha",       Boisson = "Sprite" },
                new Menu() { ID = 4,  Entree = "Salade de fruit",            Repas = "Ndolè",              Dessert = "Gâteau au chocolat",         Boisson = "Anana" },
                new Menu() { ID = 5,  Entree = "Tarte feuilletée pomme",     Repas = "Le poisson braisé",  Dessert = "Mousse aux fruits rouges",   Boisson = "Pemplemouss" },
                new Menu() { ID = 6,  Entree = "Nems au four",               Repas = "Ndolè",              Dessert = "Gâteau au praliné",          Boisson = "Fanta" },
                new Menu() { ID = 7,  Entree = "Croque-Monsieur au caramel", Repas = "Kondrè",             Dessert = "Gâteau au thé matcha",       Boisson = "Coca" },
                new Menu() { ID = 8,  Entree = "Nems au four",               Repas = "Poulet DG",          Dessert = "Blondie au sorbet",          Boisson = "Sprite" },
                new Menu() { ID = 9,  Entree = "Salade de fruit",            Repas = "Sanga",              Dessert = "Carrot Cake",                Boisson = "Pemplemouss" },
                new Menu() { ID = 10, Entree = "Tarte feuilletée pomme",     Repas = "Le Nkui",            Dessert = "Gâteau au praliné",          Boisson = "Anana" },
                new Menu() { ID = 11, Entree = "Nems au four",               Repas = "Ndolè",              Dessert = "Gâteau au chocolat",         Boisson = "Pemplemouss" },
                new Menu() { ID = 12, Entree = "Velouté de petits pois",     Repas = "Kondrè",             Dessert = "Cheesecake",                 Boisson = "Anana" },
                new Menu() { ID = 13, Entree = "Soupe de patates douces",    Repas = "Eru",                Dessert = "Mousse aux fruits rouges",   Boisson = "Fanta" },
                new Menu() { ID = 14, Entree = "Salade de fruit",            Repas = "Koki",               Dessert = "Blondie au sorbet",          Boisson = "Coca" },
                new Menu() { ID = 15, Entree = "Croque-Monsieur au caramel", Repas = "Okok",               Dessert = "Cheesecake",                 Boisson = "Sprite" } 
            );

            modelBuilder.Entity<Client>().HasData(

               new Client() { ID = 1, NomPrenom = "Fontaine Jesper",       Email = "JesperFontaine@dayrep.com",          NombrePersonne = 4 },
               new Client() { ID = 2,  NomPrenom = "Leroy Violette",       Email = "VioletteLeroy@fai.com",              NombrePersonne = 2 },
               new Client() { ID = 3,  NomPrenom = "Favreau Fantine",      Email = "FantinaFavreau@fai.com",             NombrePersonne = 4 },
               new Client() { ID = 4,  NomPrenom = "Flordelis Mathieu",    Email = "CarolosGabriaux@fai.com",            NombrePersonne = 7 },
               new Client() { ID = 5,  NomPrenom = "Mavise  Michel",       Email = "PercyPanetier@rhyta.com",            NombrePersonne = 7 },
               new Client() { ID = 6,  NomPrenom = "Marcoux Désiré",       Email = "MaximeScholten@jourrapide.com",      NombrePersonne = 2 },
               new Client() { ID = 7,  NomPrenom = "Ayot Jacques",         Email = "DesireMarcoux@jourrapide.com",       NombrePersonne = 4 },
               new Client() { ID = 8,  NomPrenom = "Pannetier Percy",      Email = "ChristabelBoncoeur@fai.com",         NombrePersonne = 7 },
               new Client() { ID = 9,  NomPrenom = "Boncoeur Christabel",  Email = "CarolosGabriaux@fai.com",            NombrePersonne = 7 },
               new Client() { ID = 10, NomPrenom = "Paré Natalie",         Email = "ChristabelBoncoeur@fai.com",         NombrePersonne = 6 },
               new Client() { ID = 11, NomPrenom = "Carolos Gabriel",      Email = "PercyPanetier@rhyta.com",            NombrePersonne = 2 },
               new Client() { ID = 12, NomPrenom = "Rep  Aniel",           Email = "CarolosGabriaux@fai.com",            NombrePersonne = 4 },
               new Client() { ID = 13, NomPrenom = "Levijn Gianna",        Email = "DesireMarcoux@jourrapide.com",       NombrePersonne = 7 },
               new Client() { ID = 14, NomPrenom = "Scholten Maxime",      Email = "MaximeScholten@jourrapide.com",      NombrePersonne = 7 },
               new Client() { ID = 15, NomPrenom = "Favreau Julie",        Email = "MaximeScholten@jourrapide.com",      NombrePersonne = 7 }
               
               );


            modelBuilder.Entity<Reservation>().HasData(

              new Reservation() { ID = 1, Manque = true,  NombrePersonne = 6,  DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8},
              new Reservation() { ID = 2, Manque = true,  NombrePersonne = 2 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 3, Manque = true,  NombrePersonne = 4 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 4, Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 5, Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 6, Manque = true,  NombrePersonne = 2 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 7, Manque = true,  NombrePersonne = 4 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 8, Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 9, Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 10,Manque = true,  NombrePersonne = 6 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 11,Manque = true,  NombrePersonne = 2 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 12,Manque = true,  NombrePersonne = 4 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 13,Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 14,Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 15,Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}
               );

            modelBuilder.Entity<SouhaiteAvoir>().HasData(

                new SouhaiteAvoir() { ClientID = 1,  ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 2,  ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 3,  ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 4,  ReservationID = 2, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 5,  ReservationID = 2, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 6,  ReservationID = 2, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 7,  ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 8,  ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 9,  ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 10, ReservationID = 2, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 11, ReservationID = 2, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 12, ReservationID = 2, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 13, ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 14, ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 15, ReservationID = 1, MenuID = 7, }
             
            ); modelBuilder.Entity<Table>().HasData(

                new Table() { ID = 1,  ZoneID = 1, NombrePlace = 7, },
                new Table() { ID = 2,  ZoneID = 1, NombrePlace = 7, },
                new Table() { ID = 3,  ZoneID = 1, NombrePlace = 7, },
                new Table() { ID = 4,  ZoneID = 2, NombrePlace = 7, },
                new Table() { ID = 5,  ZoneID = 2, NombrePlace = 7, },
                new Table() { ID = 6,  ZoneID = 2, NombrePlace = 7, },
                new Table() { ID = 7,  ZoneID = 1, NombrePlace = 7, },
                new Table() { ID = 8,  ZoneID = 1, NombrePlace = 7, },
                new Table() { ID = 9,  ZoneID = 1, NombrePlace = 7, },
                new Table() { ID = 10, ZoneID = 2, NombrePlace = 7, },
                new Table() { ID = 11, ZoneID = 2, NombrePlace = 7, },
                new Table() { ID = 12, ZoneID = 2, NombrePlace = 7, },
                new Table() { ID = 13, ZoneID = 1, NombrePlace = 7, },
                new Table() { ID = 14, ZoneID = 1, NombrePlace = 7, },
                new Table() { ID = 15, ZoneID = 1, NombrePlace = 9, }
             
            );
     
            modelBuilder.Entity<Zone>().HasData(

                new Zone() { ID = 1,  Description = "Térasse" ,           Fumeur = false, },
                new Zone() { ID = 2,  Description = "Près du bar" ,       Fumeur = false, },
                new Zone() { ID = 3,  Description = "près de la sortie" , Fumeur = false, },
                new Zone() { ID = 4,  Description = "Mezzanine" ,         Fumeur = false, },
                new Zone() { ID = 5,  Description = "Entreé" ,            Fumeur = false, },
                new Zone() { ID = 6,  Description = "Mezzanine" ,         Fumeur = false, },
                new Zone() { ID = 7,  Description = "Térasse" ,           Fumeur = false, },
                new Zone() { ID = 8,  Description = "Près du bar" ,       Fumeur = false, },
                new Zone() { ID = 9,  Description = "près de la sortie" , Fumeur = false, },
                new Zone() { ID = 10, Description = "Entreé" ,            Fumeur = false, },
                new Zone() { ID = 11, Description = "Mezzanine" ,         Fumeur = false, },
                new Zone() { ID = 12, Description = "Entreé" ,            Fumeur = false, },
                new Zone() { ID = 13, Description = "Térasse" ,           Fumeur = false, },
                new Zone() { ID = 14, Description = "Près du bar" ,       Fumeur = false, },
                new Zone() { ID = 15, Description = "près de la sortie" , Fumeur = false, }
             
            );

         
            #endregion
        }
        #endregion

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        internal Auteur AjouterAuteur(string nom, string prenom)
        {
            //Gestion des erreurs
            if (nom == null || nom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterAuteur)} : L'auteur doit avoir un nom (valeur NULL ou chaine vide)."); }

            //Ajout du nouvel auteur
            Auteur lAuteur = new() { Nom = nom, Prenom = prenom };
            Auteurs.Local.Add(lAuteur);
            return lAuteur;
        }
        internal Client AjouterClient(string nom, string prenom, Ville ville, string rueNumero)
        {
            //Gestion des erreurs
            if (nom == null || nom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le client doit avoir un nom (valeur NULL ou chaine vide)."); }
            if (prenom == null || prenom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le client doit avoir un prénom (valeur NULL ou chaine vide)."); }
            if (ville == null) { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le client doit avoir une ville (valeur NULL)."); }

            //Ajout du nouveau client
            Client lClient = new() { Nom = nom, Prenom = prenom, Ville = ville, RueNumero = rueNumero };
            Clients.Local.Add(lClient);
            return lClient;
        }
        internal Ecrire AjouterEcrire(Auteur auteur, Livre livre)
        {
            //Gestion des erreurs.
            if (auteur == null) { throw new ArgumentNullException($"{nameof(AjouterEcrire)} : Il faut un auteur pour le lien livre/auteur (valeur NULL)."); }
            if (livre == null) { throw new ArgumentNullException($"{nameof(AjouterEcrire)} : Il faut un livre pour le lien livre/auteur (valeur NULL)."); }
            if (Ecrire.Local.FirstOrDefault(ecr => ecr.LivreID == livre.ID && ecr.AuteurID == auteur.ID) != null)
            { throw new InvalidOperationException($"{nameof(AjouterEcrire)} : Le lien écrire existe déjà."); }

            //Ajout du nouveau lien ecrire (livre/auteur).
            Ecrire lEcrire = new() { Auteur = auteur, Livre = livre };
            Ecrire.Local.Add(lEcrire);
            return lEcrire;
        }
        internal Emprunt AjouterEmprunt(DateTime dateEmprunt, Client client, Livre livre)
        {
            //Gestion des erreurs
            if (dateEmprunt == null) { throw new ArgumentNullException($"{nameof(AjouterEmprunt)} : L'emprunt doit avoir une date (valeur NULL)."); }
            if (client == null) { throw new ArgumentNullException($"{nameof(AjouterEmprunt)} : L'emprunt doit avoir un client (valeur NULL)."); }
            if (livre == null) { throw new ArgumentNullException($"{nameof(AjouterEmprunt)} : L'emprunt doit avoir un livre (valeur NULL)."); }
            if (livre.Emprunts != null && livre.Emprunts.FirstOrDefault(em => em.DateRetour == null) != null)
            { throw new InvalidOperationException($"{nameof(AjouterEmprunt)} : Il ne peut y avoir d'emprunt en cours pour le livre (un emprunt n'a pas de date de retour)."); }

            //Ajout du nouvel emprunt
            Emprunt lEmprunt = new() { Client = client, Livre = livre, DateEmprunt = dateEmprunt };
            Emprunts.Local.Add(lEmprunt);
            return lEmprunt;
        }
        internal Livre AjouterLivre(string titre, DateTime dateAchat)
        {
            //Gestion des erreurs
            if (titre == null || titre == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterLivre)} : Le livre doit avoir un titre (valeur NULL ou chaine vide)."); }
            if (dateAchat == null) { throw new ArgumentNullException($"{nameof(AjouterLivre)} : Le livre doit avoir une date d'achat (valeur NULL)."); }

            //Ajout du nouveau livre
            Livre lLivre = new() { Titre = titre, DateAchat = dateAchat };
            Livres.Local.Add(lLivre);
            return lLivre;
        }
        internal Ville AjouterVille(string nom, string codePostal)
        {
            //Gestion des erreurs
            if (nom == null || nom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterVille)} : La ville doit avoir un nom (valeur NULL ou chaine vide)."); }
            if (codePostal == null || codePostal == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterVille)} : La ville doit avoir un code postal (valeur NULL ou chaine vide)."); }

            //Ajout de la nouvelle ville
            Ville lVille = new() { Nom = nom, CodePostal = codePostal };
            Villes.Local.Add(lVille);
            return lVille;
        }

        internal void SupprimerAuteur(Auteur auteur)
        {
            //Gestion des erreurs
            if (auteur == null) { throw new ArgumentNullException($"{nameof(SupprimerAuteur)} : Il faut un auteur en argument (valeur NULL)."); }
            if ((auteur.Livres?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(SupprimerAuteur)} : Il faut d'abord supprimer les livres liés a l'auteur ou désassocier l'auteur de ceux-ci."); }

            //Suppression de l'auteur
            Auteurs.Local.Remove(auteur);
        }
        internal void SupprimerClient(Client client)
        {
            //Gestion des erreurs
            if (client == null) { throw new ArgumentNullException($"{nameof(SupprimerClient)} : Il faut un client en argument (valeur NULL)."); }

            //Avant de supprimer le client, suppression de tous les emprunts liés à celui-ci.
            if (client.Emprunts != null)
            {
                foreach (Emprunt e in client.Emprunts) { SupprimerEmprunt(e); }
            }

            //Suppression du client
            Clients.Local.Remove(client);
        }
        internal void SupprimerEcrire(Ecrire ecrire)
        {
            //Gestion des erreurs
            if (ecrire == null) { throw new ArgumentNullException($"{nameof(SupprimerEcrire)} : Il faut un lien ecrire(livre/auteur) en argument (valeur NULL)."); }

            //Suppression du lien ecrire
            Ecrire.Local.Remove(ecrire);
        }
        internal void SupprimerEmprunt(Emprunt emprunt)
        {
            //Gestion des erreurs
            if (emprunt == null) { throw new ArgumentNullException($"{nameof(SupprimerEmprunt)} : Il faut un emprunt en argument (valeur NULL)."); }

            //Suppression de l'emprunt
            Emprunts.Local.Remove(emprunt);
        }
        internal void SupprimerLivre(Livre livre)
        {
            //Gestion des erreurs
            if (livre == null) { throw new ArgumentNullException($"{nameof(SupprimerLivre)} : Il faut un livre en argument (valeur NULL)."); }
            if ((livre.Emprunts?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(SupprimerLivre)} : Il faut d'abord terminer les emprunts liés au livre."); }

            //Suppression des liens ecrire du livre.
            if (livre.Auteurs != null)
            {
                foreach (Ecrire e in livre.Auteurs) { SupprimerEcrire(e); }
            }

            //Suppression du livre.
            Livres.Local.Remove(livre);
        }
        internal void SupprimerVille(Ville ville)
        {
            //Gestion des erreurs
            if (ville == null) { throw new ArgumentNullException($"{nameof(SupprimerVille)} : Il faut une ville en argument (valeur NULL)."); }
            if ((ville.Clients?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(SupprimerVille)} : Il faut d'abord supprimer les clients habitant la ville."); }

            //Suppression de la ville.
            Villes.Local.Remove(ville);
        }
        #endregion
    }
}
