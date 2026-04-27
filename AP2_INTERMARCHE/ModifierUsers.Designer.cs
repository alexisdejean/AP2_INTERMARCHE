namespace AP2_INTERMARCHE
{
    partial class ModifierUsers
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
            label7 = new Label();
            btn_ajouter = new Button();
            cb_zone_add = new ComboBox();
            label6 = new Label();
            cb_role_add = new ComboBox();
            label5 = new Label();
            txt_password = new TextBox();
            label4 = new Label();
            txt_identifiant = new TextBox();
            label3 = new Label();
            txt_prenom = new TextBox();
            label2 = new Label();
            txt_nom = new TextBox();
            label1 = new Label();
            cb_user_list = new ComboBox();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(342, 33);
            label7.Name = "label7";
            label7.Size = new Size(199, 28);
            label7.TabIndex = 31;
            label7.Text = "Modifier Utilisateur";
            // 
            // btn_ajouter
            // 
            btn_ajouter.Location = new Point(97, 540);
            btn_ajouter.Name = "btn_ajouter";
            btn_ajouter.Size = new Size(200, 50);
            btn_ajouter.TabIndex = 30;
            btn_ajouter.Text = "Modifier Utilisateur";
            btn_ajouter.UseVisualStyleBackColor = true;
            // 
            // cb_zone_add
            // 
            cb_zone_add.FormattingEnabled = true;
            cb_zone_add.Location = new Point(97, 483);
            cb_zone_add.Name = "cb_zone_add";
            cb_zone_add.Size = new Size(200, 28);
            cb_zone_add.TabIndex = 29;
            cb_zone_add.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(97, 460);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 28;
            label6.Text = "Zone :";
            label6.Visible = false;
            // 
            // cb_role_add
            // 
            cb_role_add.FormattingEnabled = true;
            cb_role_add.Location = new Point(97, 413);
            cb_role_add.Name = "cb_role_add";
            cb_role_add.Size = new Size(200, 28);
            cb_role_add.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(97, 390);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 26;
            label5.Text = "Rôle :";
            // 
            // txt_password
            // 
            txt_password.Location = new Point(97, 343);
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '*';
            txt_password.Size = new Size(200, 27);
            txt_password.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(97, 320);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 24;
            label4.Text = "Mot de passe :";
            // 
            // txt_identifiant
            // 
            txt_identifiant.Location = new Point(97, 273);
            txt_identifiant.Name = "txt_identifiant";
            txt_identifiant.Size = new Size(200, 27);
            txt_identifiant.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(97, 250);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 22;
            label3.Text = "Identifiant :";
            // 
            // txt_prenom
            // 
            txt_prenom.Location = new Point(97, 203);
            txt_prenom.Name = "txt_prenom";
            txt_prenom.Size = new Size(200, 27);
            txt_prenom.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 180);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 20;
            label2.Text = "Prénom :";
            // 
            // txt_nom
            // 
            txt_nom.Location = new Point(97, 134);
            txt_nom.Name = "txt_nom";
            txt_nom.Size = new Size(200, 27);
            txt_nom.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 111);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 18;
            label1.Text = "Nom :";
            // 
            // cb_user_list
            // 
            cb_user_list.FormattingEnabled = true;
            cb_user_list.Location = new Point(569, 123);
            cb_user_list.Name = "cb_user_list";
            cb_user_list.Size = new Size(151, 28);
            cb_user_list.TabIndex = 32;
            cb_user_list.SelectedIndexChanged += cb_user_list_SelectedIndexChanged;
            // 
            // ModifierUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 616);
            Controls.Add(cb_user_list);
            Controls.Add(label7);
            Controls.Add(btn_ajouter);
            Controls.Add(cb_zone_add);
            Controls.Add(label6);
            Controls.Add(cb_role_add);
            Controls.Add(label5);
            Controls.Add(txt_password);
            Controls.Add(label4);
            Controls.Add(txt_identifiant);
            Controls.Add(label3);
            Controls.Add(txt_prenom);
            Controls.Add(label2);
            Controls.Add(txt_nom);
            Controls.Add(label1);
            Name = "ModifierUsers";
            Text = "Form1";
            Load += ModifierUsers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Button btn_ajouter;
        private ComboBox cb_zone_add;
        private Label label6;
        private ComboBox cb_role_add;
        private Label label5;
        private TextBox txt_password;
        private Label label4;
        private TextBox txt_identifiant;
        private Label label3;
        private TextBox txt_prenom;
        private Label label2;
        private TextBox txt_nom;
        private Label label1;
        private ComboBox cb_user_list;
    }
}