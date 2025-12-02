namespace AP2_INTERMARCHE
{
    partial class Notification_C
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
            ListeCommande = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            ListeProduit = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            nb_produit = new NumericUpDown();
            changement_valider = new Button();
            ((System.ComponentModel.ISupportInitialize)nb_produit).BeginInit();
            SuspendLayout();
            // 
            // ListeCommande
            // 
            ListeCommande.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            ListeCommande.Location = new Point(37, 26);
            ListeCommande.Name = "ListeCommande";
            ListeCommande.Size = new Size(230, 276);
            ListeCommande.TabIndex = 0;
            ListeCommande.UseCompatibleStateImageBehavior = false;
            ListeCommande.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Libelle";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 150;
            // 
            // ListeProduit
            // 
            ListeProduit.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4, columnHeader5 });
            ListeProduit.Location = new Point(334, 26);
            ListeProduit.Name = "ListeProduit";
            ListeProduit.Size = new Size(442, 276);
            ListeProduit.TabIndex = 1;
            ListeProduit.UseCompatibleStateImageBehavior = false;
            ListeProduit.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "ID";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Nom";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Position";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 80;
            // 
            // nb_produit
            // 
            nb_produit.Location = new Point(571, 335);
            nb_produit.Name = "nb_produit";
            nb_produit.Size = new Size(150, 27);
            nb_produit.TabIndex = 2;
            // 
            // changement_valider
            // 
            changement_valider.Location = new Point(599, 390);
            changement_valider.Name = "changement_valider";
            changement_valider.Size = new Size(94, 29);
            changement_valider.TabIndex = 3;
            changement_valider.Text = "Valider";
            changement_valider.UseVisualStyleBackColor = true;
            // 
            // Notification_C
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(changement_valider);
            Controls.Add(nb_produit);
            Controls.Add(ListeProduit);
            Controls.Add(ListeCommande);
            Name = "Notification_C";
            Text = "Notification_C";
            ((System.ComponentModel.ISupportInitialize)nb_produit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListView ListeCommande;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ListView ListeProduit;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private NumericUpDown nb_produit;
        private Button changement_valider;
    }
}