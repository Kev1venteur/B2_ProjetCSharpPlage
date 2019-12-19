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
    /// Logique d'interaction pour AfficherEspece.xaml
    /// </summary>
    public partial class AfficherEspeces : Page
    {
        int selectedEspeceId;
        EspeceViewModel myDataObject;
        EspeceDAL c = new EspeceDAL();
        ObservableCollection<EspeceViewModel> lu;
        public AfficherEspeces()
        {
            InitializeComponent();
            lu = EspeceORM.listeEspeces();
            listeEspeces.ItemsSource = lu;
            myDataObject = new EspeceViewModel();
        }
        private void ajouterEspece_Click(object sender, EventArgs e)
        {
            myDataObject.nomEspeceProperty = Nom.Text;
            EspeceViewModel nouveau = new EspeceViewModel(EspeceDAL.getMaxIdEspece() + 1, myDataObject.nomEspeceProperty);
            lu.Add(nouveau);
            EspeceORM.insertEspece(nouveau);
            listeEspeces.Items.Refresh();
        }
        private void supprimerButton_Click(object sender, EventArgs e)
        {
            EspeceViewModel toRemove = (EspeceViewModel)listeEspeces.SelectedItem;
            lu.Remove(toRemove);
            listeEspeces.Items.Refresh();
            EspeceORM.supprimerEspece(selectedEspeceId);
        }
        private void listeEspeces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEspeces.SelectedIndex < lu.Count) && (listeEspeces.SelectedIndex >= 0))
            {
                selectedEspeceId = (lu.ElementAt<EspeceViewModel>(listeEspeces.SelectedIndex)).idEspeceProperty;
            }
        }
        private void redirectButton_Accueil(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherInterfaceAdministrateur();
        }
    }
}
