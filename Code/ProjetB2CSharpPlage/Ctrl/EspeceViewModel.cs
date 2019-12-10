using ProjetB2CSharpPlage.ORM;
using System.ComponentModel;

namespace ProjetB2CSharpPlage.Ctrl
{
    public class EspeceViewModel
    {
        private int idEspece;
        private string nomEspece;

        public EspeceViewModel() { }

        public EspeceViewModel(int id, string nom)
        {
            this.idEspece = id;
            this.nomEspece = nom;
        }

        public int idEspeceProperty
        {
            get { return idEspece; }
        }
        public string nomEspeceProperty
        {
            get { return nomEspece; }
            set
            {
                this.nomEspece = value;
                OnPropertyChanged("nomEspeceProperty");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EspeceORM.updateEspece(this);
            }
        }
    }
}
