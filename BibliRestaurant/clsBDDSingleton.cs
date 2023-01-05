
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;

namespace BibliRestaurantBDD
{
    public class BDDSingleton
    {
        #region Propriétés représentant la Base de données ou la rendant accessible à l'extérieur du projet
        public static BDDSingleton Instance { get; private set; } = new BDDSingleton();
        private BDDBibliotheque BDD { get; set; }
        #endregion

        #region Propriétés
        public bool ModificationsEnAttente => BDD?.ChangeTracker.HasChanges() ?? false;
        #endregion

        #region Tables de la BDD (sous forme de ReadOnlyObservableCollection)
        public ReadOnlyObservableCollection<Auteur> Auteurs { get; private set; }
        public ReadOnlyObservableCollection<clsClient> Clients { get; private set; }
        public ReadOnlyObservableCollection<Ecrire> Ecrire { get; private set; }
        public ReadOnlyObservableCollection<Emprunt> Emprunts { get; private set; }
        public ReadOnlyObservableCollection<Livre> Livres { get; private set; }
        public ReadOnlyObservableCollection<Ville> Villes { get; private set; }
        #endregion

        #region Constructeur de la classe
        public BDDSingleton()
        {
            BDD = new BDDBibliotheque();
            BDD.Database.EnsureCreated();
            BDD.Auteurs.Load();
            Auteurs = new ReadOnlyObservableCollection<Auteur>(BDD?.Auteurs.Local.ToObservableCollection());
            BDD.Clients.Load();
            Clients = new ReadOnlyObservableCollection<clsClient>(BDD?.Clients.Local.ToObservableCollection());
            BDD.Ecrire.Load();
            Ecrire = new ReadOnlyObservableCollection<Ecrire>(BDD?.Ecrire.Local.ToObservableCollection());
            BDD.Emprunts.Load();
            Emprunts = new ReadOnlyObservableCollection<Emprunt>(BDD?.Emprunts.Local.ToObservableCollection());
            BDD.Livres.Load();
            Livres = new ReadOnlyObservableCollection<Livre>(BDD?.Livres.Local.ToObservableCollection());
            BDD.Villes.Load();
            Villes = new ReadOnlyObservableCollection<Ville>(BDD?.Villes.Local.ToObservableCollection());
        }
        #endregion

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        public Auteur AjouterAuteur(string nom, string prenom) { return BDD?.AjouterAuteur(nom, prenom); }
        public clsClient AjouterClient(string nom, string prenom, Ville ville, string rueNumero) { return BDD?.AjouterClient(nom, prenom, ville, rueNumero); }
        public Ecrire AjouterEcrire(Auteur auteur, Livre livre) { return BDD?.AjouterEcrire(auteur, livre); }
        public Emprunt AjouterEmprunt(DateTime dateEmprunt, clsClient client, Livre livre) { return BDD?.AjouterEmprunt(dateEmprunt, client, livre); }
        public Livre AjouterLivre(string titre, DateTime dateAchat) { return BDD?.AjouterLivre(titre, dateAchat); }
        public Ville AjouterVille(string nom, string codePostal) { return BDD?.AjouterVille(nom, codePostal); }

        public void SupprimerAuteur(Auteur auteur) { BDD?.SupprimerAuteur(auteur); }
        public void SupprimerClient(clsClient client) { BDD?.SupprimerClient(client); }
        public void SupprimerEcrire(Ecrire ecrire) { BDD?.SupprimerEcrire(ecrire); }
        public void SupprimerEmprunt(Emprunt emprunt) { BDD?.SupprimerEmprunt(emprunt); }
        public void SupprimerLivre(Livre livre) { BDD?.SupprimerLivre(livre); }
        public void SupprimerVille(Ville ville) { BDD?.SupprimerVille(ville); }
        #endregion

        #region Méthodes effectuant des modifications/actions plus spécifiques sur les données
        public void SauvegarderModifications() { BDD?.SaveChanges(); }
        #endregion
    }
}
