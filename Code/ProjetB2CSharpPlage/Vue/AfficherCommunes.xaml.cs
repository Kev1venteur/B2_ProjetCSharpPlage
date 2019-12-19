using ProjetB2CSharpPlage.VM;
using ProjetB2CSharpPlage.DAL;
using ProjetB2CSharpPlage.ORM;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjetB2CSharpPlage.Vue
{
    /// <summary>
    /// Logique d'interaction pour AfficherCommune.xaml
    /// </summary>
    public partial class AfficherCommunes : Page
    {
        int selectedCommuneId;
        CommuneViewModel myDataObject;
        CommuneDAL c = new CommuneDAL();
        ObservableCollection<CommuneViewModel> lu;
        ObservableCollection<DepartementViewModel> lp;
        public AfficherCommunes()
        {
            InitializeComponent();
            lu = CommuneORM.listeCommunes();
            listeCommunes.ItemsSource = lu;
            myDataObject = new CommuneViewModel();
            lp = DepartementORM.listeDepartements();
            listeDepartementsCombo.ItemsSource = lp;
        }
        private void ajouterCommune_Click(object sender, EventArgs e)
        {
            myDataObject.nomCommuneProperty = Nom.Text;
            if ((DepartementViewModel)listeDepartementsCombo.SelectedItem != null)
            {
                myDataObject.departementCommune = (DepartementViewModel)listeDepartementsCombo.SelectedItem;
            }
            else
            {
                myDataObject.departementCommune = new DepartementViewModel(1, "MauvaisNumeroDepartement", 0);
            }
            CommuneViewModel nouveau = new CommuneViewModel(CommuneDAL.getMaxIdCommune() + 1, myDataObject.nomCommuneProperty, myDataObject.departementCommune);
            lu.Add(nouveau);
            CommuneORM.insertCommune(nouveau);
            listeDepartementsCombo.ItemsSource = lp;
            listeCommunes.Items.Refresh();
            listeDepartementsCombo.Items.Refresh();
            listeCommunes.ItemsSource = lu;
        }
        private void supprimerButton_Click(object sender, EventArgs e)
        {
            CommuneViewModel toRemove = (CommuneViewModel)listeCommunes.SelectedItem;
            lu.Remove(toRemove);
            listeCommunes.Items.Refresh();
            CommuneORM.supprimerCommune(selectedCommuneId);
        }
        private void listeCommunes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeCommunes.SelectedIndex < lu.Count) && (listeCommunes.SelectedIndex >= 0))
            {
                selectedCommuneId = (lu.ElementAt<CommuneViewModel>(listeCommunes.SelectedIndex)).idCommuneProperty;
            }
        }
        private void redirectButton_Accueil(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherInterfaceAdministrateur();
        }
    }
}
