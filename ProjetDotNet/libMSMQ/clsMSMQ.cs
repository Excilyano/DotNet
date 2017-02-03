using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace ProjetDotNet.libMSMQ
{
    public class clsMSMQ
    {
        public ReservationInfo LireMSMQ()
        {
            MessageQueue MyMQ = new MessageQueue(@".\private$\ResaVolsHotels");
            MyMQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(ReservationInfo) });
            ReservationInfo ResInfo = new ReservationInfo();
            ResInfo = (ReservationInfo)MyMQ.Peek().Body;

            MyMQ.Receive();

            MyMQ.Close();
            return ResInfo;
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
