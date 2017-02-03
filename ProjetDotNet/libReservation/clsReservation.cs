using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetDotNet.libHotel;
using ProjetDotNet.libVol;
using System.Data;

namespace ProjetDotNet.libReservation
{
    public class clsReservation
    {

        private clsVol vol;
        private clsHotel hotel; 

        public clsReservation()
        {
            this.hotel = new clsHotel();
            this.vol = new clsVol();
        }

        public List<clsResHotel> getHotels(string ville)
        {
            DataSet myDS = new DataSet();
            List<clsResHotel> listResHotels = new List<clsResHotel>();
            myDS = this.hotel.liste_Hotels(ville);
            DataRowCollection myDRC = myDS.Tables["liste_hotels"].Rows;
            for (int i=0; i < myDRC.Count; i++)
            {
                clsResHotel h = new clsResHotel();
                h.ville = myDRC[i]["Ville"].ToString();
                h.nom = myDRC[i]["Nom"].ToString();
                h.idHotel = Convert.ToInt16(myDRC[i]["Id"]);
                listResHotels.Add(h);
            }

            return listResHotels;
        }

        public List<clsResVol> getVols(string villeDepart, string villeArrivee)
        {
            DataSet myDS = new DataSet();
            List<clsResVol> listResVols = new List<clsResVol>();
            myDS = this.vol.liste_Vols(villeDepart, villeArrivee);
            DataRowCollection myDRC = myDS.Tables["liste_vols"].Rows;
            for (int i = 0; i < myDRC.Count; i++)
            {
                clsResVol v = new clsResVol();
                v.villeDepart = myDRC[i]["VilleDepart"].ToString();
                v.villeArrivee = myDRC[i]["VilleArrivee"].ToString();
                v.date = myDRC[i]["Date"].ToString();
                v.idVol = Convert.ToInt16(myDRC[i]["Id"]);
                listResVols.Add(v);
            }

            return listResVols;
        }

        public List<string> getVilles()
        {
            DataSet myDS = new DataSet();
            List<string> listeVilles = new List<string>();
            myDS = this.vol.liste_Villes();
            DataRowCollection myDRC = myDS.Tables["liste_villes"].Rows;
            for (int i = 0; i < myDRC.Count; i++)
            {
                string v;
                v = myDRC[i]["Ville"].ToString();
                listeVilles.Add(v);
            }

            return listeVilles;
        }

    }


    public class clsResVol
    {
        public string villeDepart;
        public string villeArrivee;
        public string date;
        public int idVol;
    }

    public class clsResHotel
    {
        public string ville;
        public string nom;
        public int idHotel;
    }
}
