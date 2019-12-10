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
        private int numeroDepartement;

        public DepartementViewModel() { }

        public DepartementViewModel(int id, string nom, int num)
        {
            this.idDepartement = id;
            this.nomDepartement = nom;
            this.numeroDepartement = num;
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
        public int numeroDepartementProperty
        {
            get { return numeroDepartement; }
            set
            {
                this.numeroDepartement = value;
                OnPropertyChanged("numeroDepartementProperty");
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
