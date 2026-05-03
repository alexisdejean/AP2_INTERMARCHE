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
    public partial class home_R : Form
    {
        private Panel? panneauPresentation;

        public home_R()
        {
            InitializeComponent();
            ConfigurerAccueilRole();
            MdiChildActivate += home_R_MdiChildActivate;
            Resize += home_R_Resize;
        }

        private void btn_information_Click(object sender, EventArgs e)
        {
            information_cmd_R info = new information_cmd_R();
            info.MdiParent = this;
            info.WindowState = FormWindowState.Maximized;
            info.Show();
        }

        private void btn_atrib_Click(object sender, EventArgs e)
        {
            attrib_com_R attribution = new attrib_com_R();
            attribution.MdiParent = this;
            attribution.WindowState = FormWindowState.Maximized;
            attribution.Show();
        }

        private void supprimerUtilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionUtilisateur gestion = new GestionUtilisateur();
            gestion.MdiParent = this;
            gestion.WindowState = FormWindowState.Maximized;
            gestion.Show();
        }

        private void ajouterUtilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ajout_util_R ajout = new ajout_util_R();
            ajout.MdiParent = this;
            ajout.WindowState = FormWindowState.Maximized;
            ajout.Show();
        }

        private void ajouterCommandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ajout_commande_R ajout = new ajout_commande_R();
            ajout.MdiParent = this;
            ajout.WindowState = FormWindowState.Maximized;
            ajout.Show();
        }

        private void ConfigurerAccueilRole()
        {
            Text = "Prep'Order | Responsable";
            global.ApplyTheme(this);
            panneauPresentation = global.CreateHeroPanel(
                "Espace responsable",
                "Attribuer les commandes, suivre leur progression et administrer les utilisateurs.",
                "La mission du projet est d'orchestrer la logistique de façon plus lisible et plus rapide pour toutes les équipes."
            );
            AfficherPanneauPresentation();
        }

        private void home_R_MdiChildActivate(object? sender, EventArgs e)
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

        private void home_R_Resize(object? sender, EventArgs e)
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
