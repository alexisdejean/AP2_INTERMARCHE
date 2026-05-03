using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP2_INTERMARCHE
{
    public partial class home_P : Form
    {
        private Panel? panneauPresentation;

        public home_P()
        {
            InitializeComponent();
            ConfigurerAccueilRole();
            MdiChildActivate += home_P_MdiChildActivate;
            Resize += home_P_Resize;
        }
        private void btn_voir_commande_Click(object sender, EventArgs e)
        {
            Commande_P commande = new Commande_P();
            commande.MdiParent = this;
            commande.WindowState = FormWindowState.Maximized;
            commande.Show();
        }

        private void ConfigurerAccueilRole()
        {
            Text = "Prep'Order | Préparateur";
            global.ApplyTheme(this);
            panneauPresentation = global.CreateHeroPanel(
                "Espace préparateur",
                "Voir les commandes, contrôler les palettes et signaler rapidement un manque.",
                "La valeur du projet est de transformer un suivi dispersé en un flux clair entre commande, palette et action terrain."
            );
            AfficherPanneauPresentation();
        }

        private void home_P_MdiChildActivate(object? sender, EventArgs e)
        {
            if (panneauPresentation != null)
            {
                panneauPresentation.Visible = ActiveMdiChild == null;
            }
        }

        private void AfficherPanneauPresentation()
        {
            if (panneauPresentation == null)
            {
                return;
            }

            if (!Controls.Contains(panneauPresentation))
            {
                Controls.Add(panneauPresentation);
            }

            panneauPresentation.Anchor = AnchorStyles.Top;
            PositionnerPanneauPresentation();
            panneauPresentation.BringToFront();
        }

        private void home_P_Resize(object? sender, EventArgs e)
        {
            PositionnerPanneauPresentation();
        }

        private void PositionnerPanneauPresentation()
        {
            if (panneauPresentation == null)
            {
                return;
            }

            int top = (MainMenuStrip?.Bottom ?? 0) + 32;
            int left = Math.Max((ClientSize.Width - panneauPresentation.Width) / 2, 24);
            panneauPresentation.Location = new Point(left, top);
        }

        private void seDeconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form enfant in MdiChildren)
            {
                enfant.Close();
            }

            global.role = 0;
            global.user = 0;

            if (Owner is Accueil accueil)
            {
                accueil.Show();
                accueil.BringToFront();
            }

            Close();
        }
    }
}
