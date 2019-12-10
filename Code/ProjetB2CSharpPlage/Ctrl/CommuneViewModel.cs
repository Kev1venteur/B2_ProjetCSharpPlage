using ProjetB2CSharpPlage.ORM;
using System;
using System.ComponentModel;

namespace ProjetB2CSharpPlage.Ctrl
{
    public class CommuneViewModel : INotifyPropertyChanged
    {
        private int idCommune;
        private string nomCommune;
        public DepartementViewModel departementCommune;

        public CommuneViewModel() { }

        public CommuneViewModel(int id, string nom, DepartementViewModel departement)
        {
            this.idCommune = id;
            this.nomCommuneProperty = nom;
            this.departementCommune = departement;
        }
        public int idCommuneProperty
        {
            get { return idCommune; }
        }

        public String nomCommuneProperty
        {
            get { return nomCommune; }
            set
            {
                nomCommune = value;
                OnPropertyChanged("nomCommuneProperty");
            }

        }

        public DepartementViewModel departementCommuneProperty
        {
            get { return departementCommune; }
        }
        public string departementCommuneNameProperty
        {
            get { return departementCommune.nomDepartementProperty; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                CommuneORM.updateCommune(this);
            }
        }
    }
}
