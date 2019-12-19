using ProjetB2CSharpPlage.VM;
using ProjetB2CSharpPlage.DAL;
using ProjetB2CSharpPlage.ORM;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjetB2CSharpPlage.Vue
{
    /// <summary>
    /// Logique d'interaction pour AfficherPageConnexion.xaml
    /// </summary>
    public partial class AfficherPageConnexion : Page
    {
        UtilisateurViewModel myDataObject;
        UtilisateurDAL u = new UtilisateurDAL();
        public AfficherPageConnexion()
        {
            InitializeComponent();
        }
        private void connexion_Click(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            myDataObject = UtilisateurORM.getUtilisateur(login.Text);
            if (login.Text == myDataObject.loginUtilisateurProperty && UtilisateurDAL.hash(password.Password) == myDataObject.passwordUtilisateurProperty && myDataObject.roleUtilisateurProperty == 1) //Log des admins
            {
                window.Content = new AfficherInterfaceAdministrateur();
            }
            else if (login.Text == myDataObject.loginUtilisateurProperty && UtilisateurDAL.hash(password.Password) == myDataObject.passwordUtilisateurProperty && myDataObject.roleUtilisateurProperty == 0) //Log des utilisateurs
            {
                window.Content = new AfficherInterfaceUtilisateur();
            }
            else
            {
                window.Content = new AfficherPageMauvaisLogin();
            }
        }
    }
}
