using ProjetB2CSharpPlage.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.Ctrl
{
    public class EquipeViewModel
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
                this.nomEquipe = value.ToUpper();
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
                EquipeDAO.updateEquipe(this);
            }
        }
    }
}
