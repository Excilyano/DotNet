namespace ValiderEnregistrement
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hotelSelectionne = new System.Windows.Forms.Label();
            this.volSelectionne = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nom = new System.Windows.Forms.TextBox();
            this.prenom = new System.Windows.Forms.TextBox();
            this.valider = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hotelSelectionne);
            this.groupBox1.Controls.Add(this.volSelectionne);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Récapitulatif";
            // 
            // hotelSelectionne
            // 
            this.hotelSelectionne.AutoSize = true;
            this.hotelSelectionne.Location = new System.Drawing.Point(126, 42);
            this.hotelSelectionne.Name = "hotelSelectionne";
            this.hotelSelectionne.Size = new System.Drawing.Size(0, 13);
            this.hotelSelectionne.TabIndex = 3;
            // 
            // volSelectionne
            // 
            this.volSelectionne.AutoSize = true;
            this.volSelectionne.Location = new System.Drawing.Point(126, 20);
            this.volSelectionne.Name = "volSelectionne";
            this.volSelectionne.Size = new System.Drawing.Size(0, 13);
            this.volSelectionne.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hôtel sélectionné :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vol sélectionné :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Veuillez renseigner les informations suivantes pour terminer l\'enregistrement";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nom :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Prénom :";
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(57, 102);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(183, 20);
            this.nom.TabIndex = 4;
            this.nom.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // prenom
            // 
            this.prenom.Location = new System.Drawing.Point(301, 102);
            this.prenom.Name = "prenom";
            this.prenom.Size = new System.Drawing.Size(175, 20);
            this.prenom.TabIndex = 5;
            this.prenom.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // valider
            // 
            this.valider.Enabled = false;
            this.valider.Location = new System.Drawing.Point(16, 129);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(460, 23);
            this.valider.TabIndex = 6;
            this.valider.Text = "Valider l\'enregistrement";
            this.valider.UseVisualStyleBackColor = true;
            this.valider.Click += new System.EventHandler(this.valider_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 160);
            this.Controls.Add(this.valider);
            this.Controls.Add(this.prenom);
            this.Controls.Add(this.nom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Valider l\'enregistrement";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label hotelSelectionne;
        private System.Windows.Forms.Label volSelectionne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.TextBox prenom;
        private System.Windows.Forms.Button valider;
    }
}

