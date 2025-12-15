namespace AP2_INTERMARCHE
{
    partial class ajout_commande_R
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
            ajouter_commande = new Button();
            cb_commande = new ComboBox();
            tb_libelle_magasin = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // ajouter_commande
            // 
            ajouter_commande.Location = new Point(444, 125);
            ajouter_commande.Name = "ajouter_commande";
            ajouter_commande.Size = new Size(271, 29);
            ajouter_commande.TabIndex = 0;
            ajouter_commande.Text = "Ajouter commande";
            ajouter_commande.UseVisualStyleBackColor = true;
            ajouter_commande.Click += ajouter_commande_Click;
            // 
            // cb_commande
            // 
            cb_commande.FormattingEnabled = true;
            cb_commande.Location = new Point(524, 51);
            cb_commande.Name = "cb_commande";
            cb_commande.Size = new Size(151, 28);
            cb_commande.TabIndex = 1;
            // 
            // tb_libelle_magasin
            // 
            tb_libelle_magasin.Location = new Point(50, 52);
            tb_libelle_magasin.Name = "tb_libelle_magasin";
            tb_libelle_magasin.Size = new Size(253, 27);
            tb_libelle_magasin.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(87, 125);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Ajouter magasin";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ajout_commande_R
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 544);
            Controls.Add(button1);
            Controls.Add(tb_libelle_magasin);
            Controls.Add(cb_commande);
            Controls.Add(ajouter_commande);
            Name = "ajout_commande_R";
            Text = "ajout_commande_R";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ajouter_commande;
        private ComboBox cb_commande;
        private TextBox tb_libelle_magasin;
        private Button button1;
    }
}