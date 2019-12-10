using ProjetB2CSharpPlage.ORM;
using System;
using System.ComponentModel;

namespace ProjetB2CSharpPlage.Ctrl
{
    public class EtudeViewModel : INotifyPropertyChanged
    {
        private int idEtude;
        private string titreEtude;
        public EquipeViewModel equipeEtude;
        private int nbTotalEspeceRencontreeEtude;
        private DateTime dateEtude;
        private int idEtudeDAO;
        private string nomEtudeDAO;
        private EquipeViewModel m;

        public EtudeViewModel() { }

        public EtudeViewModel(int id, DateTime date, string titre, int nbTotalEspeceRencontree, EquipeViewModel equipe)
        {
            this.idEtude = id;
            this.titreEtude = titre;
            this.equipeEtude = equipe;
            this.nbTotalEspeceRencontreeEtude = nbTotalEspeceRencontree;
            this.dateEtude = date;
        }

        public EtudeViewModel(int idEtudeDAO, string nomEtudeDAO, EquipeViewModel m)
        {
            this.idEtudeDAO = idEtudeDAO;
            this.nomEtudeDAO = nomEtudeDAO;
            this.m = m;
        }

        public int idEtudeProperty
        {
            get { return idEtude; }
        }

        public String titreEtudeProperty
        {
            get { return titreEtude; }
            set
            {
                titreEtude = value;
                OnPropertyChanged("titreEtudeProperty");
            }

        }

        public EquipeViewModel equipeEtudeProperty
        {
            get { return equipeEtude; }
        }
        public string equipeEtudeNameProperty
        {
            get { return equipeEtude.nomEquipeProperty; }
        }

        public int nbTotalEspeceRencontreeEtudeProperty
        {
            get { return nbTotalEspeceRencontreeEtude; }
            set
            {
                this.nbTotalEspeceRencontreeEtude = value;
                OnPropertyChanged("nbTotalEspeceRencontreeEtudeProperty");
            }
        }
        public DateTime dateEtudeProperty
        {
            get { return dateEtude; }
            set
            {
                this.dateEtude = value;
                OnPropertyChanged("dateEtudeProperty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EtudeORM.updateEtude(this);
            }
        }
    }
}
