﻿using System;
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
    /// Logique d'interaction pour AfficherInterfaceSelection.xaml
    /// </summary>
    public partial class AfficherInterfaceSelection : Page
    {
        public AfficherInterfaceSelection()
        {
            InitializeComponent();
        }
        private void redirectButton_Equipes(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherEquipes();
        }
        private void redirectButton_Utilisateurs(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherUtilisateurs();
        }
        private void redirectButton_ZonesPrelevement(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherZonePrelevements();
        }
        private void redirectButton_Accueil(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherInterfaceSelection();
        }
    }
}