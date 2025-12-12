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
            if (ListeCommande.SelectedItems.Count == 0)
            {

                return;
            }
            int codet = int.Parse(ListeProduit.SelectedItems[0].SubItems[0].Text); //L'id de la palette qui va être utilisée
            int quantite = (int)num_quantite.Value; // Quantitée saisie par le Cariste
            int codeProduit = int.Parse(ListeProduit.SelectedItems[0].SubItems[3].Text);
            string connexion = global.connection; // CONNEXION !
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("QuantiteePalette", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@codePalette", SqlDbType.Int).Value = codet;
                link.Open();
                object result = commande.ExecuteScalar();            // RECUPERATION DU RESULTAT     
                link.Close();
                int resultat = Convert.ToInt32(result);
                using SqlConnection linke = new SqlConnection(connexion);
                using SqlCommand commandes = new SqlCommand("TrouverQuantiteeProduit", linke);
                {
                    commandes.CommandType = CommandType.StoredProcedure;
                    commandes.Parameters.Add("@CodePalettePrQuantitee", SqlDbType.Int).Value = codet;
                    link.Open();
                    object resulta = commande.ExecuteScalar();            // RECUPERATION DU RESULTAT     
                    link.Close();
                    int leresult = Convert.ToInt32(resulta);
                    if (leresult > resultat) // S'il y a plus de produits commandés que de produits disponibles sur la palette
                    {
                        if ((resultat + quantite) >= leresult) // Si la somme de la quantitée saisie par le cariste est suprérieure ou égale à la quantité commandée
                        {
                            //APPEL D'UNE PROCEDURE STOCKEE DE MODIFICATION DE DONNEES !
                            using SqlConnection linked = new SqlConnection(connexion);
                            using SqlCommand command = new SqlCommand("InsertionBASEPalette", linked);
                            {
                                commandes.CommandType = CommandType.StoredProcedure;
                                commandes.Parameters.Add("@NumPalette", SqlDbType.Int).Value = codet;
                                commandes.Parameters.Add("@quantiteSaisie", SqlDbType.Int).Value = quantite;
                                commandes.Parameters.Add("@codeProduit", SqlDbType.Int).Value = codeProduit;
                                link.Open();
                                link.Close();

                            }
                            btn_terminer.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Quantitée saisie impossible !", "Erreur");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nul besoin de modifier la quantité de cette palette", "Information");
                        btn_terminer.Enabled = true;
                    }

                }

            }
        }
        public void VerifierPermission()
        {
            if (ListeCommande.Items.Count > 0)
            {
                ListeProduit.Enabled = true;
            }
            if (ListeProduit.Items.Count > 0)
            {
                num_quantite.Enabled = true;
                changement_valider.Enabled = true;
            }

        }

        private void btn_terminer_Click(object sender, EventArgs e)
        {
            int idNotif = int.Parse(ListeCommande.SelectedItems[0].SubItems[0].Text);
            string connetion = global.connection; // CONNEXION !
            using SqlConnection linke = new SqlConnection(connetion);
            using SqlCommand command = new SqlCommand("DELETENOTIF", linke);
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@codeCommande", SqlDbType.Int).Value = idNotif;
                linke.Open();
                linke.Close();
            }
        }
    }
}
