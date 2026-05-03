using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP2_INTERMARCHE
{
    public partial class Commande_P : Form
    {
        public Commande_P()
        {
            InitializeComponent();
            // global.ApplyTheme(this); // Commented out as I'm not sure if ApplyTheme exists in the current version of global.cs
            Text = "Prep'Order | Préparation";
        }

        private void Commande_P_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            tb_Commande.Items.Clear();
            string connexion = global.connection;
            try
            {
                using (SqlConnection link = new SqlConnection(connexion))
                using (SqlCommand commande = new SqlCommand("AfficherLesCommande", link))
                {
                    commande.CommandType = CommandType.StoredProcedure;
                    link.Open();
                    using (SqlDataReader datereader = commande.ExecuteReader())
                    {
                        while (datereader.Read())
                        {
                            int id = datereader.GetInt32(0);
                            string libelle = datereader.GetString(1);
                            string statut = datereader.GetString(2);
                            ListViewItem item = new ListViewItem(id.ToString());
                            item.SubItems.Add(libelle);
                            item.SubItems.Add(statut);
                            tb_Commande.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des commandes : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_produit_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = tb_produit.SelectedItems.Count > 0;
            Valider_notif.Enabled = tb_produit.SelectedItems.Count > 0 && textBox1.TextLength > 0;
        }

        private void tb_Commande_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tb_Commande.SelectedItems.Count == 0)
                return;

            tb_produit.Items.Clear();
            textBox1.Clear();
            textBox1.Enabled = false;
            Valider_notif.Enabled = false;
            button1.Enabled = false;

            try
            {
                int idCommande = int.Parse(tb_Commande.SelectedItems[0].SubItems[0].Text);
                string connexion = global.connection;
                using (SqlConnection link = new SqlConnection(connexion))
                using (SqlCommand commande = new SqlCommand("RecupererPalettes", link))
                {
                    commande.CommandType = CommandType.StoredProcedure;
                    commande.Parameters.Add("@idCommande", SqlDbType.Int).Value = idCommande;

                    link.Open();
                    using (SqlDataReader datereader = commande.ExecuteReader())
                    {
                        while (datereader.Read())
                        {
                            int id = datereader.GetInt32(0);
                            string libelle = datereader.GetString(1);
                            int quantite = datereader.GetInt32(2);
                            int codeStockage = datereader.GetInt32(3);
                            ListViewItem item = new ListViewItem(id.ToString());
                            item.SubItems.Add(libelle);
                            item.SubItems.Add(quantite.ToString());
                            item.SubItems.Add(codeStockage.ToString());
                            tb_produit.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des palettes : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Valider_notif.Enabled = tb_produit.SelectedItems.Count > 0 && textBox1.TextLength > 0;
        }

        private void Valider_notif_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || tb_produit.SelectedItems.Count == 0)
                return;

            try
            {
                string message = textBox1.Text;
                int codePalette = int.Parse(tb_produit.SelectedItems[0].SubItems[0].Text);
                int codeStockagePalette = int.Parse(tb_produit.SelectedItems[0].SubItems[3].Text);
                string connectionString = global.connection;

                using (SqlConnection connexion = new SqlConnection(connectionString))
                using (SqlCommand commande = new SqlCommand("CreerNotif", connexion))
                {
                    commande.CommandType = CommandType.StoredProcedure;
                    commande.Parameters.Add("@message", SqlDbType.VarChar, 100).Value = message;
                    commande.Parameters.Add("@codePalette", SqlDbType.Int).Value = codePalette;
                    commande.Parameters.Add("@codeStockagePalette", SqlDbType.Int).Value = codeStockagePalette;

                    connexion.Open();
                    commande.ExecuteNonQuery();
                }

                MessageBox.Show("Notification envoyée !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Valider_notif.Enabled = false;
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'envoi de la notification : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_Commande.SelectedItems.Count == 0 || tb_produit.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une commande et une palette.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int idCommande = int.Parse(tb_Commande.SelectedItems[0].SubItems[0].Text);
                int idPalette = int.Parse(tb_produit.SelectedItems[0].SubItems[0].Text);
                int quantitePalette = int.Parse(tb_produit.SelectedItems[0].SubItems[2].Text);
                string connexionString = global.connection;

                using (SqlConnection link = new SqlConnection(connexionString))
                {
                    link.Open();

                    // 1. Check required quantity
                    int quantiteDemandee = 0;
                    using (SqlCommand commande = new SqlCommand("SelectQuantiteCommande", link))
                    {
                        commande.CommandType = CommandType.StoredProcedure;
                        commande.Parameters.Add("@idCommande", SqlDbType.Int).Value = idCommande;
                        commande.Parameters.Add("@idPalette", SqlDbType.Int).Value = idPalette;
                        object result = commande.ExecuteScalar();
                        quantiteDemandee = result == null ? 0 : Convert.ToInt32(result);
                    }

                    if (quantitePalette >= quantiteDemandee)
                    {
                        // 2. Validate order
                        using (SqlCommand commander = new SqlCommand("Valider_commande", link))
                        {
                            commander.CommandType = CommandType.StoredProcedure;
                            commander.Parameters.Add("@idcmd", SqlDbType.Int).Value = idCommande;
                            commander.ExecuteNonQuery();
                        }

                        MessageBox.Show("Commande validée : quantité suffisante.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders(); // Refresh order list
                    }
                    else
                    {
                        MessageBox.Show("Stock insuffisant sur cette palette.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la validation de la commande : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
