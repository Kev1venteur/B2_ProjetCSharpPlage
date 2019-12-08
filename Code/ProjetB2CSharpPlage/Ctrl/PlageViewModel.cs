using ProjetB2CSharpPlage.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.Ctrl
{
    public class PlageViewModel : INotifyPropertyChanged
    {
        private int idPlage;
        private string nomPlage;
        public CommuneViewModel communePlage;
        private int nbEspecesDifferentesPlage;
        private float surfacePlage;
        private int idPlageDAO;
        private string nomPlageDAO;
        private CommuneViewModel m;

        public PlageViewModel() { }

        public PlageViewModel(int id, string nom, CommuneViewModel commune, int nombreEspeces, float surface)
        {
            this.idPlage = id;
            this.nomPlageProperty = nom;
            this.communePlage = commune;
            this.nbEspecesDifferentesPlage = nombreEspeces;
            this.surfacePlage = surface;
        }

        public PlageViewModel(int idPlageDAO, string nomPlageDAO, CommuneViewModel m)
        {
            this.idPlageDAO = idPlageDAO;
            this.nomPlageDAO = nomPlageDAO;
            this.m = m;
        }

        public int idPlageProperty
        {
            get { return idPlage; }
        }

        public String nomPlageProperty
        {
            get { return nomPlage; }
            set
            {
                nomPlage = value;
                OnPropertyChanged("nomPlageProperty");
            }

        }

        public CommuneViewModel communePlageProperty
        {
            get { return communePlage; }
        }
        public string communePlageNameProperty
        {
            get { return communePlage.nomCommuneProperty; }
        }

        public int nbEspecesDifferentesPlageProperty
        {
            get { return nbEspecesDifferentesPlage; }
            set
            {
                this.nbEspecesDifferentesPlage = value;
                OnPropertyChanged("nbEspecesDifferentesPlageProperty");
            }
        }
        public float surfacePlageProperty
        {
            get { return surfacePlage; }
            set
            {
                this.surfacePlage = value;
                OnPropertyChanged("surfacePlageProperty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                PlageDAO.updatePlage(this);
            }
        }
    }
}
