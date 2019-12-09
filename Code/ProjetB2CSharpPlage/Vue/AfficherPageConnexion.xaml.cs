using ProjetB2CSharpPlage.Ctrl;
using ProjetB2CSharpPlage.DAL;
using ProjetB2CSharpPlage.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            if (login.Text == myDataObject.loginUtilisateurProperty && UtilisateurDAL.hash(password.Text) == myDataObject.passwordUtilisateurProperty)
            {
                window.Content = new AfficherInterfaceSelection();
            }
            else
            {
                window.Content = new AfficherPageMauvaisLogin();
            }
        }
    }
}
