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
        public home_P()
        {
            InitializeComponent();
        }
        private void btn_voir_commande_Click(object sender, EventArgs e)
        {
            Commande_P commande = new Commande_P();
            commande.MdiParent = this;
            commande.WindowState = FormWindowState.Maximized;
            commande.Show();
        }
    }
}
