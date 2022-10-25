
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BibliRestaurant;


namespace WpfInterface
{

    public partial class fenPrincipale : Window
    {
        private BDDSingleton _bdd = BDDSingleton.Instance;

        public fenPrincipale()
        {
            InitializeComponent();

          
            _bdd.ChargerDonnees();

            Cadre.NavigationService.Navigate(new PgReservations());
        }

        #region Méthodes liées au Menu du haut de la fenêtre
        private void AfficherVueDeuxVolets(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgReservations2Volets()); }
        private void AfficherVueListView(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new PgReservations()); }
        private void ChargerBaseDeDonnees(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog()
            {
                CheckPathExists = true,
                CheckFileExists = false,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                Multiselect = false,
                Title = "Charger ou créer une base de données",
                Filter = "Fichiers db (*.db)|*.db"
            };

          
            if (ofd.ShowDialog() == true)
            {
                if (System.IO.Path.GetDirectoryName(ofd.FileName) == Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData))
                {
                    _bdd.ChargerDonnees(ofd.FileName);
                    Cadre.NavigationService.Navigate(new PgReservations());
                }
                else { MessageBox.Show("Vous devez ouvrir/créer une base de données dans le dossier de l'application", "Attention !", MessageBoxButton.OK, MessageBoxImage.Warning); }
            }
        }
        private void Quitter(object sender, RoutedEventArgs e) { this.Close(); }
        private void SauvegarderModifications(object sender, RoutedEventArgs e)
        {
            _bdd.SauvegarderModifications();
            MessageBox.Show("Modifications sauvegardées dans la base de données.", "Sauvegarde des modifications", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion

       
        private void NavServiceOnNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e) { while (Cadre.NavigationService.RemoveBackEntry() != null) ; }
      
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_bdd.ModificationsEnAttente)
            {
                if (MessageBox.Show("Il y a des modifications en attente voulez vous les sauvegarder avant de quitter ?", "Application POOGestionReservations", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    if (MessageBox.Show("La fermeture de l'application va entrainer la perte des modifications non sauvegardées dans la base de données. Etes-vous sûr de vouloir fermer l'application?", "Application POOGestionReservations", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        e.Cancel = true;
                    }
                }
                else { _bdd.SauvegarderModifications(); }
            }
        }
    }
}
