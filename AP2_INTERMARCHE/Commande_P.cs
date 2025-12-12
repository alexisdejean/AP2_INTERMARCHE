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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AP2_INTERMARCHE
{
    public partial class Commande_P : Form
    {
        public Commande_P()
        {
            InitializeComponent();
        }

        private void tb_produit_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true ;
            Valider_notif.Enabled = true;
        }

        private void tb_Commande_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tb_Commande.SelectedItems.Count == 0)
                return;

            int idCommande = int.Parse(tb_Commande.SelectedItems[0].SubItems[0].Text);
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("RecupererPalettes", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@idCommande", SqlDbType.Int).Value = idCommande;

                link.Open();
                SqlDataReader datereader = commande.ExecuteReader();
                int id = 0;
                string libelle = "";
                int quantite = 0;
                int codeStockage = 0;
                while (datereader.Read())
                {
                    id = datereader.GetInt32(0);
                    libelle = datereader.GetString(1);
                    quantite = datereader.GetInt32(2);
                    codeStockage = datereader.GetInt32(3);
                    ListViewItem item = new ListViewItem(id.ToString());
                    item.SubItems.Add(libelle);
                    item.SubItems.Add(quantite.ToString());
                    item.SubItems.Add(codeStockage.ToString());
                    tb_produit.Items.Add(item);
                }
                link.Close();


            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Valider_notif.Enabled = true;
        }

        private void Valider_notif_Click(object sender, EventArgs e)  // S'il y a du contenu dans le message et qu'une palette est sélectionnée, alors insérer une notification
        {
            if (textBox1.Text.Length > 0 && tb_produit.SelectedItems.Count > 0)
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
                    commande.Parameters.Add("@codePalette", SqlDbType.Int, 255).Value = codePalette;
                    commande.Parameters.Add("@codeStockagePalette", SqlDbType.Int, 255).Value = codeStockagePalette;

                    connexion.Open();
                    commande.ExecuteNonQuery();
                    connexion.Close();
                    Valider_notif.Enabled = false;

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_Commande.SelectedItems.Count == 0 || tb_produit.SelectedItems.Count == 0)
                return;

            int idCommande = int.Parse(tb_Commande.SelectedItems[0].SubItems[0].Text);

            int idPalette = int.Parse(tb_produit.SelectedItems[0].SubItems[0].Text);
            int quantitePalette = int.Parse(tb_produit.SelectedItems[0].SubItems[2].Text);
            string connexionString = global.connection;

            using SqlConnection link = new SqlConnection(connexionString);
            using SqlCommand commande = new SqlCommand("SelectQuantiteCommande", link);

            commande.CommandType = CommandType.StoredProcedure;
            commande.Parameters.Add("@idCommande", SqlDbType.Int).Value = idCommande;
            commande.Parameters.Add("@idPalette", SqlDbType.Int).Value = idPalette;

            link.Open();
            object result = commande.ExecuteScalar();
            link.Close();
            // Comparaison des quantités
            if (quantitePalette >= (int)result)
            {
                string connexionStringe = global.connection;

                using SqlConnection linkt = new SqlConnection(connexionString);
                using SqlCommand commander = new SqlCommand("ValiderCommande", linkt);

                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@idCommande", SqlDbType.Int).Value = global.user;
                commande.Parameters.Add("@idPalette", SqlDbType.Int).Value = idCommande;

                link.Open();
                commande.ExecuteNonQuery();
                link.Close();

                MessageBox.Show("Commande validée : quantité suffisante.");
            }
            else
            {
                MessageBox.Show("Stock insuffisant sur cette palette.");
            }
        }

        private void Commande_P_Load(object sender, EventArgs e)
        {

            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("AfficherLesCommande", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                
                link.Open();
                SqlDataReader datereader = commande.ExecuteReader();
                int id = 0;
                string libelle = "";
                string statut = "";
                while (datereader.Read())
                {
                    id = datereader.GetInt32(0);
                    libelle = datereader.GetString(1);
                    statut = datereader.GetString(2);
                    ListViewItem item = new ListViewItem(id.ToString());
                    item.SubItems.Add(libelle);
                    item.SubItems.Add(statut);
                    tb_Commande.Items.Add(item);
                }
                link.Close();


            }
        }
        
        }
    
}
