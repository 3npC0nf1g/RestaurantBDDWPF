using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BibliRestaurant
{
    public class BDDSingleton
    {
        //Champ/Objet unique et accessible globalement permettant d'accéder à la base de données et ses fonctionnalités.
        //Toutes les fonctionnalités décrites dans la classe ne sont donc accessibles que depuis cette instance unique.
        //La classe n'est pas elle même statique, cela permet d'initialiser la base données dans le constructeur et donc au moment souhaité.
        public static BDDSingleton Instance { get; private set; } = new BDDSingleton();

        //Propriété privée représentant la base de données
        private BDDReservations BDD { get; set; }

        //Propriété renvoyant un booléen informant s'il y a des modifications en attente de sauvegarde ou non dans la BDD.
        public bool ModificationsEnAttente => BDD?.ChangeTracker.HasChanges() ?? false;

        //table Personnes de la BDD sous forme de ReadOnlyObservableCollection (en lecture seule, on ne peut ajouter ni enlever)
        //Permet de profiter du mécanisme du Binding (WPF)
        //L'utilisation d'un champ (ici caché car propriété automatique) permet de garder l'objet en mémoire et donc de ne le charger qu'une fois
        //L'accesseur set étant privé, le champ ne peut être modifié que dans le code de cette classe.
        public ReadOnlyObservableCollection<Reservation> Reservations { get; private set; }

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        //Le ? vérifie que la base de données existe bien en mémoire, ce qui permet d'éviter une exception si ce n'est pas le cas.
        public Reservation AjouterReservation(string NomPrenom) { return BDD?.AjouterReservation(NomPrenom); }
        public void SupprimerReservation(Reservation reservation) { BDD?.SupprimerReservation(reservation); }
        #endregion

        #region Méthodes effectuant des modifications/actions plus spécifiques sur les données
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomFichier">Si la valeur reste vide, utilise le nom de fichier par défaut dans BDDPersonnes, sinon utilise le nom spécifié.</param>
        /// <param name="forcageNouveauFichier">Si vrai, force une nouvelle base de données. Si faux, travaille avec la base de données déja créée (s'il n'y en a pas, en crée une nouvelle).</param>
        public void ChargerDonnees(string nomFichier = "", bool forcageNouveauFichier = false)
        {
            //Création de l'objet BDD (appel de l'un ou l'autre constructeur en fonction qu'il y ait un nom de fichier spécifié ou non)
            if (nomFichier == string.Empty) { BDD = new BDDReservations(); }
            else { BDD = new BDDReservations(nomFichier); }

            if (forcageNouveauFichier) { BDD.Database.EnsureDeleted(); } //S'il faut créer une nouvelle base de données, d'abord suppression de celle qui existe (s'il y en a une).
            BDD.Database.EnsureCreated(); //Vérification de l'existence de la BDD. Si non, création de celle-ci.

            //ATTENTION : Il est ici nécessaire de charger toutes les tables de la BDD
            //Si ce n'est pas le cas il faudra le faire au fur et à mesure de leur utilisation
            BDD.Reservations.Load(); //Chargement de la table Personnes.

            //Création de la ReadOnlyObservableCollection permet de travailler avec la table dans un format adapté à un projet WPF
            //Le terme Local permet de travailler avec les données temporaires non encore sauvegardées dans la bdd.
           Reservations = new ReadOnlyObservableCollection<Reservation>(BDD?.Reservations.Local.ToObservableCollection());
        }
        public void SauvegarderModifications() { BDD?.SaveChanges(); }
        #endregion
    }
}
