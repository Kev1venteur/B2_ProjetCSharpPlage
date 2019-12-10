using ProjetB2CSharpPlage.Ctrl;
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
        public AfficherEtudes()
        {
            InitializeComponent();
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
            //////////////////////////////////////////////////id équipe
            string EquipeIdToParse = idEquipe.Text;
            int result;
            int defaultValue = 1; //si la string est abhérente, la equipe par défaut est 1 -> mauvaisNumDépartement
            myDataObject.equipeEtude = EquipeORM.getEquipe(int.TryParse(EquipeIdToParse, out result) ? result : defaultValue);
            //////////////////////////////////////////////////nombre especes
            string valueToParse = nbEspeces.Text;
            defaultValue = 0;
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
            listeEtudes.Items.Refresh();
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
            window.Content = new AfficherInterfaceSelection();
        }
    }
}
