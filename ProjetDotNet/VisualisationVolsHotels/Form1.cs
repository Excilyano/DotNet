using ProjetDotNet.libReservation;
using ProjetDotNet.svcReservation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualisationVolsHotels
{
    public partial class Form1 : Form
    {
        private List<clsResVol> vols;
        private clsResVol volCourant;
        private List<clsResHotel> hotels;
        private clsResHotel hotelCourant;
        private Reservation resService;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.vols = this.resService.getVols(
                this.villesDepart.Items[this.villesDepart.SelectedIndex].ToString(),
                this.villesDepart.Items[this.villesArrivee.SelectedIndex].ToString());
            this.hotels = this.resService.getHotels(
                this.villesDepart.Items[this.villesArrivee.SelectedIndex].ToString());
            Button button;
            for (int i = 1; i <= this.vols.Count; i++)
            {
                button = new Button() { Text = "Sélectionner", Name = this.vols[i-1].idVol.ToString() };
                button.Click += new System.EventHandler(this.enregistrerVol);
                tableLayoutPanel1.Controls.Add(button, 1, i);
                tableLayoutPanel1.Controls.Add(new Label() { Text = this.vols[i-1].ToString(), Anchor = AnchorStyles.Left, Width = 738 }, 0, i);
            }
            for (int i = 1; i <= this.hotels.Count; i++) {
                button = new Button() { Text = "Sélectionner", Name = this.hotels[i - 1].idHotel.ToString() };
                button.Click += new System.EventHandler(this.enregistrerHotel);
                tableLayoutPanel2.Controls.Add(button, 1, i);
                tableLayoutPanel2.Controls.Add(new Label() { Text = this.hotels[i - 1].ToString(), Anchor = AnchorStyles.Left, Width = 738 }, 0, i);
            }
        }

        private void enregistrerVol(object sender, EventArgs e)
        {
            volCourant = new clsResVol();
            int id = int.Parse(((Button)sender).Name);
            for (int i = 0; i < this.vols.Count; i++)
            {
                if (vols[i].idVol == id) volCourant = vols[i];
            }
            volSelectionne.Text = volCourant.ToString();
            if (this.volSelectionne.Text.Length > 0 && this.hotelSelectionne.Text.Length > 0) this.button2.Enabled = true;
            else this.button2.Enabled = false;
        }
        private void enregistrerHotel(object sender, EventArgs e)
        {
            hotelCourant = new clsResHotel();
            int id = int.Parse(((Button)sender).Name);
            for (int i = 0; i < this.hotels.Count; i++)
            {
                if (hotels[i].idHotel == id) hotelCourant = hotels[i];
            }
            hotelSelectionne.Text = hotelCourant.ToString();
            if (this.volSelectionne.Text.Length > 0 && this.hotelSelectionne.Text.Length > 0) this.button2.Enabled = true;
            else this.button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ValiderEnregistrement.Form1 fenetreEnr = new ValiderEnregistrement.Form1(this.volCourant, this.hotelCourant);
            fenetreEnr.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.resService = new Reservation();
            List<String> villes = resService.getVilles();
            for (int i = 0; i < villes.Count; i++)
            {
                villesDepart.Items.Add(villes[i]);
                villesArrivee.Items.Add(villes[i]);
            }
        }
    }
}
