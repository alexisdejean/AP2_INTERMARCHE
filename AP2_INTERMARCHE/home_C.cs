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
        public home_C()
        {
            InitializeComponent();
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
    }
}
