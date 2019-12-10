using System.Windows;
using ProjetB2CSharpPlage.Vue;
using ProjetB2CSharpPlage.DAL;

namespace ProjetB2CSharpPlage
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ConnexionBaseDAL.OpenConnection();
            InitializeComponent();
            this.Content = new AfficherPageConnexion();
        }
    }
}
