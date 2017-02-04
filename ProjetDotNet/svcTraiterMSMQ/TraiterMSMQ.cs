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
using System.IO;

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
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 2000; // 2 seconds  
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();

        }

        protected override void OnStop()
        {
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            clsReservationMSMQ myReservation = new clsReservationMSMQ();
            myReservation.ReservationMSMQ();
        }



    }
}
