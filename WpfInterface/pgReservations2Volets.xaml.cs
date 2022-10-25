using BibliRestaurant;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfInterface
{

    public partial class pgReservations2Volets : Page
    {
        BDDSingleton _bdd = BDDSingleton.Instance;
        ICollectionView _listeReservations;
        public pgReservations2Volets()
        {
            InitializeComponent();
            _listeReservations = CollectionViewSource.GetDefaultView(_bdd.Reservations);
            _listeReservations.SortDescriptions.Add(new SortDescription(nameof(Reservation.Resume), ListSortDirection.Ascending));

            grpListeReservations.DataContext = _listeReservations;
            if (_listeReservations.Cast<Reservation>()?.Count() > 0) { lstReservations.SelectedItem = _listeReservations.Cast<Reservation>().First(); }

            //Inscription d'une méthode à l'évènement CollectionChanged de la liste.
            _listeReservations.CollectionChanged += _listeReservations_CollectionChanged;
        }

        private void AjouterReservation(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lstReservations.SelectedItem = _bdd.AjouterReservation("Doe", "John"); }, nameof(AjouterReservation));
        }


        private void SupprimerReservation(object sender, RoutedEventArgs e)
        {
            Reservation selection = (Reservation)lstReservations.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer la Reservation {selection.NomPrenom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerReservation(selection); }, nameof(SupprimerReservation));
                }
            }
   
        }
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstReservations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (lstReservations.SelectedItem != null) { grpReservation.DataContext = (Reservation)lstReservations.SelectedItem; }
        }
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _listeReservations_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
          
            if (_listeReservations.Cast<Reservation>()?.Count() > 0)
            {
                if (e.Action == NotifyCollectionChangedAction.Add) { lstReservations.SelectedItem = _listeReservations.Cast<Reservation>().Last(); }
                else if (e.Action == NotifyCollectionChangedAction.Remove) { }
                else { lstReservations.SelectedItem = _listeReservations.Cast<Reservation>().First(); }
            }
            else { grpReservation.DataContext = null; }
        }





        private void OnFiltrerAucunFiltre(object sender, RoutedEventArgs args)
        {
            _listeReservations.Filter = null;
        }
        private void OnFiltrerPlusDe2Personnes(object sender, RoutedEventArgs args)
        {
            _listeReservations.Filter = (obj => { return (obj as Reservation).NombrePersonnes >= 2; });
        }
        private void OnFiltrerParZoneTerasse(object sender, RoutedEventArgs args)
        {
            _listeReservations.Filter = (obj => { return (obj as Reservation).ZoneRestaurant == Zones.Térasse; });
        }


        private void OnFiltrerParTypeDePlatAfricain(object sender, RoutedEventArgs args)
        {
            _listeReservations.Filter = (obj => { return (obj as Reservation).TypeDeMenu == TypePlat.Africain; });
        }


    }
}
