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
        private string passwordUtilisateur;
        private string loginUtilisateur;
        private bool roleUtilisateur;

        public UtilisateurViewModel() { }

        public UtilisateurViewModel(int id, string nom, string prenom, bool role, string password, string login)
        {
            this.idUtilisateur = id;
            this.nomUtilisateur = nom;
            this.prenomUtilisateur = prenom;
            this.roleUtilisateur = role;
            this.passwordUtilisateur = password;
            this.loginUtilisateur = login;
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
                this.concatProperty = this.nomUtilisateur + " " + value;
                OnPropertyChanged("nomUtilisateurProperty");
            }
        }
        public string prenomUtilisateurProperty
        {
            get { return prenomUtilisateur; }
            set
            {
                this.prenomUtilisateur = value;
                this.concatProperty = this.prenomUtilisateur + " " + value;
                OnPropertyChanged("prenomUtilisateurProperty");
            }
        }
        public string passwordUtilisateurProperty
        {
            get { return passwordUtilisateur; }
            set
            {
                this.passwordUtilisateur = value;
                this.concatProperty = this.passwordUtilisateur + " " + value;
                OnPropertyChanged("passwordUtilisateurProperty");
            }
        }
        public string loginUtilisateurProperty
        {
            get { return loginUtilisateur; }
            set
            {
                this.loginUtilisateur = value;
                this.concatProperty = this.loginUtilisateur + " " + value;
                OnPropertyChanged("loginUtilisateurProperty");
            }
        }
        public bool roleUtilisateurProperty
        {
            get { return roleUtilisateur; }
            set
            {
                this.roleUtilisateur = value;
                this.concatProperty = this.roleUtilisateur + " " + value;
                OnPropertyChanged("roleUtilisateurProperty");
            }
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
        public String concatProperty
        {
            get { return ""; }
            set
            {
                //     this.concat = "Ajouter " + value;
            }
        }
    }
}
