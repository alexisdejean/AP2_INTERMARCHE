namespace AP2_INTERMARCHE
{
    partial class Commande_P
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
            tb_produit = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            tb_Commande = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            textBox1 = new TextBox();
            Valider_notif = new Button();
            SuspendLayout();
            // 
            // tb_produit
            // 
            tb_produit.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            tb_produit.Location = new Point(295, 12);
            tb_produit.Name = "tb_produit";
            tb_produit.Size = new Size(474, 393);
            tb_produit.TabIndex = 0;
            tb_produit.UseCompatibleStateImageBehavior = false;
            tb_produit.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Produit";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Quantité";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Code Stockage";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 160;
            // 
            // tb_Commande
            // 
            tb_Commande.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6 });
            tb_Commande.Location = new Point(25, 12);
            tb_Commande.Name = "tb_Commande";
            tb_Commande.Size = new Size(264, 141);
            tb_Commande.TabIndex = 1;
            tb_Commande.UseCompatibleStateImageBehavior = false;
            tb_Commande.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "ID";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Libelle";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 160;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(42, 170);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(224, 156);
            textBox1.TabIndex = 2;
            // 
            // Valider_notif
            // 
            Valider_notif.Location = new Point(97, 353);
            Valider_notif.Name = "Valider_notif";
            Valider_notif.Size = new Size(94, 29);
            Valider_notif.TabIndex = 3;
            Valider_notif.Text = "Valider";
            Valider_notif.UseVisualStyleBackColor = true;
            // 
            // Commande_P
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Valider_notif);
            Controls.Add(textBox1);
            Controls.Add(tb_Commande);
            Controls.Add(tb_produit);
            Name = "Commande_P";
            Text = "Commande_P";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView tb_produit;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ListView tb_Commande;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private TextBox textBox1;
        private Button Valider_notif;
    }
}