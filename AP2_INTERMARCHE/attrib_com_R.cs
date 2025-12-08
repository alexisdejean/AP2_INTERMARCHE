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
    public partial class attrib_com_R : Form
    {
        public attrib_com_R()
        {
            InitializeComponent();
        }

        private void attrib_com_R_Load(object sender, EventArgs e) // PROCÉDURE NON CONFIGURÉE
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
                    List_Commande.Items.Add(item);
                }


            }
        }

        private void List_Commande_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_Zone_SelectedIndexChanged(object sender, EventArgs e)
        {
            object objet = List_Commande.SelectedItems;
            // PROÉDURE QUI VA RECHERCHER LA ZONE DE LA COMMANDE
        }
    }
}
