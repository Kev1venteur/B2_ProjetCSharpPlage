using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjetB2CSharpPlage.Vue
{
    /// <summary>
    /// Logique d'interaction pour AfficherPageMauvaisLogin.xaml
    /// </summary>
    public partial class AfficherPageMauvaisLogin : Page
    {
        public AfficherPageMauvaisLogin()
        {
            InitializeComponent();
        }

        private void redirectButton_LoginPage(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherPageConnexion();
        }
    }
}
