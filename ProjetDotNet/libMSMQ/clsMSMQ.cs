using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.IO;

namespace ProjetDotNet.libMSMQ
{
    public class clsMSMQ
    {

        private MessageQueue MyMQ;

        public clsMSMQ()
        {
            MyMQ = new MessageQueue(@".\private$\ResaVolsHotels");
            MyMQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(ReservationInfo) });
        }

        public ReservationInfo LireMSMQ()
        {
            ReservationInfo resInfo = new ReservationInfo();

            try
            {
                resInfo = new ReservationInfo();
                resInfo = (ReservationInfo)MyMQ.Peek().Body;

            }
            catch (Exception e)
            {
            }


            return resInfo;
        }

        public void receive()
        {
                MyMQ.Receive();
        }

        public void close()
        {
            MyMQ.Close();
        }
    }


    public class ReservationInfo
    {
        public string nom { get; set; }
        public string prenom { get; set; }
        public int idHotel { get; set; }
        public int idVol { get; set; }
    }
}
