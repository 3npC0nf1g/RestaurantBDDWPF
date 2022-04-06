
using System;

namespace BibliRestaurant
{
    public class Reservation
    {
        #region Propriétés automatiques
        //Il y a à chaque fois un champ (créé automatiquement et caché) en interaction derrière la propriété.
        /* Equivalent de (version non automatique) :
            private string _nom = "";
            public string Nom{
                get { return _nom; }
                set { _nom = value; }
            }
        */
        public string NomPrenom { get; set; }
        public byte NombrePersonnes { get; set; }
        public DateTime DateHeure { get; set; }
        public Zones Zone { get; set; }
        #endregion

        #region Propriétés
        //Propriété en accès complet et son champ d'arrière-plan avec contrôles de saisie (générant exceptions).
        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set
            {
                if (value == null || value == string.Empty) { throw new ArgumentNullException("L'email ne peut pas être une valeur vide !"); }
                if (!value.Contains("@")) { throw new ArgumentException("L'email doit contenir au moins un @ !"); }
                _email = value;
            }
        }

        //Propriété en accès complet et son champ d'arrière-plan avec contrôles de saisie (générant exceptions).
        private string _numeroTelephone = string.Empty;
        public string NumeroTelephone
        {
            get => _numeroTelephone;
            set
            {
                if (value == null || value == string.Empty) { throw new ArgumentNullException("Le numéro de téléphone ne peut pas être une valeur vide !"); }
                if (value.Length < 11) { throw new ArgumentException($"Le numéro de téléphone doit être de longueur 11 minimum !"); }
                if (value.IndexOf("0032") != 0 && value.IndexOf("+32") != 0) { throw new ArgumentException("Le numéro de téléphone doit commencer par 0032 ou +32 !"); }
                _numeroTelephone = value;
            }
        }

        //Propriétés en lecture seule avec écriture simplifiée.
        //Equivalent de :
        /*public string NomComplet{
            get { return $"{Nom} {Prenom}"; }
        }*/
      


        public string Details => $"{NomPrenom,-22} {DateHeure,-25} {NombrePersonnes,-5} {Zone.GetDescription(),-16} ";
        #endregion

        #region Ajout d'un identifiant pour le projet Entity Framework Core
        public int ID { get; set; }
        #endregion
    }
}
