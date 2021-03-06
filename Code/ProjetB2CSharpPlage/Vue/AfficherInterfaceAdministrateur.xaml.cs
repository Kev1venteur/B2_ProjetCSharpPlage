﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjetB2CSharpPlage.Vue
{
    /// <summary>
    /// Logique d'interaction pour AfficherInterfaceAdministrateur.xaml
    /// </summary>
    public partial class AfficherInterfaceAdministrateur : Page
    {
        public AfficherInterfaceAdministrateur()
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
        private void redirectButton_ZonesPrelevements(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherZonePrelevements();
        }
        private void redirectButton_Departements(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherDepartements();
        }
        private void redirectButton_Communes(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherCommunes();
        }
        private void redirectButton_Especes(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherEspeces();
        }
        private void redirectButton_Plages(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherPlages();
        }
        private void redirectButton_UE(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherUtilisateurHasEquipe();
        }
        private void redirectButton_Etudes(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherEtudes();
        }
    }
}
