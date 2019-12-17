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
    /// Logique d'interaction pour AfficherDepartement.xaml
    /// </summary>
    public partial class AfficherDepartements : Page
    {
        int selectedDepartementId;
        DepartementViewModel myDataObject;
        DepartementDAL c = new DepartementDAL();
        ObservableCollection<DepartementViewModel> lu;
        public AfficherDepartements()
        {
            InitializeComponent();
            lu = DepartementORM.listeDepartements();
            listeDepartements.ItemsSource = lu;
            myDataObject = new DepartementViewModel();
        }
        private void ajouterDepartement_Click(object sender, EventArgs e)
        {
            myDataObject.nomDepartementProperty = Nom.Text;
            string valueToParse = NumeroDepartement.Text;
            int result;
            int defaultValue = 0;
            myDataObject.numeroDepartementProperty = int.TryParse(valueToParse, out result) ? result : defaultValue;
            DepartementViewModel nouveau = new DepartementViewModel(DepartementDAL.getMaxIdDepartement() + 1, myDataObject.nomDepartementProperty, myDataObject.numeroDepartementProperty);
            lu.Add(nouveau);
            DepartementORM.insertDepartement(nouveau);
            listeDepartements.Items.Refresh();
        }
        private void supprimerButton_Click(object sender, EventArgs e)
        {
            DepartementViewModel toRemove = (DepartementViewModel)listeDepartements.SelectedItem;
            lu.Remove(toRemove);
            listeDepartements.Items.Refresh();
            DepartementORM.supprimerDepartement(selectedDepartementId);
        }
        private void listeDepartements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeDepartements.SelectedIndex < lu.Count) && (listeDepartements.SelectedIndex >= 0))
            {
                selectedDepartementId = (lu.ElementAt<DepartementViewModel>(listeDepartements.SelectedIndex)).idDepartementProperty;
            }
        }
        private void redirectButton_Accueil(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherInterfaceAdministrateur();
        }
    }
}
