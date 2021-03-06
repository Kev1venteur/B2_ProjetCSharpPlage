﻿using ProjetB2CSharpPlage.VM;
using ProjetB2CSharpPlage.DAL;
using ProjetB2CSharpPlage.ORM;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ProjetB2CSharpPlage.Vue
{
    /// <summary>
    /// Logique d'interaction pour AfficherEtudes.xaml
    /// </summary>
    public partial class AfficherEtudes : Page
    {
        int selectedEtudeId;
        EtudeViewModel myDataObject;
        EtudeDAL c = new EtudeDAL();
        ObservableCollection<EtudeViewModel> lu;
        ObservableCollection<EquipeViewModel> lp;
        public AfficherEtudes()
        {
            InitializeComponent();
            lp = EquipeORM.listeEquipes();
            listeEquipeCombo.ItemsSource = lp;
            lu = EtudeORM.listeEtudes();
            listeEtudes.ItemsSource = lu;
            myDataObject = new EtudeViewModel();
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }
        private void ajouterEtude_Click(object sender, EventArgs e)
        {
            myDataObject.titreEtudeProperty = Titre.Text;
            if((EquipeViewModel)listeEquipeCombo.SelectedItem != null)
            {
                myDataObject.equipeEtude = (EquipeViewModel)listeEquipeCombo.SelectedItem;
            }
            else
            {
                myDataObject.equipeEtude = new EquipeViewModel(1, "MauvaisNumeroEquipe", 0);
            }
            //////////////////////////////////////////////////nombre especes
            string valueToParse = nbEspeces.Text;
            int result;
            int defaultValue = 0;
            myDataObject.nbTotalEspeceRencontreeEtudeProperty = int.TryParse(valueToParse, out result) ? result : defaultValue;
            //////////////////////////////////////////////////date
            string valueToParse2 = Date.Text;
            DateTime result2;
            DateTime defaultValue2 = DateTime.Now;
            myDataObject.dateEtudeProperty = DateTime.TryParse(valueToParse2, out result2) ? result2 : defaultValue2;
            //////////////////////////////////////////////////insert
            EtudeViewModel nouveau = new EtudeViewModel(EtudeDAL.getMaxIdEtude() + 1, myDataObject.dateEtudeProperty, myDataObject.titreEtudeProperty, myDataObject.nbTotalEspeceRencontreeEtudeProperty, myDataObject.equipeEtudeProperty);
            lu.Add(nouveau);
            EtudeORM.insertEtude(nouveau);
            listeEquipeCombo.ItemsSource = lp;
            listeEtudes.Items.Refresh();
            listeEquipeCombo.Items.Refresh();
            listeEtudes.ItemsSource = lu;
        }
        private void supprimerButton_Click(object sender, EventArgs e)
        {
            EtudeViewModel toRemove = (EtudeViewModel)listeEtudes.SelectedItem;
            lu.Remove(toRemove);
            listeEtudes.Items.Refresh();
            EtudeORM.supprimerEtude(selectedEtudeId);
        }
        private void listeEtudes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEtudes.SelectedIndex < lu.Count) && (listeEtudes.SelectedIndex >= 0))
            {
                selectedEtudeId = (lu.ElementAt<EtudeViewModel>(listeEtudes.SelectedIndex)).idEtudeProperty;
            }
        }
        private void redirectButton_Accueil(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherInterfaceAdministrateur();
        }
    }
}
