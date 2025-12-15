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
using static System.Windows.Forms.LinkLabel;

namespace AP2_INTERMARCHE
{
    public partial class GestionUtilisateur : Form
    {
        public GestionUtilisateur()
        {
            InitializeComponent();
        }

        private void GestionUtilisateur_Load(object sender, EventArgs e)
        {
            btn_supprimer.Enabled = false;
            tb_Utilisateur.Items.Clear();
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("afficherlesroles", link);
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
                    cb_role.Items.Add(id.ToString() + ' ' + libelle);
                }
                link.Close();



            }
        }

        private void cb_role_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_supprimer.Enabled = false;
            cb_zone.Items.Clear();
            tb_Utilisateur.Items.Clear();
            string texte = cb_role.SelectedItem.ToString();
            string idString = texte.Split(' ')[0];
            int idrole = int.Parse(idString);
            if (idrole == 2)
            {
                cb_zone.Visible = true;
                string connexion = global.connection;
                using SqlConnection link = new SqlConnection(connexion);
                using SqlCommand commande = new SqlCommand("afficherleszones", link);
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
                        cb_zone.Items.Add(id.ToString() + ' ' + libelle);
                    }
                    link.Close();
                }
            }
            else
            {
                cb_zone.Visible = false;

                string connexion = global.connection;
                using SqlConnection link = new SqlConnection(connexion);
                using SqlCommand commande = new SqlCommand("afficherlesutilisateur", link);
                commande.Parameters.Add("@role", SqlDbType.Int).Value = idrole;
                {
                    commande.CommandType = CommandType.StoredProcedure;
                    link.Open();
                    SqlDataReader datereader = commande.ExecuteReader();
                    int id = 0;
                    string nom = "";
                    string prenom = "";
                    while (datereader.Read())
                    {
                        id = datereader.GetInt32(0);
                        nom = datereader.GetString(1);
                        prenom = datereader.GetString(2);
                        ListViewItem item = new ListViewItem(id.ToString());
                        item.SubItems.Add(nom);
                        item.SubItems.Add(prenom);
                        tb_Utilisateur.Items.Add(item);
                    }
                    link.Close();
                }
            }
        }

        private void cb_zone_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_supprimer.Enabled = false;
            tb_Utilisateur.Items.Clear();
            string texte = cb_zone.SelectedItem.ToString();
            string idString = texte.Split(' ')[0];
            int idZone = int.Parse(idString);
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("AfficherZonepreparateursupprimer", link);
            commande.Parameters.Add("@id", SqlDbType.Int).Value = idZone;
            {
                commande.CommandType = CommandType.StoredProcedure;
                link.Open();
                SqlDataReader datereader = commande.ExecuteReader();
                int id = 0;
                string nom = "";
                string prenom = "";
                while (datereader.Read())
                {
                    id = datereader.GetInt32(0);
                    nom = datereader.GetString(1);
                    prenom = datereader.GetString(2);
                    ListViewItem item = new ListViewItem(id.ToString());
                    item.SubItems.Add(nom);
                    item.SubItems.Add(prenom);
                    tb_Utilisateur.Items.Add(item);
                }
                link.Close();
            }
        }

        private void tb_Utilisateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_supprimer.Enabled = true;
        }

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            tb_Utilisateur.Items.Clear();
            int idutil = int.Parse(tb_Utilisateur.SelectedItems[0].SubItems[0].Text);
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("supprimerUtilisateur", link);
            commande.Parameters.Add("@id",SqlDbType.Int).Value = idutil;
            {
                commande.CommandType = CommandType.StoredProcedure;
                link.Open();
                SqlDataReader datereader = commande.ExecuteReader();
                link.Close();
                MessageBox.Show("suppression reussi");
            }
        }
    }
}
