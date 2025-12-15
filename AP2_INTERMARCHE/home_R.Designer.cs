namespace AP2_INTERMARCHE
{
    partial class home_R
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
            menuStrip1 = new MenuStrip();
            btn_information = new ToolStripMenuItem();
            btn_atrib = new ToolStripMenuItem();
            utilisateurToolStripMenuItem = new ToolStripMenuItem();
            supprimerUtilisateurToolStripMenuItem = new ToolStripMenuItem();
            ajouterUtilisateurToolStripMenuItem = new ToolStripMenuItem();
            ajouterCommandeToolStripMenuItem = new ToolStripMenuItem();
            validerCommandeToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { btn_information, btn_atrib, utilisateurToolStripMenuItem, ajouterCommandeToolStripMenuItem, validerCommandeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1709, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // btn_information
            // 
            btn_information.Name = "btn_information";
            btn_information.Size = new Size(186, 24);
            btn_information.Text = "Informations commande";
            btn_information.Click += btn_information_Click;
            // 
            // btn_atrib
            // 
            btn_atrib.Name = "btn_atrib";
            btn_atrib.Size = new Size(169, 24);
            btn_atrib.Text = "Atribution commande";
            btn_atrib.Click += btn_atrib_Click;
            // 
            // utilisateurToolStripMenuItem
            // 
            utilisateurToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { supprimerUtilisateurToolStripMenuItem, ajouterUtilisateurToolStripMenuItem });
            utilisateurToolStripMenuItem.Name = "utilisateurToolStripMenuItem";
            utilisateurToolStripMenuItem.Size = new Size(90, 24);
            utilisateurToolStripMenuItem.Text = "Utilisateur";
            // 
            // supprimerUtilisateurToolStripMenuItem
            // 
            supprimerUtilisateurToolStripMenuItem.Name = "supprimerUtilisateurToolStripMenuItem";
            supprimerUtilisateurToolStripMenuItem.Size = new Size(232, 26);
            supprimerUtilisateurToolStripMenuItem.Text = "Supprimer Utilisateur";
            supprimerUtilisateurToolStripMenuItem.Click += supprimerUtilisateurToolStripMenuItem_Click;
            // 
            // ajouterUtilisateurToolStripMenuItem
            // 
            ajouterUtilisateurToolStripMenuItem.Name = "ajouterUtilisateurToolStripMenuItem";
            ajouterUtilisateurToolStripMenuItem.Size = new Size(232, 26);
            ajouterUtilisateurToolStripMenuItem.Text = "Ajouter Utilisateur";
            ajouterUtilisateurToolStripMenuItem.Click += ajouterUtilisateurToolStripMenuItem_Click;
            // 
            // ajouterCommandeToolStripMenuItem
            // 
            ajouterCommandeToolStripMenuItem.Name = "ajouterCommandeToolStripMenuItem";
            ajouterCommandeToolStripMenuItem.Size = new Size(151, 24);
            ajouterCommandeToolStripMenuItem.Text = "Ajouter commande";
            ajouterCommandeToolStripMenuItem.Click += ajouterCommandeToolStripMenuItem_Click;
            // 
            // validerCommandeToolStripMenuItem
            // 
            // 
            // home_R
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1709, 783);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "home_R";
            Text = "home_R";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem btn_information;
        private ToolStripMenuItem btn_atrib;
        private ToolStripMenuItem utilisateurToolStripMenuItem;
        private ToolStripMenuItem supprimerUtilisateurToolStripMenuItem;
        private ToolStripMenuItem ajouterUtilisateurToolStripMenuItem;
        private ToolStripMenuItem ajouterCommandeToolStripMenuItem;
        private ToolStripMenuItem validerCommandeToolStripMenuItem;
    }
}