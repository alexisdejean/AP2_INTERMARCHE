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
using System.Windows.Input;

namespace AP2_INTERMARCHE
{
    public partial class attrib_com_R : Form
    {
        public attrib_com_R()
        {
            InitializeComponent();
        }

        private void attrib_com_R_Load(object sender, EventArgs e) // PROCÉDURE NON CONFIGURÉE
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
                    List_Commande.Items.Add(item);
                }
                link.Close();


            }
        }

        private void List_Commande_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Zone.SelectedIndex >= 0 && tb_Utilisateur.SelectedItems.Count > 0 && List_Commande.SelectedItems.Count > 0)
            {
                Valider_attrib.Enabled = true;
            }
            else
            {
                Valider_attrib.Enabled = false;
            }
            cb_Zone.Items.Clear();
            cb_Zone.SelectedIndex = -1;
            cb_Zone.Text = "";
            tb_Utilisateur.Items.Clear();
            if (List_Commande.SelectedItems.Count == 0)
                return;
            int idCommande = int.Parse(List_Commande.SelectedItems[0].SubItems[0].Text);
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("AfficherZoneCommande", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@id", SqlDbType.Int).Value = idCommande;
                link.Open();
                SqlDataReader datereader = commande.ExecuteReader();
                int id = 0;
                string libelle = "";
                while (datereader.Read())
                {
                    id = datereader.GetInt32(0);
                    libelle = datereader.GetString(1);
                    cb_Zone.Items.Add(id.ToString() + ' ' + libelle);
                }
                link.Close();


            }
        }

        private void cb_Zone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Zone.SelectedIndex >= 0 && tb_Utilisateur.SelectedItems.Count > 0 && List_Commande.SelectedItems.Count > 0)
            {
                Valider_attrib.Enabled = true;
            }
            else
            {
                Valider_attrib.Enabled = false;
            }
            if (List_Commande.SelectedItems.Count == 0)
                return;
            int idCommande = int.Parse(List_Commande.SelectedItems[0].SubItems[0].Text);

            tb_Utilisateur.Items.Clear();
            string texte = cb_Zone.SelectedItem.ToString();
            string idString = texte.Split(' ')[0];
            int idZone = int.Parse(idString);
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("AfficherZonepreparateur", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@id", SqlDbType.Int).Value = idZone;
                commande.Parameters.Add("@idcmd", SqlDbType.Int).Value = idCommande;
                link.Open();
                SqlDataReader datereader = commande.ExecuteReader();
                int id = 0;
                string nom;
                string prenom;
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
            if (cb_Zone.SelectedIndex >= 0 && tb_Utilisateur.SelectedItems.Count > 0 && List_Commande.SelectedItems.Count > 0)
            {
                Valider_attrib.Enabled = true;
            }
            else
            {
                Valider_attrib.Enabled = false;
            }
        }

        private void Valider_attrib_Click(object sender, EventArgs e)
        {
            int idCommande = int.Parse(List_Commande.SelectedItems[0].SubItems[0].Text);
            int idutil = int.Parse(tb_Utilisateur.SelectedItems[0].SubItems[0].Text);
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("AttributionUtil", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@idcmd", SqlDbType.Int).Value = idCommande;
                commande.Parameters.Add("@idutilisateur", SqlDbType.Int).Value = idutil;
                link.Open();
                SqlDataReader datereader = commande.ExecuteReader();
                link.Close();
                MessageBox.Show("ajout reussi");

                cb_Zone.Items.Clear();
                cb_Zone.SelectedIndex = -1;
                cb_Zone.Text = "";
                tb_Utilisateur.Items.Clear();

                if (List_Commande.SelectedItems.Count == 0)
                {
                    return;
                }
                
                if (tb_Utilisateur.SelectedItems.Count == 0)
                {
                    return;
                }

            }
        }
    }
}
