using Microsoft.Data.SqlClient;
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
    public partial class Notification_C : Form
    {
        public Notification_C()
        {
            InitializeComponent();
        }

        private void Notification_C_Load(object sender, EventArgs e)
        {
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("Afficherlesnotifs", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                link.Open();
                SqlDataReader datereader = commande.ExecuteReader();
                int id = 0;
                string libelle = "";
                while (datereader.Read())
                {
                    id = datereader.GetInt32(0);
                    libelle = datereader.GetString(1);
                    ListViewItem item = new ListViewItem(id.ToString());
                    item.SubItems.Add(libelle);
                    ListeCommande.Items.Add(item);
                }


            }
        }

        private void ListeCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
