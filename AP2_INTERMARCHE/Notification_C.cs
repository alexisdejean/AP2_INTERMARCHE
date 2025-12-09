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
                link.Close();


            }
        }

        private void ListeCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ListeCommande.SelectedItems;
            MessageBox.Show("Coucou", item.ToString());
        }

        private void changement_valider_Click(object sender, EventArgs e)
        {
            // VERIFIE LA QUANITEE EN MANQUE POUR LA COMMANDE, RENVOIE LA QUANTITEE MANQUANTE
            int result = 0; // VARIABLE DE SUBSTITUTION
            if (result > 0)
            {
                // AJOUTE LA QUANTITEE EN MANQUE POUR LE PRODUIT DANS LA BASE DE DONNÉES
                bool valid = true;
                if (valid)
                {
                    MessageBox.Show("Quantitée bien mise à jour !", "Information");
                }
                else
                {
                    MessageBox.Show("Problème d'insertion", "Erreur");
                }
                
            }
            else
            {
                MessageBox.Show("Il ne manque pas de stock concernant le produit sélectionné", "Erreur");
            }
        }
    }
}
