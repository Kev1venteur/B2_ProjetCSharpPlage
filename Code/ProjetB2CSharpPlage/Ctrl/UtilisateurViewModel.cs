using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetB2CSharpPlage.DAO;

namespace ProjetB2CSharpPlage.Ctrl
{
    public class UtilisateurViewModel
    {
        private int idUtilisateur;
        private string nomUtilisateur;
        private string prenomUtilisateur;
        private bool roleUtilisateur;

        public UtilisateurViewModel() { }

        public UtilisateurViewModel(int id, string nom, string prenom, bool role)
        {
            this.idUtilisateur = id;
            this.nomUtilisateur = nom;
            this.prenomUtilisateur = prenom;
            this.roleUtilisateur = role;
        }

        public int idUtilisateurProperty
        {
            get { return idUtilisateur; }
        }
        public string nomUtilisateurProperty
        {
            get { return nomUtilisateur; }
            set
            {
                nomUtilisateur = value.ToUpper();
                OnPropertyChanged("nomPersonneProperty");
            }
        }
        public string prenomUtilisateurProperty
        {
            get { return prenomUtilisateur; }
            set
            {
                this.prenomUtilisateur = value;
                OnPropertyChanged("prenomPersonneProperty");
            }
        }
        public bool roleUtilisateurProperty
        {
            get { return roleUtilisateur; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                UtilisateurDAO.updateUtilisateur(this);
            }
        }
    }
}
