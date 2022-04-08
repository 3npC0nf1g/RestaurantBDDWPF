
using System;

namespace BibliRestaurant 
{
    public class Reservation
    {

        /// Champ statique en lecture seule (readonly) avec valeur par défaut.
        /// Assimilable à une constante.
        /// Le champ est marqué comme statique (static) et n'existe donc qu'une seule fois en mémoire (et non une fois par objet).
        /// Un champ statique s'appelle directement depuis le nom de la classe, ici : Personne.NombreFeticheMIN par exemple.
        /// </summary>
        ///  public DateTime DateHeure { get; set; }
        public static readonly DateTime DateReservationMIN = DateTime.Now;
         public static readonly byte NombreFeticheMIN = 1;
         public static readonly byte NombreFeticheMAX = 99;
        public static readonly byte NumeroTelephoneLongueurMIN = 11;

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
        public Zones Zone { get; set; }
        #endregion

        #region Propriétés
        //Propriété en accès complet et son champ d'arrière-plan avec restriction à une plage de valeurs définie
        private DateTime _dateReservation = DateTime.Now;
        public DateTime DateReservation {
            get => _dateReservation;

            set
            {
                if (value < DateTime.Now) { value = DateTime.Now; }
                else if (value > DateReservationMIN) { value = DateReservationMIN; }
                _dateReservation = value;
            }
        }

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
         private byte _nombreFetiche = NombreFeticheMIN;
        public byte NombreFetiche
        {
            get => _nombreFetiche;
            set
            {
                if (value < NombreFeticheMIN || value > NombreFeticheMAX) { throw new ArgumentException($"Le nombre fétiche doit être compris entre {NombreFeticheMIN} et {NombreFeticheMAX}."); }

                _nombreFetiche = value;
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
      

        //L'information est juste calculée et non stockée donc le type int ne pose pa de problème (au lieu de byte)
        // public int TpsRestant => DateTime.Now.Year - DateNaissance.Year - (DateTime.Now.Month < DateNaissance.Month ? 1 : 0) - (DateTime.Now.Month == DateNaissance.Month && DateTime.Now.Day < DateNaissance.Day ? 1 : 0);
        #endregion
        public int TpsRestant => DateReservation.Year - DateTime.Now.Year - (DateReservation.Month < DateTime.Now.Month ? 1 : 0) - (DateTime.Now.Month == DateReservation.Month && DateReservation.Day < DateTime.Now.Day ? 1 : 0);


        #region Propriétés Details et Resume de l'objet et réécriturre de la méthode ToString()
        //Propriété statique utilisée dans une application console comme entête pour l'affichage des données des personnes.
        public static string DetailsEntetes{
            get{
                string Resultat = $"\n|{"Nom et prénom",-22}|{"Nombre ",-5}|{"Date du RDV",-15}|{"Temps restant",-5} |{"Zone ",-20} |{"Téléphone",-15}|{"E-mail",-30}|{"Nombre fétiche",-14}|\n";
                Resultat = Resultat.PadRight(2 * Resultat.Length - 2, '-');
                return Resultat;
            }
        }
        public string Details => $"|{NomPrenom,-22}|{NombrePersonnes,-5}|{DateReservation,-15:dd-MM-yyyy}|{TpsRestant,-5}|{Zone.GetDescription(),-20}|{NumeroTelephone,-15}|{Email,-30}|{NombreFetiche,-14}|";
        public string Resume => $"{NomPrenom}{NombrePersonnes}{DateReservation}({Zone.GetDescription()})";
        public override string ToString() => Details; //Réécriture (override) de la méthode ToString de conversion d'un objet en chaine de caractères.
        #endregion


        #region Ajout d'un identifiant pour le projet Entity Framework Core
        public int ID { get; set; }
        #endregion
    }
}






