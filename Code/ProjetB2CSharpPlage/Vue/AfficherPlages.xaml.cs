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
    /// Logique d'interaction pour AfficherPlage.xaml
    /// </summary>
    public partial class AfficherPlages : Page
    {
        int selectedPlageId;
        PlageViewModel myDataObject;
        PlageDAL c = new PlageDAL();
        ObservableCollection<PlageViewModel> lu;
        public AfficherPlages()
        {
            InitializeComponent();
            lu = PlageORM.listePlages();
            listePlages.ItemsSource = lu;
            myDataObject = new PlageViewModel();
        }
        private void ajouterPlage_Click(object sender, EventArgs e)
        {
            myDataObject.nomPlageProperty = Nom.Text;
            string CommuneIdToParse = Commune.Text;
            int result;
            int defaultValue = 1; //si la string est abhérente, la commune par défaut est 1 -> mauvaisNumDépartement
            myDataObject.communePlage = CommuneORM.getCommune(int.TryParse(CommuneIdToParse, out result) ? result : defaultValue);
            string valueToParse = nbEspeces.Text;
            defaultValue = 0;
            myDataObject.nbEspecesDifferentesPlageProperty = int.TryParse(valueToParse, out result) ? result : defaultValue;
            valueToParse = surface.Text;
            float result2;
            float defaultValue2 = 0.0F;
            myDataObject.surfacePlageProperty = float.TryParse(valueToParse, out result2) ? result2 : defaultValue2;
            PlageViewModel nouveau = new PlageViewModel(PlageDAL.getMaxIdPlage() + 1, myDataObject.nomPlageProperty, myDataObject.communePlage, myDataObject.nbEspecesDifferentesPlageProperty, myDataObject.surfacePlageProperty);
            lu.Add(nouveau);
            PlageORM.insertPlage(nouveau);
            listePlages.Items.Refresh();
        }
        private void supprimerButton_Click(object sender, EventArgs e)
        {
            PlageViewModel toRemove = (PlageViewModel)listePlages.SelectedItem;
            lu.Remove(toRemove);
            listePlages.Items.Refresh();
            PlageORM.supprimerPlage(selectedPlageId);
        }
        private void listePlages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePlages.SelectedIndex < lu.Count) && (listePlages.SelectedIndex >= 0))
            {
                selectedPlageId = (lu.ElementAt<PlageViewModel>(listePlages.SelectedIndex)).idPlageProperty;
            }
        }
        private void redirectButton_Accueil(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherInterfaceAdministrateur();
        }
    }
}
