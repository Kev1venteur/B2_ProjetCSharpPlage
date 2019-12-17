using ProjetB2CSharpPlage.Ctrl;
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
        public AfficherCommunes()
        {
            InitializeComponent();
            lu = CommuneORM.listeCommunes();
            listeCommunes.ItemsSource = lu;
            myDataObject = new CommuneViewModel();
        }
        private void ajouterCommune_Click(object sender, EventArgs e)
        {
            myDataObject.nomCommuneProperty = Nom.Text;
            string DepartementIdToParse = Departement.Text;
            int defaultValue = 1; //si la string est abhérente, le département par défaut est 1 -> mauvaisNumDépartement
            int result;
            myDataObject.departementCommune = DepartementORM.getDepartement(int.TryParse(DepartementIdToParse, out result) ? result : defaultValue);
            CommuneViewModel nouveau = new CommuneViewModel(CommuneDAL.getMaxIdCommune() + 1, myDataObject.nomCommuneProperty, myDataObject.departementCommune);
            lu.Add(nouveau);
            CommuneORM.insertCommune(nouveau);
            listeCommunes.Items.Refresh();
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
