using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP2_INTERMARCHE
{
    public partial class information_cmd_R : Form
    {
        public information_cmd_R()
        {
            InitializeComponent();
        }

        private void information_cmd_R_Load(object sender, EventArgs e)
        {
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("AfficherLesCommandenb", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                link.Open();
                SqlDataReader datereader = commande.ExecuteReader();
                int id = 0;
                string libelle = "";
                string statut = "";
                int nb;
                while (datereader.Read())
                {
                    id = datereader.GetInt32(0);
                    libelle = datereader.GetString(1);
                    statut = datereader.GetString(2);
                    nb = datereader.GetInt32(3);
                    ListViewItem item = new ListViewItem(id.ToString());
                    item.SubItems.Add(libelle);
                    item.SubItems.Add(nb.ToString());
                    item.SubItems.Add(statut);
                    tb_commande.Items.Add(item);
                }
                link.Close();
            }
            
            using SqlCommand cmd = new SqlCommand("afficherlescommandeterminer", link);
            {
                cmd.CommandType = CommandType.StoredProcedure;
                link.Open();
                SqlDataReader datereader = cmd.ExecuteReader();
                int id = 0;
                string libelle = "";
                string statut = "";
                int nb;
                while (datereader.Read())
                {
                    id = datereader.GetInt32(0);
                    libelle = datereader.GetString(1);
                    statut = datereader.GetString(2);
                    nb = datereader.GetInt32(3);
                    ListViewItem item = new ListViewItem(id.ToString());
                    item.SubItems.Add(libelle);
                    item.SubItems.Add(nb.ToString());
                    item.SubItems.Add(statut);
                    tb_terminer.Items.Add(item);
                }
                link.Close();
            }
        }
    }
}
