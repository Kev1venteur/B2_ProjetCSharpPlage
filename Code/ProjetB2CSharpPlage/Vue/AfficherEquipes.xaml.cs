using ProjetB2CSharpPlage.Ctrl;
using ProjetB2CSharpPlage.DAL;
using ProjetB2CSharpPlage.DAO;
using ProjetB2CSharpPlage.ORM;
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
        }
        private void ajouterEquipe_Click(object sender, EventArgs e)
        {
            myDataObject = new EquipeViewModel();
            myDataObject.nomEquipeProperty = Nom.Text;
            myDataObject.nombreMembresEquipeProperty = 0;
            EquipeViewModel nouveau = new EquipeViewModel(EquipeDAL.getMaxIdEquipe() + 1, myDataObject.nomEquipeProperty, myDataObject.nombreMembresEquipeProperty);
            lu.Add(nouveau);
            EquipeDAO.insertEquipe(nouveau);
            listeEquipes.Items.Refresh();
        }
        private void supprimerButton_Click(object sender, EventArgs e)
        {
            EquipeViewModel toRemove = (EquipeViewModel)listeEquipes.SelectedItem;
            lu.Remove(toRemove);
            listeEquipes.Items.Refresh();
            EquipeDAO.supprimerEquipe(selectedEquipeId);
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
            window.Content = new AfficherInterfaceSelection();
        }
    }
}
