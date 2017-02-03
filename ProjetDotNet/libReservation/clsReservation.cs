using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetDotNet.libHotel;
using ProjetDotNet.libVol;
using System.Data;
using ProjetDotNet.svcReservation;
using System.Web.Services;


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
            svcReservation.Reservation myRes = new Reservation();
            DataSet myDS = myRes.getHotels(ville);
            List<clsResHotel> listResHotels = new List<clsResHotel>();
            DataRowCollection myDRC = myDS.Tables["liste_hotels"].Rows;
            for (int i = 0; i < myDRC.Count; i++)
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
            svcReservation.Reservation myRes = new Reservation();
            DataSet myDS = myRes.getVols(villeDepart, villeArrivee);
            List<clsResVol> listResVols = new List<clsResVol>();
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
            svcReservation.Reservation myRes = new Reservation();
            DataSet myDS = myRes.getVilles();
            List<string> listeVilles = new List<string>();
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

        public override string ToString()
        {
            return "Vol n°" + idVol + " au départ de " + villeDepart
                + " à destination de " + villeArrivee + ". Départ le " + date;
        }
    }

    public class clsResHotel
    {
        public string ville;
        public string nom;
        public int idHotel;

        public override string ToString()
        {
            return ville + ". Hôtel '" + nom + "'.";
        }
    }
}
