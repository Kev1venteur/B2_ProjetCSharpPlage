using ProjetB2CSharpPlage.ORM;
using System.ComponentModel;

namespace ProjetB2CSharpPlage.VM
{
    public class DepartementViewModel : INotifyPropertyChanged
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
                DepartementORM.updateDepartement(this);
            }
        }
    }
}
