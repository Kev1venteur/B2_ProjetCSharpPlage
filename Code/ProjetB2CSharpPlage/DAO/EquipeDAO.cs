using ProjetB2CSharpPlage.Ctrl;
using ProjetB2CSharpPlage.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.DAO
{
    public class EquipeDAO
    {
        public int idEquipeDAO;
        public string nomEquipeDAO;
        public int nombreMembresEquipeDAO;
        public EquipeDAO(int idEquipeDAO, string nomEquipeDAO, int nombreMembresEquipeDAO)
        {
            this.idEquipeDAO = idEquipeDAO;
            this.nomEquipeDAO = nomEquipeDAO;
            this.nombreMembresEquipeDAO = nombreMembresEquipeDAO;
        }
        public static ObservableCollection<EquipeDAO> listeEquipes()
        {
            ObservableCollection<EquipeDAO> l = EquipeDAL.selectEquipes();
            return l;
        }

        public static EquipeDAO getEquipes(int idEquipe)
        {
            EquipeDAO p = EquipeDAL.getEquipe(idEquipe);
            return p;
        }

        public static void updateEquipe(EquipeViewModel u)
        {
            EquipeDAL.updateEquipe(new EquipeDAO(u.idEquipeProperty, u.nomEquipeProperty, u.nombreMembresEquipeProperty));
        }

        public static void supprimerEquipe(int idEquipe)
        {
            EquipeDAL.supprimerEquipe(idEquipe);
        }

        public static void insertEquipe(EquipeViewModel u)
        {
            EquipeDAL.insertEquipe(new EquipeDAO(u.idEquipeProperty, u.nomEquipeProperty, u.nombreMembresEquipeProperty));
        }
    }
}
