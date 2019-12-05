using ProjetB2CSharpPlage.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.Ctrl
{
    public class DepartementViewModel
    {
        private int idDepartement;
        private string nomDepartement;

        public DepartementViewModel() { }

        public DepartementViewModel(int id, string nom)
        {
            this.idDepartement = id;
            this.nomDepartement = nom;
        }

        public int idDepartementProperty
        {
            get { return idDepartement; }
        }
        public string nomDepartementProperty
        {
            get { return nomDepartement; }
            set
            {
                this.nomDepartement = value;
                OnPropertyChanged("nomDepartementProperty");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DepartementDAO.updateDepartement(this);
            }
        }
    }
}
