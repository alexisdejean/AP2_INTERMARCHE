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
        public home_R()
        {
            InitializeComponent();
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
    }
}
