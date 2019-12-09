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
using ProjetB2CSharpPlage.ORM;
using ProjetB2CSharpPlage.Ctrl;
using ProjetB2CSharpPlage.DAL;
using ProjetB2CSharpPlage.DAO;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.Vue
{
    /// <summary>
    /// Logique d'interaction pour AfficherZonePrelevements.xaml
    /// </summary>
    public partial class AfficherZonePrelevements : Page
    {
        int selectedZonePrelevementId;
        ZonePrelevementViewModel myDataObject;
        ZonePrelevementDAL c = new ZonePrelevementDAL();
        ObservableCollection<ZonePrelevementViewModel> lp;
        public AfficherZonePrelevements()
        {
            InitializeComponent();
            lp = ZonePrelevementORM.listeZonePrelevements();
            listeZonePrelevements.ItemsSource = lp;
            myDataObject = new ZonePrelevementViewModel();
        }
        private void ajouterZone_Click(object sender, EventArgs e)
        {
            myDataObject.nomZonePrelevementProperty = Nom.Text;
            Decimal defaultValue = 0.0M; //si la string est abhérente, les lat et long par défaut sont de 0,0
            Decimal result;
            string decimalValueToParse = Lat1.Text;
            myDataObject.lat1Property = Decimal.TryParse(decimalValueToParse, out result) ? result : defaultValue;
            decimalValueToParse = Lat2.Text;
            myDataObject.lat2Property = Decimal.TryParse(decimalValueToParse, out result) ? result : defaultValue;
            decimalValueToParse = Lat3.Text;
            myDataObject.lat3Property = Decimal.TryParse(decimalValueToParse, out result) ? result : defaultValue;
            decimalValueToParse = Lat4.Text;
            myDataObject.lat4Property = Decimal.TryParse(decimalValueToParse, out result) ? result : defaultValue;
            decimalValueToParse = Long1.Text;
            myDataObject.long1Property = Decimal.TryParse(decimalValueToParse, out result) ? result : defaultValue;
            decimalValueToParse = Long2.Text;
            myDataObject.long2Property = Decimal.TryParse(decimalValueToParse, out result) ? result : defaultValue;
            decimalValueToParse = Long3.Text;
            myDataObject.long3Property = Decimal.TryParse(decimalValueToParse, out result) ? result : defaultValue;
            decimalValueToParse = Long4.Text;
            myDataObject.long4Property = Decimal.TryParse(decimalValueToParse, out result) ? result : defaultValue;

            ZonePrelevementViewModel nouveau = new ZonePrelevementViewModel(ZonePrelevementDAL.getMaxIdZonePrelevement() + 1, myDataObject.nomZonePrelevementProperty, myDataObject.lat1Property, myDataObject.lat2Property, myDataObject.lat3Property, myDataObject.lat4Property, myDataObject.long1Property, myDataObject.long2Property, myDataObject.long3Property, myDataObject.long4Property);
            lp.Add(nouveau);
            ZonePrelevementDAO.insertZonePrelevement(nouveau);
            listeZonePrelevements.Items.Refresh();         
        }
        private void supprimerButton_Click(object sender, EventArgs e)
        {
            ZonePrelevementViewModel toRemove = (ZonePrelevementViewModel)listeZonePrelevements.SelectedItem;
            lp.Remove(toRemove);
            listeZonePrelevements.Items.Refresh();
            ZonePrelevementDAO.supprimerZonePrelevement(selectedZonePrelevementId);
        }
        private void listeZonePrelevements_SelectionChanged(object sender, EventArgs e)
        {
            if ((listeZonePrelevements.SelectedIndex < lp.Count) && (listeZonePrelevements.SelectedIndex >= 0))
            {
                selectedZonePrelevementId = (lp.ElementAt<ZonePrelevementViewModel>(listeZonePrelevements.SelectedIndex)).idZonePrelevementProperty;
            }
        }
        private void redirectButton_Accueil(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new AfficherInterfaceSelection();
        }
    }
}
