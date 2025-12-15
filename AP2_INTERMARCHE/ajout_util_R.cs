using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP2_INTERMARCHE
{
    public partial class ajout_util_R : Form
    {
        public ajout_util_R()
        {
            InitializeComponent();
        }

        private void ajout_util_R_Load(object sender, EventArgs e)
        {
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

        private void tb_nom_TextChanged(object sender, EventArgs e)
        {
            if (tb_nom.Text != "" && tb_prenom.Text != "" && tb_identifiant.Text != "" && tb_mdp.Text != "")
            {
                bt_ajouter.Enabled = true;
            }
            else { bt_ajouter.Enabled = false; }
        }

        private void tb_prenom_TextChanged(object sender, EventArgs e)
        {
            if (tb_nom.Text != "" && tb_prenom.Text != "" && tb_identifiant.Text != "" && tb_mdp.Text != "")
            {
                bt_ajouter.Enabled = true;
            }
            else { bt_ajouter.Enabled = false; }
        }

        private void tb_identifiant_TextChanged(object sender, EventArgs e)
        {
            if (tb_nom.Text != "" && tb_prenom.Text != "" && tb_identifiant.Text != "" && tb_mdp.Text != "")
            {
                bt_ajouter.Enabled = true;
            }
            else { bt_ajouter.Enabled = false; }
        }

        private void tb_mdp_TextChanged(object sender, EventArgs e)
        {
            if (tb_nom.Text != "" && tb_prenom.Text != "" && tb_identifiant.Text != "" && tb_mdp.Text != "")
            {
                bt_ajouter.Enabled = true;
            }
            else { bt_ajouter.Enabled = false; }
        }

        private void cb_role_SelectedIndexChanged(object sender, EventArgs e)
        {

            string texte = cb_role.SelectedItem.ToString();
            string idString = texte.Split(' ')[0];
            int idrole = int.Parse(idString);

            if (idrole == 2)
            {
                cb_zone.Visible = true;
            }
            else
            {
                cb_zone.Visible = false;
            }
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            string texte = cb_role.SelectedItem.ToString();
            string idString = texte.Split(' ')[0];
            int idrole = int.Parse(idString);
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("ajouter_utilisateur", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@nom",SqlDbType.VarChar).Value = tb_nom.Text;
                commande.Parameters.Add("@prenom", SqlDbType.VarChar).Value = tb_prenom.Text;
                commande.Parameters.Add("@identifiant", SqlDbType.VarChar).Value = tb_identifiant.Text;
                commande.Parameters.Add("@motdepasse", SqlDbType.VarChar).Value = tb_mdp.Text;
                commande.Parameters.Add("@role", SqlDbType.Int).Value = idrole;
                if (cb_zone.Visible == true)
                {
                    string zone = cb_zone.SelectedItem.ToString();
                    string idzonetexte = texte.Split(' ')[0];
                    int idzone = int.Parse(idzonetexte);
                    commande.Parameters.Add("@zone", SqlDbType.Int).Value = idzone;
                }
                else
                {
                    commande.Parameters.Add("@zone", SqlDbType.Int).Value = -1;
                }
                    link.Open();
                commande.ExecuteScalar();
                link.Close();
                tb_nom.Text = string.Empty;
                tb_prenom.Text = string.Empty;
                tb_identifiant.Text = string.Empty;
                tb_mdp.Text = string.Empty;
            }
        }
    }
}
