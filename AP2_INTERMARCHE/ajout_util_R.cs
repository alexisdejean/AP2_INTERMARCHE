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
            cb_role.Items.Clear();
            cb_zone.Items.Clear();
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            link.Open();

            using (SqlCommand commande = new SqlCommand("afficherlesroles", link))
            {
                commande.CommandType = CommandType.StoredProcedure;
                using SqlDataReader datereader = commande.ExecuteReader();
                while (datereader.Read())
                {
                    int id = datereader.GetInt32(0);
                    string libelle = datereader.GetString(1);
                    cb_role.Items.Add(id.ToString() + ' ' + libelle);
                }
            }

            using SqlCommand commandeZone = new SqlCommand("afficherleszones", link);
            commandeZone.CommandType = CommandType.StoredProcedure;
            using SqlDataReader dataZone = commandeZone.ExecuteReader();
            while (dataZone.Read())
            {
                int idZone = dataZone.GetInt32(0);
                string libelleZone = dataZone.GetString(1);
                cb_zone.Items.Add(idZone.ToString() + ' ' + libelleZone);
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
            if (cb_role.SelectedItem == null)
            {
                cb_zone.Visible = false;
                cb_zone.SelectedIndex = -1;
                return;
            }

            string texte = cb_role.SelectedItem.ToString()!;
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
            if (cb_role.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un rôle.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string roleTexte = cb_role.SelectedItem.ToString();
                int idRole = int.Parse(roleTexte.Split(' ')[0]);
                string connexion = global.connection;
                string identifiant = tb_identifiant.Text.Trim();

                using (SqlConnection link = new SqlConnection(connexion))
                using (SqlCommand commande = new SqlCommand("AjouterUtilisateur", link))
                {
                    link.Open();

                    if (IdentifiantExiste(link, identifiant))
                    {
                        MessageBox.Show("Cet identifiant existe dÃ©jÃ . Veuillez en choisir un autre.", "Identifiant dÃ©jÃ  utilisÃ©", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    commande.CommandType = CommandType.StoredProcedure;
                    commande.Parameters.Add("@nom", SqlDbType.VarChar).Value = tb_nom.Text.Trim();
                    commande.Parameters.Add("@prenom", SqlDbType.VarChar).Value = tb_prenom.Text.Trim();
                    commande.Parameters.Add("@identifiant", SqlDbType.VarChar).Value = identifiant;
                    commande.Parameters.Add("@password", SqlDbType.VarChar, 255).Value = global.HashPassword(tb_mdp.Text);
                    commande.Parameters.Add("@id_role", SqlDbType.Int).Value = idRole;

                    if (cb_zone.Visible)
                    {
                        if (cb_zone.SelectedItem == null)
                        {
                            MessageBox.Show("Veuillez sélectionner une zone pour ce rôle.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        string zoneTexte = cb_zone.SelectedItem.ToString();
                        int idZone = int.Parse(zoneTexte.Split(' ')[0]);
                        commande.Parameters.Add("@code_zone", SqlDbType.Int).Value = idZone;
                    }
                    else
                    {
                        commande.Parameters.Add("@code_zone", SqlDbType.Int).Value = DBNull.Value;
                    }

                    commande.ExecuteNonQuery();
                }

                MessageBox.Show("Utilisateur ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Clear fields
                tb_nom.Clear();
                tb_prenom.Clear();
                tb_identifiant.Clear();
                tb_mdp.Clear();
                cb_role.SelectedIndex = -1;
                cb_zone.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool IdentifiantExiste(SqlConnection link, string identifiant)
        {
            using SqlCommand verification = new SqlCommand(
                "SELECT COUNT(1) FROM Utilisateur WHERE Identifiant = @identifiant", link);
            verification.Parameters.Add("@identifiant", SqlDbType.VarChar, 100).Value = identifiant;

            return Convert.ToInt32(verification.ExecuteScalar()) > 0;
        }
    }
}
