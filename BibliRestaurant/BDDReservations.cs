using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace BibliRestaurant
{
    internal class BDDReservations : DbContext
    {
        #region Emplacement de la base de données
        internal static string Emplacement => Path.Combine(Directory.GetCurrentDirectory(), NomFichier);
        internal static string NomFichier { get; private set; } = "BDDPersonnes.db";
        #endregion

        #region Tables de la BDD
        internal DbSet<Reservation> Reservations { get; set; }
        #endregion

        #region Méthodes d'initialisation de la base de données
        //Constructeurs de la base de données
        //Permet de créer une nouvelle base de données avec le nom par défaut (voir NomFichier)
        internal BDDReservations() : base() { }
        //Permet de créer/ouvrir une base de données avec le nom de fichier spécifié.
        internal BDDReservations(string nomFichier) : base() { NomFichier = nomFichier; }

        /// <summary>
        /// Méthode de configuration de la connexion à la base de données.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Utilisation de SQLite avec un emplacement par défaut pour la BDD lié à l'emplacement du projet
            optionsBuilder.UseSqlite($@"Data Source={Emplacement}");
        }

        /// <summary>
        /// Méthode contenant le code lié aux contraintes du modèle de données et aux données présentes par défaut
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Contraintes liées au modèle de la BDD

            #endregion

            #region Données présentes par défaut dans la BDD (lors de sa création uniquement)
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation() { ID = 1, NomPrenom = "Fontaine Jesper", NombrePersonnes = 3, Zone = Zones.Entrée, DateReservation = new DateTime(1936, 8, 22), Email = "JesperFontaine@dayrep.com", NumeroTelephone = "+32484674671", NombreFetiche = 25 },
                new Reservation() { ID = 2, NomPrenom = "Leroy Violette", NombrePersonnes = 5, Zone = Zones.PrèsDuBar, DateReservation = new DateTime(1959, 3, 26), Email = "VioletteLeroy@fai.com", NumeroTelephone = "+32489691146", NombreFetiche = 72 },
                new Reservation() { ID = 3, NomPrenom = "Favreau Fantine", NombrePersonnes = 2, Zone = Zones.Entrée, DateReservation = new DateTime(1980, 2, 28), Email = "FantinaFavreau@fai.com", NumeroTelephone = "+32473961004", NombreFetiche = 17 },
                new Reservation() { ID = 4, NomPrenom = "Flordelis Mathieu", NombrePersonnes = 7, Zone = Zones.Entrée, DateReservation = new DateTime(1959, 3, 26), Email = "FlordelisMathieu@rhyta.com", NumeroTelephone = "+32494437781", NombreFetiche = 91 },
                new Reservation() { ID = 5, NomPrenom = "Mavise  Michel", NombrePersonnes = 6, Zone = Zones.PrèsDuBar, DateReservation = new DateTime(1983, 11, 4), Email = "MaviseMichel@jourrapide.com", NumeroTelephone = "+32498935660", NombreFetiche = 42 },
                new Reservation() { ID = 6, NomPrenom = "Marcoux Désiré", NombrePersonnes = 4, Zone = Zones.Entrée, DateReservation = new DateTime(1982, 9, 3), Email = "DesireMarcoux@jourrapide.com", NumeroTelephone = "+32476434966", NombreFetiche = 07 },
                new Reservation() { ID = 7, NomPrenom = "Ayot Jacques", NombrePersonnes = 3, Zone = Zones.PrèsDeLaSortie, DateReservation = new DateTime(1991, 12, 12), Email = "JacquesAyot@dayrep.com", NumeroTelephone = "+32487510553", NombreFetiche = 50 },
                new Reservation() { ID = 8, NomPrenom = "Pannetier Percy", NombrePersonnes = 8, Zone = Zones.Mezzanine, DateReservation = new DateTime(1975, 5, 19), Email = "PercyPanetier@rhyta.com", NumeroTelephone = "+32493876947", NombreFetiche = 13 },
                new Reservation() { ID = 9, NomPrenom = "Boncoeur Christabel", NombrePersonnes = 3, Zone = Zones.PrèsDeLaSortie, DateReservation = new DateTime(1981, 4, 1), Email = "ChristabelBoncoeur@fai.com", NumeroTelephone = "+32477986657", NombreFetiche = 88 },
                new Reservation() { ID = 10, NomPrenom = "Paré Natalie", NombrePersonnes = 7, Zone = Zones.Entrée, DateReservation = new DateTime(1967, 6, 9), Email = "NathaliePare@rhyta.com", NumeroTelephone = "+32488796427", NombreFetiche = 32 },
                new Reservation() { ID = 11, NomPrenom = "Carolos Gabriel", NombrePersonnes = 5, Zone = Zones.Entrée, DateReservation = new DateTime(1954, 8, 17), Email = "CarolosGabriaux@fai.com", NumeroTelephone = "+32474601722", NombreFetiche = 75 },
                new Reservation() { ID = 12, NomPrenom = "Rep  Aniel", NombrePersonnes = 3, Zone = Zones.PrèsDeLaSortie, DateReservation = new DateTime(1941, 3, 11), Email = "AnielRep@touristsagency.com", NumeroTelephone = "+32473432452", NombreFetiche = 41 },
                new Reservation() { ID = 13, NomPrenom = "Levijn Gianna", NombrePersonnes = 2, Zone = Zones.PrèsDuBar, DateReservation = new DateTime(1933, 3, 29), Email = "GiannaLevels@teleworm.be", NumeroTelephone = "+32485907086", NombreFetiche = 5 },
                new Reservation() { ID = 14, NomPrenom = "Scholten Maxime", NombrePersonnes = 5, Zone = Zones.PrèsDeLaSortie, DateReservation = new DateTime(1994, 11, 3), Email = "MaximeScholten@jourrapide.com", NumeroTelephone = "+32484716662", NombreFetiche = 64 },
                new Reservation() { ID = 15, NomPrenom = "Favreau Julie", NombrePersonnes = 6, Zone = Zones.Entrée, DateReservation = new DateTime(1990, 5, 15), Email = "JulieFavreau@rhyta.com", NumeroTelephone = "+32472225941", NombreFetiche = 2 }
            ); ;
            #endregion
        }
        #endregion

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        internal Reservation AjouterReservation(string nomprenom)
        {
            //Gestion des erreurs
            if (nomprenom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterReservation)} : La personne doit avoir un nom et un prenom (valeur NULL ou chaine vide)."); }
            //if (prenom == null || prenom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterPersonne)} : La personne doit avoir un prénom (valeur NULL ou chaine vide)."); }

            //Ajout de la nouvelle Personne
            Reservation NouvelleReservation = new Reservation() { NomPrenom = nomprenom};
            Reservations.Local.Add(NouvelleReservation);
            return NouvelleReservation;
        }

        internal void SupprimerReservation(Reservation reservation)
        {
            //Gestion des erreurs
            if (reservation == null) { throw new ArgumentNullException($"{nameof(SupprimerReservation)} : Il faut une reservation en argument (valeur NULL)."); }

            //Suppression de l'auteur
            Reservations.Local.Remove(reservation);
        }
        #endregion
    }
}
