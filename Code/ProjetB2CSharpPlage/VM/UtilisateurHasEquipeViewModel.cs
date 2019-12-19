using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.VM
{
    public class UtilisateurHasEquipeViewModel// : INotifyPropertyChanged
    {
        private UtilisateurViewModel idUtilisateur;
        private EquipeViewModel idEquipe;
        //private int idEquipeTamp;

        public UtilisateurHasEquipeViewModel() { }

        public UtilisateurHasEquipeViewModel(UtilisateurViewModel idUtilisateur, EquipeViewModel idEquipe)
        {
            this.idUtilisateur = idUtilisateur;
            this.idEquipe = idEquipe;
            //this.idEquipeTamp = idEquipe.idEquipeProperty;
        }

        public UtilisateurViewModel Utilisateur_UtilisateurHasEquipeProperty
        {
            get { return idUtilisateur; }
            set
            {
                idUtilisateur = value;
                //    OnPropertyChanged("Utilisateur_UtilisateurHasEquipeProperty");
            }
        }
        public String UtilisateurName_UtilisateurHasEquipeProperty
        {
            get { return idUtilisateur.loginUtilisateurProperty; }
        }
        public EquipeViewModel Equipe_UtilisateurHasEquipeProperty
        {
            get { return idEquipe; }
            set
            {
                idEquipe = value;
                //    OnPropertyChanged("Equipe_UtilisateurHasEquipeProperty");
            }
        }
        public String EquipeName_UtilisateurHasEquipeProperty
        {
            get { return idEquipe.nomEquipeProperty; }
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged(string info)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(info));
        //        UtilisateurHasEquipeORM.updateUtilisateurHasEquipe(this);                
        //    }
        //}

    }
}
