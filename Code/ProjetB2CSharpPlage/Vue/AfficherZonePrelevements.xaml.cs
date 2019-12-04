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
        int compteur = 0;
        public AfficherZonePrelevements()
        {
            InitializeComponent();
            lp = ZonePrelevementORM.listeZonePrelevements();
            listeZonePrelevements.ItemsSource = lp;
        }
        private void nomPrenomButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ZonePrelevementViewModel nouveau = new ZonePrelevementViewModel(ZonePrelevementDAL.getMaxIdZonePrelevement() + 1, myDataObject.nomZonePrelevementProperty, myDataObject.lat1Property, myDataObject.lat2Property, myDataObject.lat3Property, myDataObject.lat4Property, myDataObject.long1Property, myDataObject.long2Property, myDataObject.long3Property, myDataObject.long4Property);
            lp.Add(nouveau);
            ZonePrelevementDAO.insertZonePrelevement(nouveau);
            listeZonePrelevements.Items.Refresh();
            compteur = lp.Count();
            myDataObject = new ZonePrelevementViewModel(ZonePrelevementDAL.getMaxIdZonePrelevement() + 1, "", myDataObject.lat1Property, myDataObject.lat2Property, myDataObject.lat3Property, myDataObject.lat4Property, myDataObject.long1Property, myDataObject.long2Property, myDataObject.long3Property, myDataObject.long4Property);
        }
        private void supprimerButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ZonePrelevementViewModel toRemove = (ZonePrelevementViewModel)listeZonePrelevements.SelectedItem;
            lp.Remove(toRemove);
            listeZonePrelevements.Items.Refresh();
            ZonePrelevementDAO.supprimerZonePrelevement(selectedZonePrelevementId);
        }
        private void listeZonePrelevements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeZonePrelevements.SelectedIndex < lp.Count) && (listeZonePrelevements.SelectedIndex >= 0))
            {
                selectedZonePrelevementId = (lp.ElementAt<ZonePrelevementViewModel>(listeZonePrelevements.SelectedIndex)).idZonePrelevementProperty;
            }
        }
    }
}
