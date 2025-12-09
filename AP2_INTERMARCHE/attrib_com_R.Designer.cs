namespace AP2_INTERMARCHE
{
    partial class attrib_com_R
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
            List_Commande = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            tb_Utilisateur = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            cb_Zone = new ComboBox();
            Valider_attrib = new Button();
            SuspendLayout();
            // 
            // List_Commande
            // 
            List_Commande.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            List_Commande.Location = new Point(12, 51);
            List_Commande.Name = "List_Commande";
            List_Commande.Size = new Size(522, 416);
            List_Commande.TabIndex = 0;
            List_Commande.UseCompatibleStateImageBehavior = false;
            List_Commande.View = View.Details;
            List_Commande.SelectedIndexChanged += List_Commande_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Libelle";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Status";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 90;
            // 
            // tb_Utilisateur
            // 
            tb_Utilisateur.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6 });
            tb_Utilisateur.Location = new Point(697, 51);
            tb_Utilisateur.Name = "tb_Utilisateur";
            tb_Utilisateur.Size = new Size(473, 416);
            tb_Utilisateur.TabIndex = 1;
            tb_Utilisateur.UseCompatibleStateImageBehavior = false;
            tb_Utilisateur.View = View.Details;
            tb_Utilisateur.SelectedIndexChanged += tb_Utilisateur_SelectedIndexChanged;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "ID";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Nom";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Prénom";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 200;
            // 
            // cb_Zone
            // 
            cb_Zone.FormattingEnabled = true;
            cb_Zone.Location = new Point(540, 153);
            cb_Zone.Name = "cb_Zone";
            cb_Zone.Size = new Size(151, 28);
            cb_Zone.TabIndex = 2;
            cb_Zone.SelectedIndexChanged += cb_Zone_SelectedIndexChanged;
            // 
            // Valider_attrib
            // 
            Valider_attrib.Enabled = false;
            Valider_attrib.Location = new Point(564, 273);
            Valider_attrib.Name = "Valider_attrib";
            Valider_attrib.Size = new Size(94, 29);
            Valider_attrib.TabIndex = 3;
            Valider_attrib.Text = "Valider";
            Valider_attrib.UseVisualStyleBackColor = true;
            Valider_attrib.Click += Valider_attrib_Click;
            // 
            // attrib_com_R
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 509);
            Controls.Add(Valider_attrib);
            Controls.Add(cb_Zone);
            Controls.Add(tb_Utilisateur);
            Controls.Add(List_Commande);
            Name = "attrib_com_R";
            Text = "attrib_com_R";
            Load += attrib_com_R_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView List_Commande;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ListView tb_Utilisateur;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ComboBox cb_Zone;
        private Button Valider_attrib;
    }
}