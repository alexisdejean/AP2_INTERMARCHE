namespace AP2_INTERMARCHE
{
    partial class GestionUtilisateur
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
            cb_role = new ComboBox();
            cb_zone = new ComboBox();
            tb_Utilisateur = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            btn_supprimer = new Button();
            SuspendLayout();
            // 
            // cb_role
            // 
            cb_role.FormattingEnabled = true;
            cb_role.Location = new Point(658, 71);
            cb_role.Name = "cb_role";
            cb_role.Size = new Size(194, 28);
            cb_role.TabIndex = 0;
            cb_role.SelectedIndexChanged += cb_role_SelectedIndexChanged;
            // 
            // cb_zone
            // 
            cb_zone.FormattingEnabled = true;
            cb_zone.Location = new Point(658, 140);
            cb_zone.Name = "cb_zone";
            cb_zone.Size = new Size(194, 28);
            cb_zone.TabIndex = 1;
            cb_zone.Visible = false;
            cb_zone.SelectedIndexChanged += cb_zone_SelectedIndexChanged;
            // 
            // tb_Utilisateur
            // 
            tb_Utilisateur.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6 });
            tb_Utilisateur.Location = new Point(520, 230);
            tb_Utilisateur.Name = "tb_Utilisateur";
            tb_Utilisateur.Size = new Size(473, 416);
            tb_Utilisateur.TabIndex = 2;
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
            // btn_supprimer
            // 
            btn_supprimer.Location = new Point(658, 708);
            btn_supprimer.Name = "btn_supprimer";
            btn_supprimer.Size = new Size(186, 85);
            btn_supprimer.TabIndex = 3;
            btn_supprimer.Text = "Supprimer";
            btn_supprimer.UseVisualStyleBackColor = true;
            btn_supprimer.Click += btn_supprimer_Click;
            // 
            // GestionUtilisateur
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1688, 839);
            Controls.Add(btn_supprimer);
            Controls.Add(tb_Utilisateur);
            Controls.Add(cb_zone);
            Controls.Add(cb_role);
            Name = "GestionUtilisateur";
            Text = "GestionUtilisateur";
            Load += GestionUtilisateur_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cb_role;
        private ComboBox cb_zone;
        private ListView tb_Utilisateur;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Button btn_supprimer;
    }
}