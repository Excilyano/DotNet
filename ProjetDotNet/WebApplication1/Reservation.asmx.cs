using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using ProjetDotNet.libVol;
using ProjetDotNet.libHotel;

namespace ProjetDotNet.svcReservation
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Reservation : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet getHotels(string ville)
        {
            clsHotel hotel = new clsHotel();
            DataSet myDS = new DataSet();
            myDS = hotel.liste_Hotels(ville);

            return myDS;
        }

        [WebMethod]
        public DataSet getVols(string villeDepart, string villeArrivee)
        {
            clsVol vol = new clsVol();
            DataSet myDS = new DataSet();
            myDS = vol.liste_Vols(villeDepart, villeArrivee);

            return myDS;
        }

        [WebMethod]
        public DataSet getVilles()
        {
            clsVol vol = new clsVol();
            DataSet myDS = new DataSet();
            myDS = vol.liste_Villes();

            return myDS;
        }
    }
}
