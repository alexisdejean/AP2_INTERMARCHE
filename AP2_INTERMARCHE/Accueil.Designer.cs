namespace AP2_INTERMARCHE
{
    partial class Accueil
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            pictureBox1 = new PictureBox();
            txt_login = new TextBox();
            txt_mdp = new TextBox();
            btn_login = new Button();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(493, 174);
            label1.Name = "label1";
            label1.Size = new Size(286, 52);
            label1.TabIndex = 0;
            label1.Text = "Bienvenue ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(493, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(286, 159);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txt_login
            // 
            txt_login.Location = new Point(573, 316);
            txt_login.Name = "txt_login";
            txt_login.Size = new Size(125, 27);
            txt_login.TabIndex = 2;
            txt_login.TextChanged += txt_login_TextChanged;
            // 
            // txt_mdp
            // 
            txt_mdp.Location = new Point(573, 370);
            txt_mdp.Name = "txt_mdp";
            txt_mdp.PasswordChar = '*';
            txt_mdp.Size = new Size(125, 27);
            txt_mdp.TabIndex = 3;
            txt_mdp.TextChanged += txt_mdp_TextChanged;
            // 
            // btn_login
            // 
            btn_login.Enabled = false;
            btn_login.Location = new Point(554, 432);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(144, 55);
            btn_login.TabIndex = 4;
            btn_login.Text = "Valider";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(493, 319);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 5;
            label2.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(469, 373);
            label3.Name = "label3";
            label3.Size = new Size(98, 20);
            label3.TabIndex = 6;
            label3.Text = "Mot de passe";
            // 
            // Accueil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 538);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btn_login);
            Controls.Add(txt_mdp);
            Controls.Add(txt_login);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Accueil";
            Text = "Form1";
            Load += Accueil_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private TextBox txt_login;
        private TextBox txt_mdp;
        private Button btn_login;
        private Label label2;
        private Label label3;
    }
}
