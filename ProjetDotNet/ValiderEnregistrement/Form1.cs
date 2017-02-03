using ProjetDotNet.libReservation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValiderEnregistrement
{
    public partial class Form1 : Form
    {
        private clsResVol volCourant;
        private clsResHotel hotelCourant;
        public Form1(clsResVol vol, clsResHotel hotel)
        {
            InitializeComponent();
            this.volSelectionne.Text = vol.ToString();
            this.hotelSelectionne.Text = hotel.ToString();
            volCourant = vol;
            hotelCourant = hotel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (nom.Text.Length > 0 && prenom.Text.Length > 0) valider.Enabled = true;
            else valider.Enabled = false;
        }

        private void valider_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
