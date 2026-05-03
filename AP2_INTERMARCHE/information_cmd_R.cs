using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
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
            LoadData();
        }

        private void LoadData()
        {
            tb_commande.Items.Clear();
            tb_terminer.Items.Clear();

            string connexion = global.connection;
            try
            {
                using (SqlConnection link = new SqlConnection(connexion))
                {
                    link.Open();

                    // Load pending orders
                    using (SqlCommand commande = new SqlCommand("AfficherLesCommandenb", link))
                    {
                        commande.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader datereader = commande.ExecuteReader())
                        {
                            while (datereader.Read())
                            {
                                int id = datereader.GetInt32(0);
                                string libelle = datereader.GetString(1);
                                string statut = datereader.GetString(2);
                                int nb = datereader.GetInt32(3);

                                ListViewItem item = new ListViewItem(id.ToString());
                                item.SubItems.Add(libelle);
                                item.SubItems.Add(nb.ToString());
                                item.SubItems.Add(statut);
                                tb_commande.Items.Add(item);
                            }
                        }
                    }

                    // Load completed orders
                    using (SqlCommand cmd = new SqlCommand("afficherlescommandeterminer", link))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader datereader = cmd.ExecuteReader())
                        {
                            while (datereader.Read())
                            {
                                int id = datereader.GetInt32(0);
                                string libelle = datereader.GetString(1);
                                string statut = datereader.GetString(2);
                                int nb = datereader.GetInt32(3);

                                ListViewItem item = new ListViewItem(id.ToString());
                                item.SubItems.Add(libelle);
                                item.SubItems.Add(nb.ToString());
                                item.SubItems.Add(statut);
                                tb_terminer.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_valider_cmd_Click(object sender, EventArgs e)
        {
            if (tb_commande.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une commande à valider.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idCommande = int.Parse(tb_commande.SelectedItems[0].SubItems[0].Text);
            string connexion = global.connection;

            try
            {
                using (SqlConnection link = new SqlConnection(connexion))
                using (SqlCommand commande = new SqlCommand("Valider_commande", link))
                {
                    commande.CommandType = CommandType.StoredProcedure;
                    commande.Parameters.Add("@idcmd", SqlDbType.Int).Value = idCommande;
                    link.Open();
                    commande.ExecuteNonQuery();
                }

                MessageBox.Show("Commande validée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Refresh the list instead of closing/reopening the form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la validation : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
