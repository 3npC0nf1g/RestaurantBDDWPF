using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BibliRestaurant
{
    internal class BDDReservations : DbContext
    {
        #region Emplacement de la base de données
        internal static string Emplacement => Path.Combine(Directory.GetCurrentDirectory(), NomFichier);
        internal static string NomFichier { get; private set; } = "BDDReservations.db";
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

            #endregion
        }
        #endregion

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        internal Reservation AjouterReservation(string NomPrenom)
        {
            //Gestion des erreurs
            if (NomPrenom == null || NomPrenom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterReservation)} : La personne doit avoir un nom et un prenom (valeur NULL ou chaine vide)."); }
            // if (prenom == null || prenom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterPersonne)} : La personne doit avoir un prénom (valeur NULL ou chaine vide)."); }

            //Ajout de la nouvelle Personne
            Reservation NouvelleReservation = new Reservation() { NomPrenom = NomPrenom };
            Reservations.Local.Add(NouvelleReservation);
            return NouvelleReservation;
        }

        internal void SupprimerReservation(Reservation Reservation)
        {
            //Gestion des erreurs
            if (Reservation == null) { throw new ArgumentNullException($"{nameof(SupprimerReservation)} : Il faut une personne en argument (valeur NULL)."); }

            //Suppression de l'auteur
            Reservations.Local.Remove(Reservation);
        }
        #endregion
    }
}
