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
    /// Logique d'interaction pour AfficherEquipes.xaml
    /// </summary>
    public partial class AfficherEquipes : Page
    {
        int selectedEquipeId;
        EquipeViewModel myDataObject;
        EquipeDAL c = new EquipeDAL();
        ObservableCollection<EquipeViewModel> lu;
        public AfficherEquipes()
        {
            InitializeComponent();
            lu = EquipeORM.listeEquipes();
            listeEquipes.ItemsSource = lu;
            myDataObject = new EquipeViewModel();
        }
        private void ajouterEquipe_Click(object sender, EventArgs e)
        {
            myDataObject.nomEquipeProperty = Nom.Text;
            myDataObject.nombreMembresEquipeProperty = 0; //On set le nombre de membre à  0 dès que l'on creer une équipe, il changera lors d'un select en compatnt le nombre d'entrées dans la table de liaison
            EquipeViewModel nouveau = new EquipeViewModel(EquipeDAL.getMaxIdEquipe() + 1, myDataObject.nomEquipeProperty, myDataObject.nombreMembresEquipeProperty);
            lu.Add(nouveau);
            EquipeORM.insertEquipe(nouveau);
            listeEquipes.Items.Refresh();
        }
        private void supprimerButton_Click(object sender, EventArgs e)
        {
            EquipeViewModel toRemove = (EquipeViewModel)listeEquipes.SelectedItem;
            lu.Remove(toRemove);
            listeEquipes.Items.Refresh();
            EquipeORM.supprimerEquipe(selectedEquipeId);
        }
        private void listeEquipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEquipes.SelectedIndex < lu.Count) && (listeEquipes.SelectedIndex >= 0))
            {
                selectedEquipeId = (lu.ElementAt<EquipeViewModel>(listeEquipes.SelectedIndex)).idEquipeProperty;
            }
        }
        private void redirectButton_Accueil(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherInterfaceAdministrateur();
        }
    }
}
