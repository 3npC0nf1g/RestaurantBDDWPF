using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace BibliRestaurant
{
    internal class BDDReservations : DbContext
    {
        #region Emplacement de la base de données
        internal static string Emplacement => Path.Combine(Directory.GetCurrentDirectory(), NomFichier);
        internal static string NomFichier { get; private set; } = "BDDReservation.db";
        #endregion

        #region Tables de la BDD
        internal DbSet<Reservation> Reservations { get; set; }
        #endregion

        #region Méthodes d'initialisation de la base de données
        
        internal BDDReservations() : base() { }
        
        internal BDDReservations(string nomFichier) : base() { NomFichier = nomFichier; }

        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlite($@"Data Source={Emplacement}");
        }

        
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Contraintes liées au modèle de la BDD

            #endregion

            #region Données présentes par défaut dans la BDD (lors de sa création uniquement)
            modelBuilder.Entity<Reservation>().HasData(
            new Reservation() { ID = 1, NomPrenom = "Fontaine Jesper", NombrePersonnes = 3, ZoneRestaurant = Zones.Entrée, DateReservation = new DateTime(2022, 8, 22,14,30,10), Email = "JesperFontaine@dayrep.com", NumeroTelephone = "+32484674671", NuméroTable = 25, Adresse = "Avenue Boziere 8 BP 7500 tournai", ChoixDuDécor = Décor.Africain, TypeDeMenu = TypePlat.Américain, PlaceParking = 2 },
            new Reservation() { ID = 2, NomPrenom = "Leroy Violette", NombrePersonnes = 5, ZoneRestaurant = Zones.PrèsDuBar, DateReservation = new DateTime(2023, 3, 26, 15, 20, 3), Email = "VioletteLeroy@fai.com", NumeroTelephone = "+32489691146", NuméroTable = 2, Adresse = "Rue  Piges 66 BP 7500 tournai", ChoixDuDécor = Décor.Asiatique, TypeDeMenu = TypePlat.Européen, PlaceParking = 10 },
            new Reservation() { ID = 3, NomPrenom = "Favreau Fantine", NombrePersonnes = 2, ZoneRestaurant = Zones.Entrée, DateReservation = new DateTime(2023, 2, 28, 10, 00, 5), Email = "FantinaFavreau@fai.com", NumeroTelephone = "+32473961004", NuméroTable = 17, Adresse = "Rue  Martin  8 BP 7500 tournai", ChoixDuDécor = Décor.Variété, TypeDeMenu = TypePlat.Américain, PlaceParking = 7 },
            new Reservation() { ID = 4, NomPrenom = "Flordelis Mathieu", NombrePersonnes = 7, ZoneRestaurant = Zones.Entrée, DateReservation = new DateTime(2022, 9, 26, 13, 15, 8), Email = "FlordelisMathieu@rhyta.com", NumeroTelephone = "+32494437781", NuméroTable = 9, Adresse = "Rue  Palais 44 BP 7500 tournai", ChoixDuDécor = Décor.Asiatique, TypeDeMenu = TypePlat.Européen, PlaceParking = 9 },
            new Reservation() { ID = 5, NomPrenom = "Mavise  Michel", NombrePersonnes = 6, ZoneRestaurant = Zones.PrèsDuBar, DateReservation = new DateTime(2022, 11, 4, 21, 30, 5), Email = "MaviseMichel@jourrapide.com", NumeroTelephone = "+32498935660", NuméroTable = 42, Adresse = "Boulevar Bara 22 BP 7500 tournai", ChoixDuDécor = Décor.Variété, TypeDeMenu = TypePlat.Variété, PlaceParking = 6},
            new Reservation() { ID = 6, NomPrenom = "Marcoux Désiré", NombrePersonnes = 4, ZoneRestaurant = Zones.Entrée, DateReservation = new DateTime(2022, 9, 3, 22, 30, 6), Email = "DesireMarcoux@jourrapide.com", NumeroTelephone = "+32476434966", NuméroTable = 07, Adresse = "Avenue Marie 6 BP 7500 tournai", ChoixDuDécor = Décor.Asiatique, TypeDeMenu = TypePlat.Africain, PlaceParking = 8 },
            new Reservation() { ID = 7, NomPrenom = "Ayot Jacques", NombrePersonnes = 3, ZoneRestaurant = Zones.PrèsDeLaSortie, DateReservation = new DateTime(2022, 12, 12, 19, 00, 6), Email = "JacquesAyot@dayrep.com", NumeroTelephone = "+32487510553", NuméroTable = 5, Adresse = "Rue Gilchrist 8 BP 7500 tournai", ChoixDuDécor = Décor.Africain, TypeDeMenu = TypePlat.Américain, PlaceParking = 9 },
            new Reservation() { ID = 8, NomPrenom = "Pannetier Percy",NombrePersonnes = 8, ZoneRestaurant = Zones.Mezzanine, DateReservation = new DateTime(2022, 6, 19, 23, 30, 4), Email = "PercyPanetier@rhyta.com", NumeroTelephone = "+32493876947", NuméroTable = 13, Adresse = "Avenue Hyme 3 BP 7500 tournai", ChoixDuDécor = Décor.Variété, TypeDeMenu = TypePlat.Européen, PlaceParking = 5 },
            new Reservation() { ID = 9, NomPrenom = "Boncoeur Christabel",NombrePersonnes = 3,ZoneRestaurant = Zones.PrèsDeLaSortie,DateReservation = new DateTime(2022, 9, 1, 13, 15, 3), Email = "ChristabelBoncoeur@fai.com", NumeroTelephone = "+32477986657", NuméroTable = 8, Adresse = "Rue Morel 34 BP 7500 tournai",ChoixDuDécor = Décor.Asiatique,TypeDeMenu = TypePlat.Européen, PlaceParking = 12 },
            new Reservation() { ID = 10, NomPrenom = "Paré Natalie", NombrePersonnes = 7, ZoneRestaurant = Zones.Entrée, DateReservation = new DateTime(2022, 6, 9, 14, 45, 9), Email = "NathaliePare@rhyta.com", NumeroTelephone = "+32488796427", NuméroTable = 32, Adresse = "Avenue Paul 31 BP 6000 charleroi", ChoixDuDécor = Décor.Africain, TypeDeMenu = TypePlat.Américain, PlaceParking = 13 },
            new Reservation() { ID = 11, NomPrenom = "Carolos Gabriel", NombrePersonnes = 5, ZoneRestaurant = Zones.Entrée, DateReservation = new DateTime(2022, 8, 17, 17, 00, 44), Email = "CarolosGabriaux@fai.com", NumeroTelephone = "+32474601722", NuméroTable = 5, Adresse = "Avenue Pierre 137 BP 7000 mons", ChoixDuDécor = Décor.Asiatique, TypeDeMenu = TypePlat.Américain, PlaceParking = 14 },
            new Reservation() { ID = 12, NomPrenom = "Rep  Aniel", NombrePersonnes = 3, ZoneRestaurant = Zones.PrèsDeLaSortie, DateReservation = new DateTime(2022, 12, 5, 20, 30, 7), Email = "AnielRep@touristsagency.com", NumeroTelephone = "+32473432452", NuméroTable = 41,Adresse = "Grand Place 12 BP 7500 tournai", ChoixDuDécor = Décor.Variété, TypeDeMenu = TypePlat.Variété, PlaceParking = 17 },
            new Reservation() { ID = 13, NomPrenom = "Levijn Gianna", NombrePersonnes = 2, ZoneRestaurant = Zones.PrèsDuBar, DateReservation = new DateTime(2022, 9, 29, 13, 30, 21), Email = "GiannaLevels@teleworm.be", NumeroTelephone = "+32485907086", NuméroTable = 5,Adresse = "Rue Dedrouin 7 BP 6000 charleroi", ChoixDuDécor = Décor.Africain, TypeDeMenu = TypePlat.Africain, PlaceParking = 19 },
            new Reservation() { ID = 14, NomPrenom = "Scholten Maxime", NombrePersonnes = 5, ZoneRestaurant = Zones.PrèsDeLaSortie, DateReservation = new DateTime(2022, 11, 3, 11, 15, 4), Email = "MaximeScholten@jourrapide.com", NumeroTelephone = "+32484716662",NuméroTable = 6,Adresse = "Rue Marein 42 BP 6000 charleroi", ChoixDuDécor = Décor.Asiatique, TypeDeMenu = TypePlat.Américain, PlaceParking = 20 },
            new Reservation() { ID = 15, NomPrenom = "Favreau Julie", NombrePersonnes = 6, ZoneRestaurant = Zones.Entrée, DateReservation = new DateTime(2022, 6, 15,17, 00, 4), Email = "JulieFavreau@rhyta.com", NumeroTelephone = "+32472225941", NuméroTable = 2, Adresse = "Avenue Boziere 7 BP 7500 tournai", ChoixDuDécor = Décor.Africain, TypeDeMenu = TypePlat.Européen, PlaceParking = 11 }
            ); ;
            #endregion
        }
        #endregion

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        internal Reservation AjouterReservation(string nomprenom)
        {
           
            if (nomprenom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterReservation)} : La personne doit avoir un nom et un prenom (valeur NULL ou chaine vide)."); }
            
            Reservation NouvelleReservation = new Reservation() { NomPrenom = nomprenom };
            Reservations.Local.Add(NouvelleReservation);
            return NouvelleReservation;
        }

        internal void SupprimerReservation(Reservation reservation)
        {
            
            if (reservation == null) { throw new ArgumentNullException($"{nameof(SupprimerReservation)} : Il faut une reservation en argument (valeur NULL)."); }

            
            Reservations.Local.Remove(reservation);
        }
        #endregion
    }
}
