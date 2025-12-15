namespace AP2_INTERMARCHE
{
    partial class ajout_util_R
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
            tb_nom = new TextBox();
            tb_prenom = new TextBox();
            tb_identifiant = new TextBox();
            tb_mdp = new TextBox();
            cb_role = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            bt_ajouter = new Button();
            cb_zone = new ComboBox();
            SuspendLayout();
            // 
            // tb_nom
            // 
            tb_nom.Location = new Point(503, 54);
            tb_nom.Name = "tb_nom";
            tb_nom.Size = new Size(125, 27);
            tb_nom.TabIndex = 0;
            tb_nom.TextChanged += tb_nom_TextChanged;
            // 
            // tb_prenom
            // 
            tb_prenom.Location = new Point(503, 107);
            tb_prenom.Name = "tb_prenom";
            tb_prenom.Size = new Size(125, 27);
            tb_prenom.TabIndex = 1;
            tb_prenom.TextChanged += tb_prenom_TextChanged;
            // 
            // tb_identifiant
            // 
            tb_identifiant.Location = new Point(503, 169);
            tb_identifiant.Name = "tb_identifiant";
            tb_identifiant.Size = new Size(125, 27);
            tb_identifiant.TabIndex = 2;
            tb_identifiant.TextChanged += tb_identifiant_TextChanged;
            // 
            // tb_mdp
            // 
            tb_mdp.Location = new Point(503, 224);
            tb_mdp.Name = "tb_mdp";
            tb_mdp.Size = new Size(125, 27);
            tb_mdp.TabIndex = 3;
            tb_mdp.TextChanged += tb_mdp_TextChanged;
            // 
            // cb_role
            // 
            cb_role.FormattingEnabled = true;
            cb_role.Location = new Point(488, 272);
            cb_role.Name = "cb_role";
            cb_role.Size = new Size(151, 28);
            cb_role.TabIndex = 4;
            cb_role.SelectedIndexChanged += cb_role_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(428, 57);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 5;
            label1.Text = "Nom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(410, 110);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 6;
            label2.Text = "Prénom";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(393, 172);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 7;
            label3.Text = "Identifiant";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(372, 227);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 8;
            label4.Text = "Mot de passe";
            // 
            // bt_ajouter
            // 
            bt_ajouter.Enabled = false;
            bt_ajouter.Location = new Point(425, 369);
            bt_ajouter.Name = "bt_ajouter";
            bt_ajouter.Size = new Size(254, 94);
            bt_ajouter.TabIndex = 9;
            bt_ajouter.Text = "Valider";
            bt_ajouter.UseVisualStyleBackColor = true;
            bt_ajouter.Click += bt_ajouter_Click;
            // 
            // cb_zone
            // 
            cb_zone.FormattingEnabled = true;
            cb_zone.Location = new Point(488, 319);
            cb_zone.Name = "cb_zone";
            cb_zone.Size = new Size(151, 28);
            cb_zone.TabIndex = 10;
            cb_zone.Visible = false;
            // 
            // ajout_util_R
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1228, 488);
            Controls.Add(cb_zone);
            Controls.Add(bt_ajouter);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cb_role);
            Controls.Add(tb_mdp);
            Controls.Add(tb_identifiant);
            Controls.Add(tb_prenom);
            Controls.Add(tb_nom);
            Name = "ajout_util_R";
            Text = "ajout_util_R";
            Load += ajout_util_R_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_nom;
        private TextBox tb_prenom;
        private TextBox tb_identifiant;
        private TextBox tb_mdp;
        private ComboBox cb_role;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button bt_ajouter;
        private ComboBox cb_zone;
    }
}