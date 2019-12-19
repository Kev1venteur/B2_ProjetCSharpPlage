using ProjetB2CSharpPlage.ORM;
using System.ComponentModel;

namespace ProjetB2CSharpPlage.VM
{
    public class EquipeViewModel : INotifyPropertyChanged
    {
        private int idEquipe;
        private string nomEquipe;
        private int nombreMembresEquipe;

        public EquipeViewModel() { }

        public EquipeViewModel(int id, string nom, int nombreMembres)
        {
            this.idEquipe = id;
            this.nomEquipe = nom;
            this.nombreMembresEquipe = nombreMembres;
        }

        public int idEquipeProperty
        {
            get { return idEquipe; }
        }
        public string nomEquipeProperty
        {
            get { return nomEquipe; }
            set
            {
                this.nomEquipe = value;
                OnPropertyChanged("nomEquipeProperty");
            }
        }
        public int nombreMembresEquipeProperty
        {
            get { return nombreMembresEquipe; }
            set
            {
                this.nombreMembresEquipe = value;
                OnPropertyChanged("nombreMembresEquipeProperty");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EquipeORM.updateEquipe(this);
            }
        }
    }
}
