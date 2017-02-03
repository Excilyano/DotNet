using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ProjetDotNet.libReservationMSMQ;

namespace svcTraiterMSMQ
{
    public partial class TraiterMSMQ : ServiceBase
    {
        public TraiterMSMQ()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            
            while (true)
            {
                clsReservationMSMQ myReservation = new clsReservationMSMQ();
                myReservation.ReservationMSMQ();
            }
            
        }

        protected override void OnStop()
        {
        }
    }
}
