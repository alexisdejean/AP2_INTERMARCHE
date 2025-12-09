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
            columnHeader6 = new ColumnHeader();
            ListeProduit = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            changement_valider = new Button();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // ListeCommande
            // 
            ListeCommande.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader6 });
            ListeCommande.Location = new Point(26, 26);
            ListeCommande.Name = "ListeCommande";
            ListeCommande.Size = new Size(655, 276);
            ListeCommande.TabIndex = 0;
            ListeCommande.UseCompatibleStateImageBehavior = false;
            ListeCommande.View = View.Details;
            ListeCommande.SelectedIndexChanged += ListeCommande_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Libelle";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 400;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Commande";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 120;
            // 
            // ListeProduit
            // 
            ListeProduit.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4, columnHeader5 });
            ListeProduit.Location = new Point(844, 26);
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
            columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Position";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 120;
            // 
            // changement_valider
            // 
            changement_valider.Location = new Point(599, 390);
            changement_valider.Name = "changement_valider";
            changement_valider.Size = new Size(94, 29);
            changement_valider.TabIndex = 3;
            changement_valider.Text = "Valider";
            changement_valider.UseVisualStyleBackColor = true;
            changement_valider.Click += changement_valider_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(572, 343);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 4;
            // 
            // Notification_C
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1557, 771);
            Controls.Add(numericUpDown1);
            Controls.Add(changement_valider);
            Controls.Add(ListeProduit);
            Controls.Add(ListeCommande);
            Name = "Notification_C";
            Text = "Notification_C";
            Load += Notification_C_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
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
        private Button changement_valider;
        private ColumnHeader columnHeader6;
        private NumericUpDown numericUpDown1;
    }
}