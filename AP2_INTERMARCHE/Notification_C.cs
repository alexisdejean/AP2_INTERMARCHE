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

        }
        private bool AfficherPalette(int idNotif)
        {
            bool trouve = false;
            string connectionString = global.connection;
            using (SqlConnection connexion = new SqlConnection(connectionString))
            using (SqlCommand commande = new SqlCommand("SelectionNotifCommande", connexion))
            {
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@idNotif", SqlDbType.VarChar, 100).Value = idNotif;
                connexion.Open();
                using (SqlDataReader reader = commande.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        trouve = true;
                        string code = reader["codePalette"].ToString();
                        string libelle = reader["libellePalette"].ToString();
                        string zone = reader["paletteZone"].ToString();

                        ListViewItem item = new ListViewItem(code);

                        // 3. Ajout des sous-éléments dans l'ordre des colonnes
                        item.SubItems.Add(libelle);
                        item.SubItems.Add(zone);

                        // 4. Ajout de l'élément complet à la ListView
                        ListeProduit.Items.Add(item);
                    }
                    object result = commande.ExecuteScalar();
                    
                }

             return trouve;
            }
            
        }

        private void ListeCommande_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
