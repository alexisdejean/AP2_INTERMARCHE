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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
            ListeProduit.Items.Clear();
            ListeProduit.Enabled = false;
            num_quantite.Enabled = false;
            changement_valider.Enabled = false;
            btn_terminer.Enabled = false;

            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("Afficherlesnotifs", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                link.Open();
                SqlDataReader datereader = commande.ExecuteReader();
                int id = 0;
                string libelle = "";
                int id_commande = 0;
                while (datereader.Read())
                {
                    id = datereader.GetInt32(0);
                    libelle = datereader.GetString(1);
                    id_commande = datereader.GetInt32(2);
                    ListViewItem item = new ListViewItem(id.ToString());
                    item.SubItems.Add(libelle);
                    item.SubItems.Add(id_commande.ToString());
                    ListeCommande.Items.Add(item);
                }
                link.Close();
                VerifierPermission();


            }
        }

        private void ListeCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListeProduit.Items.Clear();
            num_quantite.Enabled = false;
            changement_valider.Enabled = false;
            btn_terminer.Enabled = false;

            if (ListeCommande.SelectedItems.Count == 0)
            {
                return;
            }

            int code = int.Parse(ListeCommande.SelectedItems[0].SubItems[0].Text);
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("AfficherPalette", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@CodePaletteNotif", SqlDbType.Int).Value = code;
                link.Open();
                SqlDataReader datereader = commande.ExecuteReader();
                int id = 0;
                string libelle = "";
                int id_commande = 0;
                string position = "";
                int code_produit = 0;
                while (datereader.Read())
                {
                    id = datereader.GetInt32(0);
                    libelle = datereader.GetString(1);
                    id_commande = datereader.GetInt32(2);
                    code_produit = datereader.GetInt32(3);
                    position = datereader.GetInt32(3).ToString() + " " + datereader.GetString(4);

                    ListViewItem item = new ListViewItem(id.ToString());
                    item.SubItems.Add(libelle);
                    item.SubItems.Add(position);
                    item.SubItems.Add(code_produit.ToString());
                    ListeProduit.Items.Add(item);
                }
                link.Close();
                VerifierPermission();


            }

        }

        private void changement_valider_Click(object sender, EventArgs e)
        {
            if (ListeProduit.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un produit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int codePalette = int.Parse(ListeProduit.SelectedItems[0].SubItems[0].Text);
                int codeProduit = int.Parse(ListeProduit.SelectedItems[0].SubItems[3].Text);
                int quantiteSaisie = (int)num_quantite.Value;
                string connexion = global.connection;

                using (SqlConnection link = new SqlConnection(connexion))
                {
                    link.Open();

                    // 1. Get palette capacity/quantity
                    int dispoSurPalette = 0;
                    using (SqlCommand cmdDispo = new SqlCommand("QuantiteePalette", link))
                    {
                        cmdDispo.CommandType = CommandType.StoredProcedure;
                        cmdDispo.Parameters.Add("@codePalette", SqlDbType.Int).Value = codePalette;
                        object result = cmdDispo.ExecuteScalar();
                        dispoSurPalette = result != null ? Convert.ToInt32(result) : 0;
                    }

                    // 2. Get required quantity for product
                    int quantiteRequise = 0;
                    using (SqlCommand cmdRequise = new SqlCommand("TrouverQuantiteeProduit", link))
                    {
                        cmdRequise.CommandType = CommandType.StoredProcedure;
                        cmdRequise.Parameters.Add("@CodePalettePrQuantitee", SqlDbType.Int).Value = codePalette;
                        object result = cmdRequise.ExecuteScalar();
                        quantiteRequise = result != null ? Convert.ToInt32(result) : 0;
                    }

                    if (quantiteRequise > dispoSurPalette)
                    {
                        if ((dispoSurPalette + quantiteSaisie) >= quantiteRequise)
                        {
                            // 3. Update/Insert into palette
                            using (SqlCommand cmdInsert = new SqlCommand("InsertionBASEPalette", link))
                            {
                                cmdInsert.CommandType = CommandType.StoredProcedure;
                                cmdInsert.Parameters.Add("@NumPalette", SqlDbType.Int).Value = codePalette;
                                cmdInsert.Parameters.Add("@quantiteSaisie", SqlDbType.Int).Value = quantiteSaisie;
                                cmdInsert.Parameters.Add("@codeProduit", SqlDbType.Int).Value = codeProduit;
                                cmdInsert.ExecuteNonQuery();
                            }
                            MessageBox.Show("Quantité mise à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_terminer.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("La quantité saisie est insuffisante pour couvrir le besoin.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nul besoin de modifier la quantité de cette palette.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_terminer.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la validation du changement : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void VerifierPermission()
        {
            ListeProduit.Enabled = ListeCommande.SelectedItems.Count > 0;
            num_quantite.Enabled = ListeProduit.Items.Count > 0;
            changement_valider.Enabled = ListeProduit.Items.Count > 0;
            btn_terminer.Enabled = ListeCommande.SelectedItems.Count > 0;
        }

        private void btn_terminer_Click(object sender, EventArgs e)
        {
            if (ListeCommande.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une notification.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idNotif = int.Parse(ListeCommande.SelectedItems[0].SubItems[0].Text);
            string connexion = global.connection;

            try
            {
                using (SqlConnection link = new SqlConnection(connexion))
                using (SqlCommand command = new SqlCommand("DELETENOTIF", link))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@codeCommande", SqlDbType.Int).Value = idNotif;
                    link.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Notification traitée et supprimée.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Refresh data
                Notification_C_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression de la notification : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
