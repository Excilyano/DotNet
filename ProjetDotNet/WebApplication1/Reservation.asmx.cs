using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ProjetDotNet.libReservation;

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
        public List<clsResHotel> getHotels (string ville)
        {
            clsReservation res = new clsReservation();
            return res.getHotels(ville);            
        }

        [WebMethod]
        public List<clsResVol> getVols(string villeDepart, string villeArrivee)
        {
            clsReservation res = new clsReservation();
            return res.getVols(villeDepart, villeArrivee);
        }
    }
}
