
using System;

namespace BibliRestaurant
{
    public class Reservation : IComparable, IComparable<Reservation>
    {

       
        public static readonly DateTime DateReservationMAX = DateTime.Today.AddYears(1);
        public static readonly byte NuméroTableMIN = 1;
        public static readonly byte NuméroTableMAX = 50;
        public static readonly byte NumeroTelephoneLongueurMIN = 11;
        public static readonly byte PlaceParkingMIN = 1;
        public static readonly byte PlaceParkingMAX = 30;
        public static readonly byte NombrePersonnesMIN = 1;
        public static readonly byte NombrePersonnesMAX = 8;


        #region Propriétés automatiques
       

        public string NomPrenom { get; set; }

        public Zones ZoneRestaurant { get; set; }
        public TypePlat TypeDeMenu { get; set; }
        public Décor ChoixDuDécor { get; set; }
        #endregion

        #region Propriétés
        
        private DateTime _dateReservation = DateTime.Today.AddDays(1);
        public DateTime DateReservation
        {
            get => _dateReservation;

            set
            {
                if (value < DateTime.Today.AddDays(1)) { value = DateTime.Today.AddDays(1); }
                else if (value > DateReservationMAX) { value = DateReservationMAX; }
                _dateReservation = value;
            }
        }

       
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

        private string _adresse = string.Empty;
        public string Adresse
        {
            get => _adresse;
            set

            {
                if (value == null || value == string.Empty) { throw new ArgumentNullException("L'adresse ne peut pas être une valeur vide !"); }
                if (!value.Contains("BP")) { throw new ArgumentException("L'adresse doit contenir un BP !"); }
                _adresse = value;
            }
        }
       
        private byte _numéroTable = NuméroTableMIN;
        public byte NuméroTable
        {
            get => _numéroTable;
            set
            {
                if (value < NuméroTableMIN || value > NuméroTableMAX) { throw new ArgumentException($"Le numéro de table doit être compris entre {NuméroTableMIN} et {NuméroTableMAX}."); }

                _numéroTable = value;
            }
        }
        private byte _placeparking = PlaceParkingMIN;
        public byte PlaceParking
        {
            get => _placeparking;
            set
            {
                if (value < PlaceParkingMIN || value > PlaceParkingMAX) { throw new ArgumentException($"La place doit être comprise entre {PlaceParkingMIN} et {PlaceParkingMAX}."); }

                _placeparking = value;
            }
        }
        private byte _nombrepersonnes = NombrePersonnesMIN;
        public byte NombrePersonnes
        {
            get => _nombrepersonnes;
            set
            {
                if (value < NombrePersonnesMIN || value > NombrePersonnesMAX) { throw new ArgumentException($"Le numéro de personne doit être compris entre {NombrePersonnesMIN} et {NombrePersonnesMAX}."); }

                _nombrepersonnes = value;
            }
        }
        
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

        #endregion
      
        public int TpsRestant => (((DateReservation.Year - DateTime.Now.Year) * 365) + ((DateReservation.Month - DateTime.Now.Month) * 30) + (DateReservation.Day - DateTime.Now.Day));

       



        #region Propriétés Details et Resume de l'objet et réécriturre de la méthode ToString()
       
        public static string DetailsEntetes
        {
            get
            {
                string Resultat = $"\n|{"Nom et prénom",-22}|{"Nombre ",-7}|{"Date et Heure",-16}|{"Jours restants",-16} |{"Numéro de table",-15}|{"Zone ",-20}|{"Décor choisit",-15}|{"Menu choisit",-15}|{"Adresse",-32}|{"Téléphone",-15}|{"E-mail",-30}|{"parking",-7}|\n";
                Resultat = Resultat.PadRight(2 * Resultat.Length - 2, '-');
                return Resultat;
            }
        }
        public string Details => $"|{NomPrenom,-22}|{NombrePersonnes,-7}|{DateReservation,-14:dd/MM/yyyy HH:mm}|{TpsRestant,-17}|{NuméroTable,-15}|{ZoneRestaurant.GetDescription(),-20}|{ChoixDuDécor,-15}|{TypeDeMenu,-15}|{Adresse,-32}|{NumeroTelephone,-15}|{Email,-30}|{PlaceParking,-7}|";
        public string Resume => $"{NomPrenom}{NombrePersonnes}{DateReservation}({ZoneRestaurant.GetDescription()})";
        public override string ToString() => Details; 
        #endregion


        #region Implémentation de l'interface IComparable
        
        /// <param name="other">Autre objet personne qui sera comparé</param>
       
        public int CompareTo(Reservation other)
        {
            if (other == null) { return 1; }
            else if (this.ZoneRestaurant > other.ZoneRestaurant) { return 1; }
            else if (this.ZoneRestaurant < other.ZoneRestaurant) { return -1; }
            else
            {
                if (this.NombrePersonnes > other.NombrePersonnes) { return 1; }
                else if (this.NombrePersonnes < other.NombrePersonnes) { return -1; }
                else { return this.TpsRestant.CompareTo(other.TpsRestant); }
            }
        }
        public int CompareTo(object obj) => CompareTo(obj as Reservation);
        #endregion

        #region Ajout d'un identifiant pour le projet Entity Framework Core
        public int ID { get; set; }
        #endregion
    }
}






