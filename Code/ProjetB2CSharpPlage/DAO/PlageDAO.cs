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
    public class PlageDAO
    {
        public int idPlageDAO;
        public string nomPlageDAO;
        public int idCommunePlageDAO;
        public int nbEspecesDifferentesPlageDAO;
        public float surfacePlageDAO;

        public PlageDAO(int idPlageDAO, string nomPlageDAO, int idCommunePlageDAO, int nbEspecesDifferentesPlageDAO, float surfacePlageDAO)
        {
            this.idPlageDAO = idPlageDAO;
            this.nomPlageDAO = nomPlageDAO;
            this.idCommunePlageDAO = idCommunePlageDAO;
            this.nbEspecesDifferentesPlageDAO = nbEspecesDifferentesPlageDAO;
            this.surfacePlageDAO = surfacePlageDAO;
        }

        public static ObservableCollection<PlageDAO> listePlages()
        {
            ObservableCollection<PlageDAO> l = PlageDAL.selectPlages();
            return l;
        }

        public static PlageDAO getPlage(int idPlage)
        {
            PlageDAO p = PlageDAL.getPlage(idPlage);
            return p;
        }

        public static void updatePlage(PlageViewModel p)
        {
            PlageDAL.updatePlage(new PlageDAO(p.idPlageProperty, p.nomPlageProperty, p.communePlage.idCommuneProperty, p.nbEspecesDifferentesPlageProperty, p.surfacePlageProperty));
        }

        public static void supprimerPlage(int id)
        {
            PlageDAL.supprimerPlage(id);
        }

        public static void insertPlage(PlageViewModel p)
        {
            PlageDAL.insertPlage(new PlageDAO(p.idPlageProperty, p.nomPlageProperty, p.communePlage.idCommuneProperty, p.nbEspecesDifferentesPlageProperty, p.surfacePlageProperty));
        }
    }
}
