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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = tableLayoutPanel1.RowCount;
            Button button;
            for (int i = size; i < size + 5; i++)
            {
                button = new Button() { Text = "Sélectionner", Name = i.ToString() };
                button.Click += new System.EventHandler(this.enregistrerVol);
                tableLayoutPanel1.Controls.Add(button, 1, i);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Albaator ! Albaaator ! " + i, Anchor = AnchorStyles.Left, Width = 400 }, 0, i);
            }
            size = tableLayoutPanel2.RowCount;
            for (int i = size; i < size + 3; i++) {
                button = new Button() { Text = "Sélectionner", Name = i.ToString() };
                button.Click += new System.EventHandler(this.enregistrerHotel);
                tableLayoutPanel2.Controls.Add(button, 1, i);
                tableLayoutPanel2.Controls.Add(new Label() { Text = "Moi mon petit bisounours, je lui fais, des câlins " +i, Anchor = AnchorStyles.Left, Width = 400 }, 0, i);
            }
        }

        private void enregistrerVol(object sender, EventArgs e)
        {
            volSelectionne.Text = this.tableLayoutPanel1.GetControlFromPosition(0, int.Parse(((Button)sender).Name)).Text;
            if (this.volSelectionne.Text.Length > 0 && this.hotelSelectionne.Text.Length > 0) this.button2.Enabled = true;
            else this.button2.Enabled = false;
        }
        private void enregistrerHotel(object sender, EventArgs e)
        {
            hotelSelectionne.Text = this.tableLayoutPanel2.GetControlFromPosition(0, int.Parse(((Button)sender).Name)).Text;
            if (this.volSelectionne.Text.Length > 0 && this.hotelSelectionne.Text.Length > 0) this.button2.Enabled = true;
            else this.button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ValiderEnregistrement.Form1 fenetreEnr = new ValiderEnregistrement.Form1(this.volSelectionne.Text, this.hotelSelectionne.Text);
            fenetreEnr.Show();
        }
    }
}
