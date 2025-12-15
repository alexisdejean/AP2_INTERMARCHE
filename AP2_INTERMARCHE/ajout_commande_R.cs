using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AP2_INTERMARCHE
{
    public partial class ajout_commande_R : Form
    {
        public ajout_commande_R()
        {
            InitializeComponent();
        }

        private void ajouter_commande_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Fichiers CSV (*.csv)|*.csv|Tous les fichiers (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    LireFichierCSV(filePath);
                }
            }
        }

        private void LireFichierCSV(string filePath)
        {
            if (cb_commande.SelectedItem == null)
            {
                MessageBox.Show("Veuillez d'abord sélectionner une commande");
                return;
            }

            string texte = cb_commande.SelectedItem.ToString();
            string idString = texte.Split(' ')[0];
            int idcommande = int.Parse(idString);

            try
            {
                List<string> toutesLesLignes = File.ReadAllLines(filePath).ToList();

                if (toutesLesLignes.Count == 0)
                {
                    MessageBox.Show("Le fichier CSV est vide");
                    return;
                }
                toutesLesLignes.RemoveAt(0);
                foreach (string ligne in toutesLesLignes)
                {
                    List<string> colonnes = ligne.Split(',').ToList();

                    if (colonnes.Count >= 2)
                    {
                        string nomProduit = colonnes[0];
                        string qteProduit = colonnes[1];
                        InsererLigneDansBD(idcommande, nomProduit, qteProduit);

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool InsererLigneDansBD(int idCommande, string nomProduit, string qteProduit)
        {
            string connexion = global.connection;

            try
            {
                using (SqlConnection link = new SqlConnection(connexion))
                {
                    link.Open();

                    using (SqlCommand commande = new SqlCommand("ajouter_commande", link))
                    {
                        commande.CommandType = CommandType.StoredProcedure;

                        commande.Parameters.Add("@idcommande", SqlDbType.Int).Value = idCommande;
                        commande.Parameters.Add("@nomProduit", SqlDbType.NVarChar).Value = nomProduit;
                        commande.Parameters.Add("@qteproduit", SqlDbType.Int).Value = qteProduit;
                        commande.ExecuteScalar();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur BD pour le produit '{nomProduit}': {ex.Message}");
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connexion = global.connection;
            using (SqlConnection link = new SqlConnection(connexion))
            {
                link.Open();
                using (SqlCommand commande = new SqlCommand("ajout_magasin", link))
                {
                    commande.CommandType = CommandType.StoredProcedure;
                    commande.Parameters.Add("@libelle",SqlDbType.VarChar).Value = tb_libelle_magasin.Text;
                    commande.ExecuteScalar();
                }
            }
        }
    }
}