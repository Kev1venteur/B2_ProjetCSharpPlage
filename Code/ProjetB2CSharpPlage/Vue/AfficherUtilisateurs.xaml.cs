using System;
using System.Linq;
using System.Windows.Controls;
using ProjetB2CSharpPlage.ORM;
using ProjetB2CSharpPlage.Ctrl;
using ProjetB2CSharpPlage.DAL;
using System.Collections.ObjectModel;
using System.Windows;

namespace ProjetB2CSharpPlage.Vue
{
    /// <summary>
    /// Logique d'interaction pour AfficherUtilisateurs.xaml
    /// </summary>
    public partial class AfficherUtilisateurs : Page
    {
        int selectedUtilisateurId;
        UtilisateurViewModel myDataObject;
        UtilisateurDAL c = new UtilisateurDAL();
        ObservableCollection<UtilisateurViewModel> lu;
        public AfficherUtilisateurs()
        {
            InitializeComponent();
            lu = UtilisateurORM.listeUtilisateurs();
            listeUtilisateurs.ItemsSource = lu;
            myDataObject = new UtilisateurViewModel();
        }
        private void ajouterUtilisateur_Click(object sender, EventArgs e)
        {
            myDataObject.nomUtilisateurProperty = Nom.Text;
            myDataObject.loginUtilisateurProperty = login.Text;
            myDataObject.passwordUtilisateurProperty = password.Text;

            string decimalValueToParse = isAdmin.Text;
            Byte result;
            Byte defaultValue = 0; //Par défaut l'utilisateur n'est pas admin
            myDataObject.roleUtilisateurProperty = Byte.TryParse(decimalValueToParse, out result) ? result : defaultValue;
            myDataObject.prenomUtilisateurProperty = Prenom.Text;
            UtilisateurViewModel nouveau = new UtilisateurViewModel(UtilisateurDAL.getMaxIdUtilisateur() + 1, myDataObject.nomUtilisateurProperty, myDataObject.prenomUtilisateurProperty, myDataObject.roleUtilisateurProperty, myDataObject.passwordUtilisateurProperty, myDataObject.loginUtilisateurProperty);
            lu.Add(nouveau);
            UtilisateurORM.insertUtilisateur(nouveau);
            listeUtilisateurs.Items.Refresh();
        }
        private void supprimerButton_Click(object sender, EventArgs e)
        {
            UtilisateurViewModel toRemove = (UtilisateurViewModel)listeUtilisateurs.SelectedItem;
            lu.Remove(toRemove);
            listeUtilisateurs.Items.Refresh();
            UtilisateurORM.supprimerUtilisateur(selectedUtilisateurId);
        }
        private void listeUtilisateurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeUtilisateurs.SelectedIndex < lu.Count) && (listeUtilisateurs.SelectedIndex >= 0))
            {
                selectedUtilisateurId = (lu.ElementAt<UtilisateurViewModel>(listeUtilisateurs.SelectedIndex)).idUtilisateurProperty;
            }
        }
        private void redirectButton_Accueil(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherInterfaceAdministrateur();
        }
    }
}
