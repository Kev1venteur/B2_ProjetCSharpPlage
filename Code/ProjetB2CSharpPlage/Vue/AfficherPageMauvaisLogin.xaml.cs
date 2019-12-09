using System;
using System.Collections.Generic;
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
