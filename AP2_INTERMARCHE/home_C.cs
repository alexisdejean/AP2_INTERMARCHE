using Microsoft.VisualBasic.Logging;
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
    public partial class home_C : Form
    {
        private Panel? panneauPresentation;

        public home_C()
        {
            InitializeComponent();
            ConfigurerAccueilRole();
            MdiChildActivate += home_C_MdiChildActivate;
            Resize += home_C_Resize;
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            Log_produit_C log = new Log_produit_C();
            log.MdiParent = this;
            log.WindowState = FormWindowState.Maximized;
            log.Show();
        }

        private void btn_commande_Click(object sender, EventArgs e)
        {
            Notification_C commande = new Notification_C();
            commande.MdiParent = this;
            commande.WindowState = FormWindowState.Maximized;
            commande.Show();
        }

        private void ConfigurerAccueilRole()
        {
            Text = "Prep'Order | Cariste";
            global.ApplyTheme(this);
            panneauPresentation = global.CreateHeroPanel(
                "Espace cariste",
                "Traiter les alertes terrain, corriger les palettes et sécuriser le stock réel.",
                "Le projet existe pour éviter que les commandes se bloquent entre le besoin magasin et la réalité physique de l'entrepôt."
            );
            AfficherPanneauPresentation();
        }

        private void home_C_MdiChildActivate(object? sender, EventArgs e)
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

        private void home_C_Resize(object? sender, EventArgs e)
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
