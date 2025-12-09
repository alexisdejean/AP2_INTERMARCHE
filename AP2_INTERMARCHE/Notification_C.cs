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


            }
        }

        private void ListeCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                while (datereader.Read())
                {
                    id = datereader.GetInt32(0);
                    libelle = datereader.GetString(1);
                    id_commande = datereader.GetInt32(2);
                    position = datereader.GetInt32(3).ToString() + " " + datereader.GetString(4);
                    ListViewItem item = new ListViewItem(id.ToString());
                    item.SubItems.Add(libelle);
                    item.SubItems.Add(position);
                    ListeProduit.Items.Add(item);
                }
                link.Close();


            }

        }

        private void changement_valider_Click(object sender, EventArgs e)
        {
            int code = int.Parse(ListeProduit.SelectedItems[0].SubItems[0].Text); //L'id de la palette qui va être utilisée
            int quantite = 0; // Quantitée saisie par le Cariste
            string connexion = global.connection; // CONNEXION !
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("QuantiteePalette", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@CodePalette", SqlDbType.Int).Value = code;
                link.Open();
                object result = commande.ExecuteScalar();            // RECUPERATION DU RESULTAT     
                link.Close();
                int resultat = Convert.ToInt32(result);
                if (resultat > quantite) // SI Il y'a moins de quantitée saisie par le Cariste que de place sur la palette alors : 
                {
                    string connetion = global.connection; // CONNEXION !
                    using SqlConnection linke = new SqlConnection(connetion);
                    using SqlCommand commandes = new SqlCommand("TrouverQuantiteeProduit", link);
                    {
                        commandes.CommandType = CommandType.StoredProcedure;
                        commandes.Parameters.Add("@CodePalettePrQuantitee", SqlDbType.Int).Value = code;
                        link.Open();
                        object resulta = commande.ExecuteScalar();            // RECUPERATION DU RESULTAT     
                        link.Close();
                        int leresult = Convert.ToInt32(resulta);
                        if ((leresult + quantite) <= resultat) // Si la quantitée de produit initiale + la quantitée saisie est inférieure à la capacité d'une palette alors :
                        {
                            MessageBox.Show("Quantitée bien mise à jour !", "Information");
                        }
                        else // Sinon
                        {
                            MessageBox.Show("Mais quelle erreur du joueur Français !", "Erreur");
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Il ne manque pas de stock concernant le produit sélectionné", "Erreur");
                }


            }
        }
    }
}
