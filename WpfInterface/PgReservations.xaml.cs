using BibliRestaurant;
using System;
using System.Collections.Generic;
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
using Xceed;

namespace WpfInterface
{
    public partial class PgReservations : Page
    {
        BDDSingleton _bdd = BDDSingleton.Instance;
        ICollectionView _listeReservations;

        public PgReservations()
        {
            InitializeComponent();
            _listeReservations = CollectionViewSource.GetDefaultView(_bdd.Reservations);
            grpListeReservations.DataContext = _listeReservations;
        }


        private void AjouterReservation(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvReservations.SelectedItem = _bdd.AjouterReservation("Doe", "John"); }, nameof(AjouterReservation));
        }


        private void SupprimerReservation(object sender, RoutedEventArgs e)
        {
            Reservation selection = (Reservation)lvReservations.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer la Reservation {selection.NomPrenom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerReservation(selection); }, nameof(SupprimerReservation));
                }
            }
        }



        #region Mécanisme de tri des données dans le listview
        GridViewColumnHeader _sortColumnHeader = null;
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private void OnClick(object sender, RoutedEventArgs args)
        {
            var ColumnHeader = sender as GridViewColumnHeader;
            //Sort the data based on the column selected
            _listeReservations.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeReservations.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion

        #region Mécanisme de filtres des données dans le listview
        private void OnFiltrerAucunFiltre(object sender, RoutedEventArgs args)
        {
            _listeReservations.Filter = null;
        }
        private void OnFiltrerPlusDe4Personnes(object sender, RoutedEventArgs args)
        {
            _listeReservations.Filter = (obj => { return (obj as Reservation).NombrePersonnes >= 4 ; });
        }
        private void OnFiltrerParZoneTerasse(object sender, RoutedEventArgs args)
        {
            _listeReservations.Filter = (obj => { return (obj as Reservation).ZoneRestaurant == Zones.Térasse ; });
        }


        private void OnFiltrerParTypeDePlatAfricain(object sender, RoutedEventArgs args)
        {
            _listeReservations.Filter = (obj => { return (obj as Reservation).TypeDeMenu == TypePlat.Africain; });
        }
      



       /* private void OnFiltrerLeMoisSuivant(object sender, RoutedEventArgs args)
        {
            _listeReservations.Filter = (obj => { return (obj as Reservation).TpsRestant ; });
        }
       
       */


    }
}
#endregion,