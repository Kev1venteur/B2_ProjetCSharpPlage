using ProjetB2CSharpPlage.DAL;
using ProjetB2CSharpPlage.ORM;
using ProjetB2CSharpPlage.VM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProjetB2CSharpPlage.Vue
{
    /// <summary>
    /// Logique d'interaction pour AfficherUtilisateurHasEquipe.xaml
    /// </summary>
    public partial class AfficherUtilisateurHasEquipe : Page
    {
        int idEquipe_selectedUtilisateurHasEquipe;
        int idUtilisateur_selectedUtilisateurHasEquipe;
        UtilisateurHasEquipeViewModel myDataObjectUtilisateurHasEquipe;
        ObservableCollection<UtilisateurViewModel> lp;
        ObservableCollection<UtilisateurHasEquipeViewModel> lue;
        ObservableCollection<EquipeViewModel> le;
        public AfficherUtilisateurHasEquipe()
        {
            InitializeComponent();
            lp = UtilisateurORM.listeUtilisateurs();
            lue = UtilisateurHasEquipeORM.listeUtilisateurHasEquipes();
            le = EquipeORM.listeEquipes();
            listeUtilisateursHasEquipe.ItemsSource = lue;
            myDataObjectUtilisateurHasEquipe = new UtilisateurHasEquipeViewModel();
            EquipeComboBox.ItemsSource = le;
            UtilisateurComboBox.ItemsSource = lp;
        }
        private void redirectButton_Accueil(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherInterfaceAdministrateur();
        }
        private void ajouterButton(object sender, RoutedEventArgs e)
        {
            myDataObjectUtilisateurHasEquipe.Utilisateur_UtilisateurHasEquipeProperty = (UtilisateurViewModel)UtilisateurComboBox.SelectedItem;
            myDataObjectUtilisateurHasEquipe.Equipe_UtilisateurHasEquipeProperty = (EquipeViewModel)EquipeComboBox.SelectedItem;

            UtilisateurHasEquipeViewModel newUE = new UtilisateurHasEquipeViewModel(myDataObjectUtilisateurHasEquipe.Utilisateur_UtilisateurHasEquipeProperty, myDataObjectUtilisateurHasEquipe.Equipe_UtilisateurHasEquipeProperty);
            lue.Add(newUE);
            UtilisateurHasEquipeORM.insertUtilisateurHasEquipe(newUE);
            listeUtilisateursHasEquipe.Items.Refresh();
        }
        private void supprimerButton_Click(object sender, RoutedEventArgs e)
        {
            UtilisateurHasEquipeViewModel toRemove = (UtilisateurHasEquipeViewModel)listeUtilisateursHasEquipe.SelectedItem;
            lue.Remove(toRemove);
            listeUtilisateursHasEquipe.Items.Refresh();
            UtilisateurHasEquipeORM.supprimerUtilisateurHasEquipe(idUtilisateur_selectedUtilisateurHasEquipe, idEquipe_selectedUtilisateurHasEquipe);
        }
        private void listeUtilisateursHasEquipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeUtilisateursHasEquipe.SelectedIndex < lue.Count) && (listeUtilisateursHasEquipe.SelectedIndex >= 0))
            {
                idUtilisateur_selectedUtilisateurHasEquipe = (lue.ElementAt<UtilisateurHasEquipeViewModel>(listeUtilisateursHasEquipe.SelectedIndex)).Utilisateur_UtilisateurHasEquipeProperty.idUtilisateurProperty;
                idEquipe_selectedUtilisateurHasEquipe = (lue.ElementAt<UtilisateurHasEquipeViewModel>(listeUtilisateursHasEquipe.SelectedIndex)).Equipe_UtilisateurHasEquipeProperty.idEquipeProperty;
            }
        }
    }
}
