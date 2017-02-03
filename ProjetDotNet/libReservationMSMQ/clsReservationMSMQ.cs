using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetDotNet.libReservationMSMQ;
using ProjetDotNet.libMSMQ;
using ProjetDotNet.libHotel;
using ProjetDotNet.libVol;

namespace ProjetDotNet.libReservationMSMQ
{
    public class clsReservationMSMQ
    {
        clsHotel hotel;
        clsVol vol;

        public clsReservationMSMQ()
        {
            this.hotel = new clsHotel();
            this.vol = new clsVol();
        }


        public bool ReservationMSMQ()
        {
            bool success = false;
            clsReservationMSMQ myResMSMQ = new clsReservationMSMQ();
            ReservationInfo myRI = new ReservationInfo();
            clsMSMQ myMSMQ = new clsMSMQ();
            myRI = myMSMQ.LireMSMQ();
            int resHotel = hotel.reservationHotel(myRI.nom, myRI.prenom, myRI.idHotel);
            int resVol = vol.reservationVol(myRI.nom, myRI.prenom, myRI.idVol);
            success = true;
            return success;
        }

    }
}
