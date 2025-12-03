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
            ListeCommande.Items.Clear();

            string connectionString = global.connection;
            using (SqlConnection connexion = new SqlConnection(connectionString))
            using (SqlCommand commande = new SqlCommand("Afficherlesnotifs", connexion))
            {
                commande.CommandType = CommandType.StoredProcedure;
                try
                {
                    connexion.Open();


                    using (SqlDataReader reader = commande.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string code = reader["idNotif"].ToString();
                            string libelle = reader["message"].ToString();

                            ListViewItem item = new ListViewItem(code);


                            item.SubItems.Add(libelle);

                            ListeCommande.Items.Add(item);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erreur lors du chargement des notifications: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur inattendue est survenue: " + ex.Message);
                }
            }
        }
        private bool AfficherPalette(int idNotif)
        {
            bool trouve = false;
            string connectionString = global.connection;
            using (SqlConnection connexion = new SqlConnection(connectionString))
            using (SqlCommand commande = new SqlCommand("SelectionNotifCommande", connexion))
            {
                commande.CommandType = CommandType.StoredProcedure;

                // *** Improvement: Use SqlDbType.Int for an integer ID ***
                commande.Parameters.Add("@idNotif", SqlDbType.Int).Value = idNotif;

                try
                {
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
                            item.SubItems.Add(libelle);
                            item.SubItems.Add(zone);

                            ListeProduit.Items.Add(item);
                        }
                        // *** Removed the incorrect call to commande.ExecuteScalar(); ***
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erreur lors de l'affichage de la palette: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur inattendue est survenue: " + ex.Message);
                }

                return trouve;

            }

        }


        private void ListeCommande_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (ListeCommande.SelectedItems.Count > 0)
            {
                // 2. Get the first selected item
                ListViewItem selectedItem = ListeCommande.SelectedItems[0];

                // 3. The Notification ID (idNotif) is in the first column (Index 0).
                //    We retrieve it as a string.
                string idNotifString = selectedItem.SubItems[0].Text;

                // 4. Try to convert the string ID to an integer, as AfficherPalette expects an int.
                if (int.TryParse(idNotifString, out int idNotif))
                {
                    // 5. Clear the ListeProduit control before loading new items
                    ListeProduit.Items.Clear();

                    // 6. Call the function to display the associated palette
                    AfficherPalette(idNotif);
                }
                else
                {
                    MessageBox.Show("Erreur: L'ID de la notification n'est pas un nombre valide.", "Erreur de format");
                }
            }
        }
    }
}
