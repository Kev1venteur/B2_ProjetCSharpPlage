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
        }
        private void ajouterDepartement_Click(object sender, EventArgs e)
        {
            myDataObject = new DepartementViewModel();
            myDataObject.nomDepartementProperty = Nom.Text;
            DepartementViewModel nouveau = new DepartementViewModel(DepartementDAL.getMaxIdDepartement() + 1, myDataObject.nomDepartementProperty);
            lu.Add(nouveau);
            DepartementDAO.insertDepartement(nouveau);
            listeDepartements.Items.Refresh();
        }
        private void supprimerButton_Click(object sender, EventArgs e)
        {
            DepartementViewModel toRemove = (DepartementViewModel)listeDepartements.SelectedItem;
            lu.Remove(toRemove);
            listeDepartements.Items.Refresh();
            DepartementDAO.supprimerDepartement(selectedDepartementId);
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
            window.Content = new AfficherInterfaceSelection();
        }
    }
}
